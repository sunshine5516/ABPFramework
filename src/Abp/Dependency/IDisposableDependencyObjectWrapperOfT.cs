using System;

namespace Abp.Dependency
{
    /// <summary>
    /// 该接口用于包装从IOC容器解析的对象。
    /// It inherits <see cref="IDisposable"/>, so resolved object can be easily released.
    /// In <see cref="IDisposable.Dispose"/> method, <see cref="IIocResolver.Release"/> is called to dispose the object.
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    public interface IDisposableDependencyObjectWrapper<out T> : IDisposable
    {
        /// <summary>
        /// 解析对象.
        /// </summary>
        T Object { get; }
    }
}