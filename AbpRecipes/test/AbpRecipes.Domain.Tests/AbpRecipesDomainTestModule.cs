using Volo.Abp.Modularity;

namespace AbpRecipes;

[DependsOn(
    typeof(AbpRecipesDomainModule),
    typeof(AbpRecipesTestBaseModule)
)]
public class AbpRecipesDomainTestModule : AbpModule
{

}
