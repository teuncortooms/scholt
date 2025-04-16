using Recipes.Core.Domain.Entities;

namespace Recipes.Migrator.Data;

internal class DataDto
{
    public List<RecipeDto> Recipes { get; set; }
}

internal class RecipeDto
{
    public required string Name { get; set; }
    public required List<string> Ingredients { get; set; }
    public required List<string> Instructions { get; set; }

    public Core.Domain.Entities.Recipe ToRecipe()
    {
        return new Core.Domain.Entities.Recipe
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Ingredients = Ingredients.Select(i => new Ingredient { Text = i }).ToList(),
            Instructions = Instructions.Select(i => new Instruction { Text = i }).ToList()
        };
    }
}