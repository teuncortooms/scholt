namespace Recipes.Security
{
    internal static class CorsExtensions
    {
        internal static IServiceCollection AddCorsPolicies(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Development", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
                options.AddPolicy("Production", _ => { });
            });

            return services;
        }
    }
}
