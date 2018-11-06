using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpDemo.Authorization
{
    public class TaskAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Tasks, L("Tasks"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpDemoConsts.LocalizationSourceName);
        }
    }
}
