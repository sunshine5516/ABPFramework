using System;
using System.Web.Http.Filters;
using Abp.Web;

namespace Abp.WebApi.Controllers.Dynamic.Builders
{
    /// <summary>
    /// �����������嶯̬API��������
    /// </summary>
    /// <typeparam name="T">������������</typeparam>
    public interface IBatchApiControllerBuilder<T>
    {
        /// <summary>
        /// ���ڹ������͡�
        /// </summary>
        /// <param name="predicate">Predicate to filter types</param>
        IBatchApiControllerBuilder<T> Where(Func<Type, bool> predicate);

        /// <summary>
        /// ��ӹ�����
        /// </summary>
        /// <param name="filters"> ������. </param>
        /// <returns>��ǰ������������ </returns>
        IBatchApiControllerBuilder<T> WithFilters(params IFilter[] filters);

        /// <summary>
        /// Enables/Disables API Explorer for dynamic controllers.
        /// </summary>
        IBatchApiControllerBuilder<T> WithApiExplorer(bool isEnabled);

        /// <summary>
        /// ����ű�
        /// Ĭ��enabled
        /// </summary>
        IBatchApiControllerBuilder<T> WithProxyScripts(bool isEnabled);

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="serviceNameSelector">Service name selector</param>
        /// <returns></returns>
        IBatchApiControllerBuilder<T> WithServiceName(Func<Type, string> serviceNameSelector);

        /// <summary>
        /// Used to perform actions for each method of all dynamic api controllers.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>��ǰ������������</returns>
        IBatchApiControllerBuilder<T> ForMethods(Action<IApiControllerActionBuilder> action);

        /// <summary>
        /// ����ʽ
        /// Ĭ��POST
        /// </summary>
        /// <returns>��ǰ������������</returns>
        IBatchApiControllerBuilder<T> WithConventionalVerbs();

        /// <summary>
        /// ����controller.
        /// �����ڹ��������������ô˷�����
        /// </summary>
        void Build();
    }
}