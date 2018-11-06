using System.Web.Http;
using System.Web.Http.Controllers;
using System.Collections.ObjectModel;
using System.Web.Http.Filters;
using Abp.Collections.Extensions;

namespace Abp.WebApi.Controllers.Dynamic.Selectors
{
    /// <summary>
    /// 该类用于扩展默认控制器描述符以动态添加动作过滤器。
    /// </summary>
    public class DynamicHttpControllerDescriptor : HttpControllerDescriptor
    {
        /// <summary>
        /// The Dynamic Controller Action filters.
        /// </summary>
        private readonly DynamicApiControllerInfo _controllerInfo;

        private readonly object[] _attributes;
        private readonly object[] _declaredOnlyAttributes;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">The Http Configuration.</param>
        /// <param name="controllerInfo">Controller info</param>
        public DynamicHttpControllerDescriptor(HttpConfiguration configuration, DynamicApiControllerInfo controllerInfo)
            : base(configuration, controllerInfo.ServiceName, controllerInfo.ApiControllerType)
        {
            _controllerInfo = controllerInfo;

            _attributes = controllerInfo.ServiceInterfaceType.GetCustomAttributes(true);
            _declaredOnlyAttributes = controllerInfo.ServiceInterfaceType.GetCustomAttributes(false);
        }

        /// <summary>
        /// 重写控制器的GetFilters并添加动态控制器过滤器。
        /// </summary>
        /// <returns> The Collection of filters.</returns>
        public override Collection<IFilter> GetFilters()
        {
            if (_controllerInfo.Filters.IsNullOrEmpty())
            {
                return base.GetFilters();
            }

            var actionFilters = new Collection<IFilter>();

            foreach (var filter in _controllerInfo.Filters)
            {
                actionFilters.Add(filter);
            }

            foreach (var baseFilter in base.GetFilters())
            {
                actionFilters.Add(baseFilter);
            }

            return actionFilters;
        }

        public override Collection<T> GetCustomAttributes<T>(bool inherit)
        {
            var attributes = inherit ? _attributes : _declaredOnlyAttributes;
            return new Collection<T>(DynamicApiDescriptorHelper.FilterType<T>(attributes));
        }
    }
}
