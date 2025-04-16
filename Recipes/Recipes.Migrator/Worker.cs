using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Recipes.Core.Application.Database;
using Recipes.Migrator.Data;

namespace Recipes.Migrator;

internal class Worker : IHostedService
{
    private readonly ILogger<Worker> logger;
    private readonly RecipesContext dbContext;
    private readonly IHostApplicationLifetime lifetime;

    public Worker(ILogger<Worker> logger, RecipesContext dbContext, IHostApplicationLifetime lifetime)
    {
        this.logger = logger;
        this.dbContext = dbContext;
        this.lifetime = lifetime;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Starting migration");

            await dbContext.Database.MigrateAsync(cancellationToken);

            logger.LogInformation("Migration complete");

            if (dbContext.Recipes.Any())
            {
                logger.LogInformation("Database already contains data. Skipping seed.");
                return;
            }

            await SeedFromFiles(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Migration failed");
        }
        finally
        {
            lifetime.StopApplication();
        }
    }

    private async Task SeedFromFiles(CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting seed");

        var assembly = Assembly.GetExecutingAssembly();

        var resourceNames = assembly.GetManifestResourceNames();

        foreach (var fileName in resourceNames)
        {
            var stream = assembly.GetManifestResourceStream(fileName);

            if (stream == null)
            {
                logger.LogWarning("{file} not found", fileName);
                return;
            }

            var dtos = JsonSerializer.Deserialize<DataDto>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (dtos is null)
            {
                logger.LogError("Could not deserialize {file}", fileName);
                return;
            }

            var recipes = dtos.Recipes.Select(dto => dto.ToRecipe());

            dbContext.AddRange(recipes);
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Seeding complete");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Stopping application");

        return Task.CompletedTask;
    }
}