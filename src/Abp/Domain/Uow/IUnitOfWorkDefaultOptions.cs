using System;
using System.Collections.Generic;
using System.Transactions;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// Ĭ��UOWѡ��ӿ�
    /// </summary>
    public interface IUnitOfWorkDefaultOptions
    {
        /// <summary>
        /// ������ѡ��
        /// </summary>
        TransactionScopeOption Scope { get; set; }

        /// <summary>
        /// �Ƿ��������Ե�
        /// ���δ�ṩ����ʹ��Ĭ��ֵ
        /// </summary>
        bool IsTransactional { get; set; }

        /// <summary>
        /// A boolean value indicates that System.Transactions.TransactionScope is available for current application.
        /// Default: true.
        /// </summary>
        bool IsTransactionScopeAvailable { get; set; }

        /// <summary>
        /// ��ʱʱ��
        /// </summary>
        TimeSpan? Timeout { get; set; }

        /// <summary>
        /// ������UOW�������Եģ����ѡ��ָ��������ĸ��뼶��
        /// Ĭ��true
        /// </summary>
        IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        IReadOnlyList<DataFilterConfiguration> Filters { get; }

        /// <summary>
        /// A list of selectors to determine conventional Unit Of Work classes.
        /// </summary>
        List<Func<Type, bool>> ConventionalUowSelectors { get; }

        /// <summary>
        /// ע�������
        /// </summary>
        /// <param name="filterName">����������.</param>
        /// <param name="isEnabledByDefault">�Ƿ�Ĭ�Ͽ���.</param>
        void RegisterFilter(string filterName, bool isEnabledByDefault);

        /// <summary>
        /// ��д����������
        /// </summary>
        /// <param name="filterName">����������.</param>
        /// <param name="isEnabledByDefault">�Ƿ�Ĭ�Ͽ���.</param>
        void OverrideFilter(string filterName, bool isEnabledByDefault);
    }
}