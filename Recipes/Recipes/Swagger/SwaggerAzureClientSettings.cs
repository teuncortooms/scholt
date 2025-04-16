namespace Recipes.Swagger;

internal record SwaggerAzureClientSettings
{
    public const string SectionName = "SwaggerAzureClientSettings";

    public string AuthorizationUrl { get; set; } = null!;
    public string TokenUrl { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public string[] Scopes { get; set; } = null!;
}