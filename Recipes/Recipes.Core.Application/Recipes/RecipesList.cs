using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Core.Application.Common;
using Recipes.Core.Application.Database;
using Recipes.Core.Application.Recipes.Models;

namespace Recipes.Core.Application.Recipes;

public record RecipesListQuery : IRequest<PaginatedList<RecipeDto>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

internal class RecipesListHandler(RecipesContext dbContext)
    : IRequestHandler<RecipesListQuery, PaginatedList<RecipeDto>>
{
    public async Task<PaginatedList<RecipeDto>> Handle(RecipesListQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PageSize > 0 ? request.PageSize : 10;
        var page = request.Page > 0 ? request.Page: 1;

        var result = await dbContext.Recipes
            .Take(pageSize)
            .Skip(pageSize * (page - 1))
            .OrderBy(r => r.Name)
            .Select(r => new RecipeDto(r))
            .ToListAsync(cancellationToken);

        var total = await dbContext.Recipes.CountAsync(cancellationToken);

        return new PaginatedList<RecipeDto>
        {
            Result = result,
            Page = request.Page,
            PageSize = request.PageSize,
            Total = total
        };
    }
}