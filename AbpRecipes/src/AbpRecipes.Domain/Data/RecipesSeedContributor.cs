using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using AbpRecipes.Recipes;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AbpRecipes.Data;

public class RecipesSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Recipe, Guid> _recipesRepository;

    public RecipesSeedContributor(IRepository<Recipe, Guid> recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _recipesRepository.GetCountAsync() <= 0)
        {
            var recipes = GetRecipesFromFile();

            foreach (var recipe in recipes)
            {
                await _recipesRepository.InsertAsync(recipe, autoSave: true);
            }
        }
    }

    private List<Recipe> GetRecipesFromFile()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var resourceNames = assembly.GetManifestResourceNames();

        var fileName = resourceNames.First();

        var stream = assembly.GetManifestResourceStream(fileName);

        if (stream == null)
        {
            throw new FileNotFoundException(fileName);
        }

        var dtos = JsonSerializer.Deserialize<DataDto>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (dtos is null)
        {
            throw new SerializationException($"Could not deserialize {fileName}");
        }

        return dtos.Recipes.Select(dto => dto.ToRecipe()).ToList();
    }
}