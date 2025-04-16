using System.Text.Json;
using Recipes.Core.Application.Common;
using Recipes.Core.Application.Recipes.Models;

namespace Recipes.FunctionalTests
{
    public class RecipesListQueryTests
    {
        [Test]
        public async Task Should_Return_Recipes()
        {
            // Arrange
            var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Recipes_AppHost>();

            appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
            {
                clientBuilder.AddStandardResilienceHandler();
            });

            await using var app = await appHost.BuildAsync();

            var resourceNotificationService = app.Services.GetRequiredService<ResourceNotificationService>();

            await app.StartAsync();

            // Act
            var httpClient = app.CreateHttpClient("recipes");

            await resourceNotificationService.WaitForResourceAsync("recipes", KnownResourceStates.Running).WaitAsync(TimeSpan.FromSeconds(30));

            var response = await httpClient.GetAsync("/recipes");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var stream = await response.Content.ReadAsStreamAsync();
            var recipeResponse = JsonSerializer.Deserialize<PaginatedList<RecipeDto>>(stream);

            Assert.That(recipeResponse?.Result.Count > 0);
            Assert.That(recipeResponse?.Page == 1);
            Assert.That(recipeResponse?.PageSize == 10);
        }
    }
}
