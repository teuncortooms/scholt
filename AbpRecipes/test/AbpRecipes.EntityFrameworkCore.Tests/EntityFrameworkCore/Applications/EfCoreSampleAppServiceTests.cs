using AbpRecipes.Samples;
using Xunit;

namespace AbpRecipes.EntityFrameworkCore.Applications;

[Collection(AbpRecipesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpRecipesEntityFrameworkCoreTestModule>
{

}
