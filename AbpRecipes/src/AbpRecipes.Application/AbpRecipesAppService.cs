using AbpRecipes.Localization;
using Volo.Abp.Application.Services;

namespace AbpRecipes;

/* Inherit your application services from this class.
 */
public abstract class AbpRecipesAppService : ApplicationService
{
    protected AbpRecipesAppService()
    {
        LocalizationResource = typeof(AbpRecipesResource);
    }
}
