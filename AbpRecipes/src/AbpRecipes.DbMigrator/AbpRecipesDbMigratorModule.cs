using AbpRecipes.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpRecipes.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpRecipesEntityFrameworkCoreModule),
    typeof(AbpRecipesApplicationContractsModule)
)]
public class AbpRecipesDbMigratorModule : AbpModule
{
}
