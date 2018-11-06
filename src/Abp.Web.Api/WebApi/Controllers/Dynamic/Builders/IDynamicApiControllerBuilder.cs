using System.Reflection;

namespace Abp.WebApi.Controllers.Dynamic.Builders
{
    /// <summary>
    /// 构建动态API接口
    /// </summary>
    public interface IDynamicApiControllerBuilder
    {
        IApiControllerBuilder<T> For<T>(string serviceName);

        IBatchApiControllerBuilder<T> ForAll<T>(Assembly assembly, string servicePrefix);
    }
}