using System.ComponentModel.DataAnnotations;
using Recipes.Core.Application.Recipes;

namespace Recipes.API.UnitTests.Recipes;

public class RecipeCreateValidationTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Recipe_Name_Should_Be_Required()
    {
        var recipeCommand = new RecipeCreateCommand
        {
            Name = string.Empty,
            Ingredients = ["Ingredient 1", "Ingredient 2"],
            Instructions = ["Instruction 1", "Instruction 2"]
        };

        var context = new ValidationContext(recipeCommand);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(recipeCommand, context, results, true);

        Assert.That(!isValid);
        Assert.That(results.Any(r => r.MemberNames.Contains("Name")));
    }
}