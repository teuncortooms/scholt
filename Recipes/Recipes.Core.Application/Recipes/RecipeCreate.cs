using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Recipes.Core.Application.Database;
using Recipes.Core.Application.Recipes.Models;
using Recipes.Core.Domain.Entities;
using Recipes.Core.Domain.Exceptions;

namespace Recipes.Core.Application.Recipes;

public record RecipeCreateCommand : IRequest
{
    [Required]
    [StringLength(100, MinimumLength = 3)] 
    public required string Name { get; set; }
    [MinLength(2)]
    public IList<string> Ingredients { get; set; } = [];
    [MinLength(2)]
    public IList<string> Instructions { get; set; } = [];

}

internal class RecipeCreateHandler(RecipesContext dbContext, ILogger<RecipeCreateHandler> logger)
    : IRequestHandler<RecipeCreateCommand>
{
    public async Task Handle(RecipeCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newRecipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Ingredients = request.Ingredients
                    .Select(i => new Ingredient { Text = i })
                    .ToList(),
                Instructions = request.Instructions
                    .Select(i => new Instruction { Text = i })
                    .ToList()
            };

            dbContext.Add(newRecipe);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Create recipe failed");
            throw new UserFriendlyCoreException("Create recipe failed");
        }
    }
}