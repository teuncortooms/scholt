using Recipes.Core.Domain.Entities;

namespace Recipes.Core.Application.Recipes.Models;

public class RecipeDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IList<string> Ingredients { get; set; }
    public int Steps { get; set; }

    public RecipeDetailsDto(Recipe recipe)
    {
        Id = recipe.Id;
        Name = recipe.Name;
        Ingredients = recipe.Ingredients.Select(i => i.Text).ToList();
        Steps = recipe.Instructions.Count;
    }
}