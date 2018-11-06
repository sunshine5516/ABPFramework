using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// ��װ��UnitOfWork��������
    /// </summary>
    public class UnitOfWorkOptions
    {
        /// <summary>
        /// ������ѡ��
        /// </summary>
        public TransactionScopeOption? Scope { get; set; }

        /// <summary>
        /// �Ƿ��������Ե�
        /// ���δ�ṩ����ʹ��Ĭ��ֵ
        /// </summary>
        public bool? IsTransactional { get; set; }

        /// <summary>
        /// ��ʱʱ��(����)
        /// ���δ�ṩ����ʹ��Ĭ��ֵ
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// ������UOW�������Եģ����ѡ��ָ��������ĸ��뼶��
        /// ���δ�ṩ����ʹ��Ĭ��ֵ
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// This option should be set to <see cref="TransactionScopeAsyncFlowOption.Enabled"/>
        /// if unit of work is used in an async scope.
        /// </summary>
        public TransactionScopeAsyncFlowOption? AsyncFlowOption { get; set; }

        /// <summary>
        /// ��������/����ĳЩ��������
        /// </summary>
        public List<DataFilterConfiguration> FilterOverrides { get; }

        /// <summary>
        /// ���캯��
        /// </summary>
        public UnitOfWorkOptions()
        {
            FilterOverrides = new List<DataFilterConfiguration>();
        }

        internal void FillDefaultsForNonProvidedOptions(IUnitOfWorkDefaultOptions defaultOptions)
        {
            //TODO: Do not change options object..?

            if (!IsTransactional.HasValue)
            {
                IsTransactional = defaultOptions.IsTransactional;
            }

            if (!Scope.HasValue)
            {
                Scope = defaultOptions.Scope;
            }

            if (!Timeout.HasValue && defaultOptions.Timeout.HasValue)
            {
                Timeout = defaultOptions.Timeout.Value;
            }

            if (!IsolationLevel.HasValue && defaultOptions.IsolationLevel.HasValue)
            {
                IsolationLevel = defaultOptions.IsolationLevel.Value;
            }
        }

        internal void FillOuterUowFiltersForNonProvidedOptions(List<DataFilterConfiguration> filterOverrides)
        {
            foreach (var filterOverride in filterOverrides)
            {
                if (FilterOverrides.Any(fo => fo.FilterName == filterOverride.FilterName))
                {
                    continue;
                }

                FilterOverrides.Add(filterOverride);
            }
        }
    }
}