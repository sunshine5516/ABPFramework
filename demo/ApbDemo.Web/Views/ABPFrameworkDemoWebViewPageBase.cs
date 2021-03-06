﻿using Abp.Web.Mvc.Views;
namespace AbpDemo.Web.Views
{
    public abstract class ABPFrameworkDemoWebViewPageBase : ABPFrameworkDemoWebViewPageBase<dynamic>
    {

    }

    public abstract class ABPFrameworkDemoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ABPFrameworkDemoWebViewPageBase()
        {
            LocalizationSourceName = AbpDemoConsts.LocalizationSourceName;
        }
    }
}