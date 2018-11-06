using System;

namespace Abp.Runtime.Caching.Configuration
{
    /// <summary>
    ///��ע��Ļ����������ӿ�
    /// </summary>
    public interface ICacheConfigurator
    {
        /// <summary>
        /// ��������
        /// ��������ó����������л��棬����Ϊ�ա�
        /// </summary>
        string CacheName { get; }

        /// <summary>
        /// ���ò����� �ڴ�������֮����á�
        /// </summary>
        Action<ICache> InitAction { get; }
    }
}