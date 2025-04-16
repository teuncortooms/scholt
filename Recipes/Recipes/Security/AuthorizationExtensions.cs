using Microsoft.Identity.Web;
using Recipes.Core.Domain.Exceptions;
using Recipes.NewFolder;

namespace Recipes.Security;

internal static class AuthorizationExtensions
{
    internal static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization(o =>
        {
            o.AddPolicy(Policies.MembersOnly, b =>
            {
                var write = configuration["AzureAd:Scopes:Write"]
                            ?? throw new CoreException("Missing scopes configuration");

                b.RequireScope(write);
            });
        });

        return services;
    }
}