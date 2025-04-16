using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Core.Application.Database;
using Recipes.Core.Domain.Exceptions;
using System.Reflection;

namespace Recipes.Core.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddDbContext<RecipesContext>(o =>
        {
            o.UseSqlServer(configuration.GetConnectionString("database"));
        });

        return services;
    }
}