using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using AbpDemo;
using Microsoft.AspNet.Identity;

namespace AbpDemo.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class ABPFrameworkDemoControllerBase : AbpController
    {
        protected ABPFrameworkDemoControllerBase()
        {
            LocalizationSourceName = AbpDemoConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}