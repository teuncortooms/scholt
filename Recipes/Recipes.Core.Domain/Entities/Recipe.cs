namespace Recipes.Core.Domain.Entities;

public class Recipe 
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required List<Ingredient> Ingredients { get; init; } 
    public required List<Instruction> Instructions { get; init; } 
    public required string CreatedBy { get; init; }
    public required DateTime CreatedOn { get; init; }
}