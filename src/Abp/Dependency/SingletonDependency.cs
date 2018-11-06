using System;

namespace Abp.Dependency
{
    /// <summary>
    /// 为容器中的实例生成Singelton实例的方法
    /// Important: Use classes by injecting wherever possible. This class is for cases that's not possible.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class SingletonDependency<T>
    {
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static T Instance => LazyInstance.Value;
        private static readonly Lazy<T> LazyInstance;

        static SingletonDependency()
        {
            LazyInstance = new Lazy<T>(() => IocManager.Instance.Resolve<T>(), true);
        }
    }
}
