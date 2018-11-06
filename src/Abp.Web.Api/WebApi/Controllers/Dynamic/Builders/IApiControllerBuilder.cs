using System;
using System.Web.Http.Filters;
using Abp.Web;

namespace Abp.WebApi.Controllers.Dynamic.Builders
{
    public interface IApiControllerBuilder
    {
        /// <summary>
        /// Name of the controller.
        /// </summary>
        string ServiceName { get; }

        /// <summary>
        /// ��ȡ�˶�̬�������ķ���ӿڵ�����.
        /// It's typeof(T).
        /// </summary>
        Type ServiceInterfaceType { get; }

        /// <summary>
        /// ������
        /// </summary>
        IFilter[] Filters { get; set; }

        /// <summary>
        /// Is API Explorer enabled.
        /// </summary>
        bool? IsApiExplorerEnabled { get; set; }

        /// <summary>
        /// True, if using conventional verbs for this dynamic controller.
        /// </summary>
        bool ConventionalVerbs { get; set; }
    }

    /// <summary>
    /// �ýӿ����ڶ��嶯̬api��������
    /// </summary>
    /// <typeparam name="T">Type of the proxied object</typeparam>
    public interface IApiControllerBuilder<T> : IApiControllerBuilder
    {
        /// <summary>
        /// Ϊ��̬��������Ӷ���������.
        /// </summary>
        /// <param name="filters"> ������. </param>
        /// <returns>The current Controller Builder </returns>
        IApiControllerBuilder<T> WithFilters(params IFilter[] filters);

        /// <summary>
        /// Used to specify a method definition.
        /// </summary>
        /// <param name="methodName">Name of the method in proxied type</param>
        /// <returns>Action builder</returns>
        IApiControllerActionBuilder<T> ForMethod(string methodName);

        /// <summary>
        /// Used to perform actions for each method.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The current Controller Builder</returns>
        IApiControllerBuilder<T> ForMethods(Action<IApiControllerActionBuilder> action);

        /// <summary>
        /// Use conventional Http Verbs by method names.
        /// By default, it uses <see cref="HttpVerb.Post"/> for all actions.
        /// </summary>
        /// <returns>The current Controller Builder</returns>
        IApiControllerBuilder<T> WithConventionalVerbs();

        /// <summary>
        /// Enables/Disables API Explorer for the Dynamic Controller.
        /// </summary>
        IApiControllerBuilder<T> WithApiExplorer(bool isEnabled);

        /// <summary>
        /// Enables/Disables proxy scripting for the Dynamic Controller.
        /// It's enabled by default.
        /// </summary>
        IApiControllerBuilder<T> WithProxyScripts(bool isEnabled);

        /// <summary>
        /// Builds the controller.
        /// This method must be called at last of the build operation.
        /// </summary>
        void Build();
    }
}