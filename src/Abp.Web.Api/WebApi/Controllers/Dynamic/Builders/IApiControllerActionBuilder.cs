using System.Reflection;
using Abp.Web;
using System.Web.Http.Filters;

namespace Abp.WebApi.Controllers.Dynamic.Builders
{
    public interface IApiControllerActionBuilder
    {
        /// <summary>
        /// 关联到此action的controller.
        /// </summary>
        IApiControllerBuilder Controller { get; }

        /// <summary>
        /// action名称.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Gets the action method.
        /// </summary>
        MethodInfo Method { get; }

        /// <summary>
        /// 当前的Http Verb设置.
        /// </summary>
        HttpVerb? Verb { get; set; }

        /// <summary>
        /// Is API Explorer enabled.
        /// </summary>
        bool? IsApiExplorerEnabled { get; set; }

        /// <summary>
        /// 过滤器
        /// </summary>
        IFilter[] Filters { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to create action for this method.
        /// </summary>
        bool DontCreate { get; set; }
    }

    /// <summary>
    /// This interface is used to define a dynamic api controller action.
    /// </summary>
    /// <typeparam name="T">Type of the proxied object</typeparam>
    public interface IApiControllerActionBuilder<T>: IApiControllerActionBuilder
    {
        /// <summary>
        /// Used to specify Http verb of the action.
        /// </summary>
        /// <param name="verb">Http very</param>
        /// <returns>Action builder</returns>
        IApiControllerActionBuilder<T> WithVerb(HttpVerb verb);

        /// <summary>
        /// Enables/Disables API Explorer for the action.
        /// </summary>
        IApiControllerActionBuilder<T> WithApiExplorer(bool isEnabled);

        /// <summary>
        /// Used to specify another method definition.
        /// </summary>
        /// <param name="methodName">Name of the method in proxied type</param>
        /// <returns>Action builder</returns>
        IApiControllerActionBuilder<T> ForMethod(string methodName);

        /// <summary>
        /// 不创建动作.
        /// </summary>
        /// <returns>Controller builder</returns>
        IApiControllerBuilder<T> DontCreateAction();

        /// <summary>
        /// 创建控制器.
        /// This method must be called at last of the build operation.
        /// </summary>
        void Build();

        /// <summary>
        /// 过滤器
        /// </summary>
        /// <param name="filters"> Action Filters to apply.</param>
        IApiControllerActionBuilder<T> WithFilters(params IFilter[] filters);
    }
}