﻿using System.Reflection;
using Abp.Dependency;

namespace Abp.WebApi.Controllers.Dynamic.Builders
{
    /// <summary>
    /// 为任意类型生成动态API控制器。
    /// </summary>
    public class DynamicApiControllerBuilder : IDynamicApiControllerBuilder
    {
        private readonly IIocResolver _iocResolver;

        public DynamicApiControllerBuilder(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
        }

        /// <summary>
        /// 为给定类型生成一个新的动态api控制器。
        /// </summary>
        /// <param name="serviceName">服务名称. For example: 'myapplication/myservice'.</param>
        /// <typeparam name="T">Type of the proxied object</typeparam>
        public IApiControllerBuilder<T> For<T>(string serviceName)
        {
            return new ApiControllerBuilder<T>(serviceName, _iocResolver);
        }

        /// <summary>
        /// 生成多个动态API控制器.
        /// </summary>
        /// <typeparam name="T">Base type (class or interface) for services</typeparam>
        /// <param name="assembly">程序集包含的类型</param>
        /// <param name="servicePrefix">Service prefix</param>
        public IBatchApiControllerBuilder<T> ForAll<T>(Assembly assembly, string servicePrefix)
        {
            return new BatchApiControllerBuilder<T>(_iocResolver, this,  assembly, servicePrefix);
        }
    }
}
