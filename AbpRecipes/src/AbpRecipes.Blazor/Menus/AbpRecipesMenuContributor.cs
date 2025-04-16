using System.Threading.Tasks;
using AbpRecipes.Localization;
using AbpRecipes.Permissions;
using AbpRecipes.MultiTenancy;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.Identity.Blazor;

namespace AbpRecipes.Blazor.Menus;

public class AbpRecipesMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<AbpRecipesResource>();
        
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AbpRecipesMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 1
            )
        );

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 6;

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Recipes",
                l["Menu:Recipes"],
                icon: "fa fa-pot-food",
                url: "/recipes"
            )
        );

        return Task.CompletedTask;
    }
}
