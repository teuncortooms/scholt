using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Core.Application.Database;
using Recipes.Core.Application.Recipes.Models;
using Recipes.Core.Domain.Entities;

namespace Recipes.Core.Application.Recipes;

public record RecipeGetByNameQuery(string Name) : IRequest<RecipeDetailsDto?>;

internal class RecipeGetByNameHandler(RecipesContext dbContext)
    : IRequestHandler<RecipeGetByNameQuery, RecipeDetailsDto?>
{
    public Task<RecipeDetailsDto?> Handle(RecipeGetByNameQuery request, CancellationToken cancellationToken)
    {
        var normalizatedName = request.Name.ToLower();

        return dbContext.Recipes
            .Where(r => r.Name.ToLower() == normalizatedName)
            .Select(r => new RecipeDetailsDto(r))
            .FirstOrDefaultAsync(cancellationToken);
    }
}