using System;

namespace Abp.Dependency
{
    /// <summary>
    /// �ýӿ����ڰ�װ��IOC���������Ķ���
    /// It inherits <see cref="IDisposable"/>, so resolved object can be easily released.
    /// In <see cref="IDisposable.Dispose"/> method, <see cref="IIocResolver.Release"/> is called to dispose the object.
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    public interface IDisposableDependencyObjectWrapper<out T> : IDisposable
    {
        /// <summary>
        /// ��������.
        /// </summary>
        T Object { get; }
    }
}