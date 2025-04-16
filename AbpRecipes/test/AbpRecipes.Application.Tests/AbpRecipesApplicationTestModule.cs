using Volo.Abp.Modularity;

namespace AbpRecipes;

[DependsOn(
    typeof(AbpRecipesApplicationModule),
    typeof(AbpRecipesDomainTestModule)
)]
public class AbpRecipesApplicationTestModule : AbpModule
{

}
