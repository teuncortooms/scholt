using AbpRecipes.Recipes;
using AutoMapper;

namespace AbpRecipes;

public class AbpRecipesApplicationAutoMapperProfile : Profile
{
    public AbpRecipesApplicationAutoMapperProfile()
    {
        CreateMap<Recipe, RecipeDto>();
        CreateMap<CreateUpdateRecipeCommand, Recipe>();
    }
}
