using System;
using System.Web.Http.Filters;
using Abp.Web;

namespace Abp.WebApi.Controllers.Dynamic.Builders
{
    /// <summary>
    /// 用于批量定义动态API控制器。
    /// </summary>
    /// <typeparam name="T">代理对象的类型</typeparam>
    public interface IBatchApiControllerBuilder<T>
    {
        /// <summary>
        /// 用于过滤类型。
        /// </summary>
        /// <param name="predicate">Predicate to filter types</param>
        IBatchApiControllerBuilder<T> Where(Func<Type, bool> predicate);

        /// <summary>
        /// 添加过滤器
        /// </summary>
        /// <param name="filters"> 过滤器. </param>
        /// <returns>当前控制器构建器 </returns>
        IBatchApiControllerBuilder<T> WithFilters(params IFilter[] filters);

        /// <summary>
        /// Enables/Disables API Explorer for dynamic controllers.
        /// </summary>
        IBatchApiControllerBuilder<T> WithApiExplorer(bool isEnabled);

        /// <summary>
        /// 代理脚本
        /// 默认enabled
        /// </summary>
        IBatchApiControllerBuilder<T> WithProxyScripts(bool isEnabled);

        /// <summary>
        /// 服务名称
        /// </summary>
        /// <param name="serviceNameSelector">Service name selector</param>
        /// <returns></returns>
        IBatchApiControllerBuilder<T> WithServiceName(Func<Type, string> serviceNameSelector);

        /// <summary>
        /// Used to perform actions for each method of all dynamic api controllers.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>当前控制器构建器</returns>
        IBatchApiControllerBuilder<T> ForMethods(Action<IApiControllerActionBuilder> action);

        /// <summary>
        /// 请求方式
        /// 默认POST
        /// </summary>
        /// <returns>当前控制器构建器</returns>
        IBatchApiControllerBuilder<T> WithConventionalVerbs();

        /// <summary>
        /// 构建controller.
        /// 必须在构建操作的最后调用此方法。
        /// </summary>
        void Build();
    }
}