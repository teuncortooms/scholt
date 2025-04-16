using AbpRecipes.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpRecipes.Blazor;

public abstract class AbpRecipesComponentBase : AbpComponentBase
{
    protected AbpRecipesComponentBase()
    {
        LocalizationResource = typeof(AbpRecipesResource);
    }
}
