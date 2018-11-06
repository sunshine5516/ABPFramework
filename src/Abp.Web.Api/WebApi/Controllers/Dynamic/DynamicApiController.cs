using System.Collections.Generic;
using Abp.Application.Services;

namespace Abp.WebApi.Controllers.Dynamic
{
    /// <summary>
    /// 用作所有动态生成的ApiController的基类
    /// </summary>
    /// <typeparam name="T">代理对象的类型</typeparam>
    /// <remarks>
    /// 动态ApiController用于将对象（通常为Application Service类）透明地显示给远程客户端。
    /// </remarks>
    public class DynamicApiController<T> : AbpApiController, IDynamicApiController, IAvoidDuplicateCrossCuttingConcerns
    {
        public List<string> AppliedCrossCuttingConcerns { get; }

        public DynamicApiController()
        {
            AppliedCrossCuttingConcerns = new List<string>();
        }
    }
}