using Volo.Abp.Modularity;

namespace AbpRecipes;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpRecipesDomainTestBase<TStartupModule> : AbpRecipesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
