using AbpRecipes.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpRecipes.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpRecipesController : AbpControllerBase
{
    protected AbpRecipesController()
    {
        LocalizationResource = typeof(AbpRecipesResource);
    }
}
