using System.Text.Json;
using Aspire.Hosting;
using NUnit.Framework.Legacy;
using Recipes.Core.Application.Common;
using Recipes.Core.Application.Recipes.Models;

namespace Recipes.FunctionalTests
{
    public class RecipesListQueryTests
    {
        private DistributedApplication app;

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var appHost = await DistributedApplicationTestingBuilder
                .CreateAsync<Projects.Recipes_AppHost>(
                [
                    "--isTestRun=true"
                ]);

            appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
            {
                clientBuilder.AddStandardResilienceHandler();
            });

            var sql = appHost.Resources.Single(r => r.Name == "sql");

            CollectionAssert.IsEmpty(sql.Annotations.OfType<ContainerMountAnnotation>());

            app = await appHost.BuildAsync();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown() => await app.DisposeAsync();

        [Test]
        public async Task Should_Return_Recipes()
        {
            var resourceNotificationService = app.Services.GetRequiredService<ResourceNotificationService>();

            await app.StartAsync();

            // Act
            var httpClient = app.CreateHttpClient("recipes");

            await resourceNotificationService
                .WaitForResourceAsync("recipes", KnownResourceStates.Running)
                .WaitAsync(TimeSpan.FromSeconds(30));

            var response = await httpClient.GetAsync("/recipes");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var stream = await response.Content.ReadAsStreamAsync();
            var recipeResponse = JsonSerializer.Deserialize<PaginatedList<RecipeDto>>(stream,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            Assert.That(recipeResponse?.Result.Count == 3);
            Assert.That(recipeResponse?.Page == 1);
            Assert.That(recipeResponse?.PageSize == 10);
        }
    }
}
