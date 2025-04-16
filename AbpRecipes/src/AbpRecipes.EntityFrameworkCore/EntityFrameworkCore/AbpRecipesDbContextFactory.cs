using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpRecipes.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AbpRecipesDbContextFactory : IDesignTimeDbContextFactory<AbpRecipesDbContext>
{
    public AbpRecipesDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AbpRecipesEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AbpRecipesDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new AbpRecipesDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpRecipes.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
