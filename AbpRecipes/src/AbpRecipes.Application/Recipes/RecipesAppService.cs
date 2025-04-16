using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpRecipes.Recipes;

public class RecipesAppService :
    CrudAppService<Recipe, RecipeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateRecipeCommand>,
    IRecipesAppService 
{
    public RecipesAppService(IRepository<Recipe, Guid> repository) : base(repository)
    {

    }
}