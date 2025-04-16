using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpRecipes.Recipes;

public interface IRecipesAppService :
    ICrudAppService<RecipeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateRecipeCommand> 
{ }