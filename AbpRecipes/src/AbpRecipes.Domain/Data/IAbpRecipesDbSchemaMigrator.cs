using System.Threading.Tasks;

namespace AbpRecipes.Data;

public interface IAbpRecipesDbSchemaMigrator
{
    Task MigrateAsync();
}
