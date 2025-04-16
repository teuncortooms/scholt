using AbpRecipes.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AbpRecipes.Permissions;

public class AbpRecipesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpRecipesPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpRecipesPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpRecipesResource>(name);
    }
}
