using System;
using System.Transactions;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// ���ڱ�עĳ������λUnitOfWork��Attribute��. ͨ��������ԣ�����ָ���Ƿ�����UOW��������뼶��TransactionScopeOption��
    /// �������������ʾ�����ķ�����ԭ�ӵģ�Ӧ�ñ���Ϊ��һ��������Ԫ��
    /// ���д����Եķ��������أ������ݿ����Ӳ��ڵ��÷���֮ǰ��������
    /// �ڷ������ý���ʱ�����û���쳣�����ύ���񲢽����и���Ӧ�������ݿ⣬���򽫻ع���
    /// </summary>
    /// <remarks>
    /// ����ڵ��ô˷���֮ǰ�Ѿ���һ��������Ԫ��������Բ������ã������������ʹ����ͬ������
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Interface)]
    public class UnitOfWorkAttribute : Attribute
    {
        /// <summary>
        /// ������ѡ��.
        /// </summary>
        public TransactionScopeOption? Scope { get; set; }

        /// <summary>
        /// �Ƿ��������Ե�
        /// ���δ�ṩ����ʹ��Ĭ��ֵ
        /// </summary>
        public bool? IsTransactional { get; set; }

        /// <summary>
        /// ��ʱʱ��.
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// ������UOW�������Եģ����ѡ��ָ��������ĸ��뼶��
        /// ���δ�ṩ����ʹ��Ĭ��ֵ
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// ���ڷ�ֹΪ�÷�������һ��������Ԫ��
        /// ����Ѿ���һ����ʼ�Ĺ�����Ԫ�������������ԡ�
        /// Default: false.
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// ���캯��
        /// </summary>
        public UnitOfWorkAttribute()
        {

        }

        /// <summary>
        /// ���캯��.
        /// </summary>
        /// <param name="isTransactional">
        /// �Ƿ������Ե�?
        /// </param>
        public UnitOfWorkAttribute(bool isTransactional)
        {
            IsTransactional = isTransactional;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="timeout">��ʱʱ��</param>
        public UnitOfWorkAttribute(int timeout)
        {
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="isTransactional">�Ƿ������Ե�?</param>
        /// <param name="timeout">��ʱʱ��</param>
        public UnitOfWorkAttribute(bool isTransactional, int timeout)
        {
            IsTransactional = isTransactional;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// ���캯��
        /// <see cref="IsTransactional"/> is automatically set to true.
        /// </summary>
        /// <param name="isolationLevel">Transaction isolation level</param>
        public UnitOfWorkAttribute(IsolationLevel isolationLevel)
        {
            IsTransactional = true;
            IsolationLevel = isolationLevel;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="isolationLevel">������뼶��</param>
        /// <param name="timeout">����ʱΪ����</param>
        public UnitOfWorkAttribute(IsolationLevel isolationLevel, int timeout)
        {
            IsTransactional = true;
            IsolationLevel = isolationLevel;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="scope">������ѡ��</param>
        public UnitOfWorkAttribute(TransactionScopeOption scope)
        {
            IsTransactional = true;
            Scope = scope;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="scope">������ѡ��</param>
        /// <param name="isTransactional">
        /// Is this unit of work will be transactional?
        /// </param>
        public UnitOfWorkAttribute(TransactionScopeOption scope, bool isTransactional)
        {
            Scope = scope;
            IsTransactional = isTransactional;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="scope">������ѡ��</param>
        /// <param name="timeout">��ʱʱ��</param>
        public UnitOfWorkAttribute(TransactionScopeOption scope, int timeout)
        {
            IsTransactional = true;
            Scope = scope;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        internal UnitOfWorkOptions CreateOptions()
        {
            return new UnitOfWorkOptions
            {
                IsTransactional = IsTransactional,
                IsolationLevel = IsolationLevel,
                Timeout = Timeout,
                Scope = Scope
            };
        }
    }
}