using Volo.Abp.Modularity;

namespace AbpRecipes;

public abstract class AbpRecipesApplicationTestBase<TStartupModule> : AbpRecipesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
