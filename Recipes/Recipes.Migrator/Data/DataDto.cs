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

    public Recipe ToRecipe()
    {
        return new Recipe
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Ingredients = Ingredients.Select(i => new Ingredient { Text = i }).ToList(),
            Instructions = Instructions.Select(i => new Instruction { Text = i }).ToList(),
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now
        };
    }
}