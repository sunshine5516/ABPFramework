using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Abp.Collections.Extensions;
using Abp.Dependency;

namespace Abp.WebApi.Controllers.Dynamic
{
    /// <summary>
    /// �ṩ��һ��Dictionary�����������е�DynamicApiControllerInfo����
    /// </summary>
    public class DynamicApiControllerManager : ISingletonDependency
    {
        private readonly IDictionary<string, DynamicApiControllerInfo> _dynamicApiControllers;

        public DynamicApiControllerManager()
        {
            _dynamicApiControllers = new Dictionary<string, DynamicApiControllerInfo>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// ע���������Ϣ.
        /// </summary>
        /// <param name="controllerInfo">Controller info</param>
        public void Register(DynamicApiControllerInfo controllerInfo)
        {
            _dynamicApiControllers[controllerInfo.ServiceName] = controllerInfo;
        }

        /// <summary>
        /// ���ҿ�����
        /// </summary>
        /// <param name="controllerName">Name of the controller</param>
        /// <returns>Controller info</returns>
        public DynamicApiControllerInfo FindOrNull(string controllerName)
        {
            return _dynamicApiControllers.GetOrDefault(controllerName);
        }
        /// <summary>
        /// �������п�������Ϣ
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<DynamicApiControllerInfo> GetAll()
        {
            return _dynamicApiControllers.Values.ToImmutableList();
        }
    }
}