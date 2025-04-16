using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Core.Application.Database;
using Recipes.Core.Application.Recipes.Models;

namespace Recipes.Core.Application.Recipes;

public record RecipeGetByIdQuery(Guid Id) : IRequest<RecipeDetailsDto?>;

internal class RecipeGetByIdHandler(RecipesContext dbContext)
    : IRequestHandler<RecipeGetByIdQuery, RecipeDetailsDto?>
{
    public Task<RecipeDetailsDto?> Handle(RecipeGetByIdQuery request, CancellationToken cancellationToken)
    {
        return dbContext.Recipes
            .Where(r => r.Id == request.Id)
            .Select(recipe => new RecipeDetailsDto(recipe))
            .FirstOrDefaultAsync(cancellationToken);
    }
}