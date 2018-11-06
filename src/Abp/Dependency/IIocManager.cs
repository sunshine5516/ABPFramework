using System;
using Castle.Windsor;

namespace Abp.Dependency
{
    /// <summary>
    /// �ýӿ�����ֱ��ִ������ע������
    /// </summary>
    public interface IIocManager : IIocRegistrar, IIocResolver, IDisposable
    {
        /// <summary>
        /// IWindsorContainerע������
        /// </summary>
        IWindsorContainer IocContainer { get; }

        /// <summary>
        /// �����Ƿ��Ѿ�ע��
        /// </summary>
        /// <param name="type">Type to check</param>
        new bool IsRegistered(Type type);

        /// <summary>
        /// �����Ƿ��Ѿ�ע��
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        new bool IsRegistered<T>();
    }
}