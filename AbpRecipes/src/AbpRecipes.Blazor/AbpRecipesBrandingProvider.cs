using Microsoft.Extensions.Localization;
using AbpRecipes.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpRecipes.Blazor;

[Dependency(ReplaceServices = true)]
public class AbpRecipesBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AbpRecipesResource> _localizer;

    public AbpRecipesBrandingProvider(IStringLocalizer<AbpRecipesResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
