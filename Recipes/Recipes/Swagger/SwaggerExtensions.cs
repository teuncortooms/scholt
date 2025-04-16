using Microsoft.OpenApi.Models;

namespace Recipes.API.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Swagger UI for Recipes API"
            });
        });

        return services;
    }

    public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseSwagger();
        app.UseSwaggerUI(o =>
        {
            o.SwaggerEndpoint("/openapi/v1.json", "v1");
        });
    }
}