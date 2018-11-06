using System;
using System.Collections.Generic;
using System.Web.Http.Filters;

namespace Abp.WebApi.Controllers.Dynamic
{
    /// <summary>
    /// ��װApiController����Ϣ.
    /// </summary>
    public class DynamicApiControllerInfo
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// �ӿ�����
        /// </summary>
        public Type ServiceInterfaceType { get; private set; }

        /// <summary>
        /// Api����������.
        /// </summary>
        public Type ApiControllerType { get; private set; }

        /// <summary>
        /// ����������
        /// </summary>
        public Type InterceptorType { get; private set; }

        /// <summary>
        /// Is API Explorer enabled.
        /// </summary>
        public bool? IsApiExplorerEnabled { get; private set; }

        /// <summary>
        /// ������
        /// </summary>
        public IFilter[] Filters { get; set; }

        /// <summary>
        /// action����
        /// </summary>
        public IDictionary<string, DynamicApiActionInfo> Actions { get; private set; }

        /// <summary>
        /// ����ű��Ƿ�������
        /// </summary>
        public bool IsProxyScriptingEnabled { get; private set; }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="serviceName">��������</param>
        /// <param name="serviceInterfaceType">����ӿ�����</param>
        /// <param name="apiControllerType">Api����������</param>
        /// <param name="interceptorType">������</param>
        /// <param name="filters">������</param>
        /// <param name="isApiExplorerEnabled">Is API explorer enabled</param>
        /// <param name="isProxyScriptingEnabled">Is proxy scripting enabled</param>
        public DynamicApiControllerInfo(
            string serviceName, 
            Type serviceInterfaceType, 
            Type apiControllerType, 
            Type interceptorType, 
            IFilter[] filters = null,
            bool? isApiExplorerEnabled = null,
            bool isProxyScriptingEnabled = true)
        {
            ServiceName = serviceName;
            ServiceInterfaceType = serviceInterfaceType;
            ApiControllerType = apiControllerType;
            InterceptorType = interceptorType;
            IsApiExplorerEnabled = isApiExplorerEnabled;
            IsProxyScriptingEnabled = isProxyScriptingEnabled;
            Filters = filters ?? new IFilter[] { }; //Assigning or initialzing the action filters.

            Actions = new Dictionary<string, DynamicApiActionInfo>(StringComparer.InvariantCultureIgnoreCase);
        }
    }
}