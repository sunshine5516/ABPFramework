using System;

namespace Abp.Dependency
{
    /// <summary>    
    /// ��������������������Ľӿڡ�
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// ��IOC������ȡ����
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">��ȡ�Ķ��������</typeparam>
        /// <returns>����ʵ��</returns>
        T Resolve<T>();

        /// <summary>
        /// ��IOC������ȡ����.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">ҪͶ������������</typeparam>
        /// <param name="type">Ҫ�����Ķ��������</param>
        /// <returns>����ʵ��</returns>
        T Resolve<T>(Type type);

        /// <summary>
        /// ��IOC������ȡ����
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">Ҫ��ȡ�Ķ��������</typeparam>
        /// <param name="argumentsAsAnonymousType">���캯������</param>
        /// <returns>����ʵ��</returns>
        T Resolve<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// ��IOC������ȡ����.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Ҫ��ȡ�Ķ��������</param>
        /// <returns>����ʵ��</returns>
        object Resolve(Type type);

        /// <summary>
        /// ��IOC������ȡ����.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Ҫ��ȡ�Ķ��������</param>
        /// <param name="argumentsAsAnonymousType">���캯������s</param>
        /// <returns>����ʵ��</returns>
        object Resolve(Type type, object argumentsAsAnonymousType);

        /// <summary>
        /// ��ȡ�������͵�����ʵ��.
        /// Returning objects must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">Ҫ�����Ķ��������</typeparam>
        /// <returns>����ʵ��</returns>
        T[] ResolveAll<T>();

        /// <summary>
        /// ��ȡ�������͵�����ʵ��.
        /// Returning objects must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">Ҫ�����Ķ��������</typeparam>
        /// <param name="argumentsAsAnonymousType">���캯������</param>
        /// <returns>����ʵ��</returns>
        T[] ResolveAll<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// ��ȡ�������͵�����ʵ��
        /// Returning objects must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Ҫ�����Ķ��������</param>
        /// <returns>����ʵ��</returns>
        object[] ResolveAll(Type type);

        /// <summary>
        /// ��ȡ�������͵�����ʵ��.
        /// Returning objects must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Ҫ�����Ķ��������</param>
        /// <param name="argumentsAsAnonymousType">���캯����</param>
        /// <returns>����ʵ��</returns>
        object[] ResolveAll(Type type, object argumentsAsAnonymousType);

        /// <summary>
        /// �ͷ�Ԥ�Ƚ����Ķ��� ����Ľ���������
        /// </summary>
        /// <param name="obj">Ҫ�ͷŵĶ���d</param>
        void Release(object obj);

        /// <summary>
        /// �����������Ƿ���֮ǰע��.
        /// </summary>
        /// <param name="type">�������</param>
        bool IsRegistered(Type type);

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        bool IsRegistered<T>();
    }
}