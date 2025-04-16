using Microsoft.AspNetCore.Components;
using System;
using AbpRecipes.Localization;
using AbpRecipes.Recipes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BlazoriseUI;
using Volo.Abp.Localization;

namespace AbpRecipes.Blazor.Components.Pages;


public partial class Recipes : AbpCrudPageBase<IRecipesAppService, RecipeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateRecipeCommand>
{
    public Recipes()
    {
        LocalizationResource = typeof(AbpRecipesResource);
    }
}