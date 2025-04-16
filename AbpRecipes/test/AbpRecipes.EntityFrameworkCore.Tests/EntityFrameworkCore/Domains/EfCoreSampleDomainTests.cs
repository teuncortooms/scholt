using AbpRecipes.Samples;
using Xunit;

namespace AbpRecipes.EntityFrameworkCore.Domains;

[Collection(AbpRecipesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpRecipesEntityFrameworkCoreTestModule>
{

}
