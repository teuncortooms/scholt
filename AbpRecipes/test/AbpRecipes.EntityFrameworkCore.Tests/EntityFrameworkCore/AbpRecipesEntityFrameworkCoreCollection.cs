using Xunit;

namespace AbpRecipes.EntityFrameworkCore;

[CollectionDefinition(AbpRecipesTestConsts.CollectionDefinitionName)]
public class AbpRecipesEntityFrameworkCoreCollection : ICollectionFixture<AbpRecipesEntityFrameworkCoreFixture>
{

}
