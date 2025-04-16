using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Recipes.Core.Domain.Exceptions;

namespace Recipes.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerWithOAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var clientSettings = configuration
            .GetRequiredSection(SwaggerAzureClientSettings.SectionName)
            .Get<SwaggerAzureClientSettings>()
            ?? throw new CoreException("Swagger client not configured");

        services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Swagger UI for Recipes API"
            });

            o.AddSecurityDefinition("azureAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.OAuth2,
                In = ParameterLocation.Header,
                Name = "Authorization",
                Scheme = "Bearer",
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(clientSettings.AuthorizationUrl),
                        TokenUrl = new Uri(clientSettings.TokenUrl),
                        Scopes = clientSettings.Scopes.ToDictionary(scope => scope, scope => scope)
                    }
                }
            });

            o.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Name = "oauth2",
                        Scheme = "oauth2",
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "azureAuth"
                        }
                    },
                    clientSettings.Scopes
                }
            });
        });

        return services;
    }

    public static void UseSwaggerWithOAuth(this IApplicationBuilder app, IConfiguration configuration)
    {
        var clientSettings = configuration
            .GetRequiredSection(SwaggerAzureClientSettings.SectionName)
            .Get<SwaggerAzureClientSettings>()
            ?? throw new CoreException("Swagger client not configured");

        app.UseSwagger();
        app.UseSwaggerUI(o =>
        {
            o.SwaggerEndpoint("/openapi/v1.json", "v1");
            o.OAuthClientId(clientSettings.ClientId);
            o.OAuthUsePkce();
            o.OAuthUseBasicAuthenticationWithAccessCodeGrant();
        });
    }
}