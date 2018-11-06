using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace Abp.Domain.Uow
{
    /// <summary>
    ///һ��UOW�������������ӿ��ж���ķ����������⣬���������Ժͷ�����������ӿڶ���ġ�
    ///����Completed��Disposed��Failed�¼�����Filter��enable��disable,�Լ�ͬ�����첽��SaveChanges������
    ///  ����ӿڲ��ܱ�ע���ֱ��ʹ�á�ʹ�� <see cref="IUnitOfWorkManager"/> ʵ��.
    /// </summary>
    public interface IActiveUnitOfWork
    {
        /// <summary>
        ///�����UOW�ɹ����ʱ������¼������á�
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        /// �����UOWδ�ɹ����ʱ������¼������á�
        /// </summary>
        event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        /// <summary>
        /// �����UOW���ͷ�ʱ������¼������á�
        /// </summary>
        event EventHandler Disposed;

        /// <summary>
        /// ��ȡ���������Ԫ�Ƿ��������Եġ�
        /// </summary>
        UnitOfWorkOptions Options { get; }

        /// <summary>
        /// ��ȡ�˹�����Ԫ�����ݹ��������á�
        /// </summary>
        IReadOnlyList<DataFilterConfiguration> Filters { get; }

        /// <summary>
        /// �Ƿ��ͷ�
        /// </summary>
        bool IsDisposed { get; }

            /// <summary>
            /// �������
            /// This method may be called to apply changes whenever needed.
            /// ��ע�⣬������������Ԫ�������Եģ���ô�������ع�������ĸ���Ҳ��ع���
            /// SaveChangesͨ������Ҫ��ʽ����, ��Ϊ���и��Ķ����ڹ�����Ԫ��ĩβ�Զ�����        
            /// </summary>
        void SaveChanges();

        /// <summary>
        /// �첽�������
        /// This method may be called to apply changes whenever needed.
        /// ��ע�⣬������������Ԫ�������Եģ���ô�������ع�������ĸ���Ҳ��ع���
        /// SaveChangesͨ������Ҫ��ʽ����, ��Ϊ���и��Ķ����ڹ�����Ԫ��ĩβ�Զ�����        
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        /// ����һ���������ݹ�������
        /// ����������ѱ����ã���ִ���κβ�����
        /// �����Ҫ����using�����ʹ�ô˷�����������ɸѡ����
        /// </summary>
        /// <param name="filterNames">���Ƽ���.</param>
        /// <returns>A <see cref="IDisposable"/> handle to take back the disable effect.</returns>
        IDisposable DisableFilter(params string[] filterNames);

        /// <summary>
        /// ����һ���������ݹ�������
        /// ����������ѱ����ã���ִ���κβ�����
        /// �����Ҫ����using�����ʹ�ô˷�����������ɸѡ����
        ///  </summary>
        /// <param name="filterNames">One or more filter names. <see cref="AbpDataFilters"/> for standard filters.</param>
        /// <returns>A <see cref="IDisposable"/> handle to take back the enable effect.</returns>
        IDisposable EnableFilter(params string[] filterNames);

        /// <summary>
        /// ���������Ƿ���á�
        /// </summary>
        /// <param name="filterName">Name of the filter. <see cref="AbpDataFilters"/> for standard filters.</param>
        bool IsFilterEnabled(string filterName);

        /// <summary>
        /// ���ã���д��������������ֵ��
        /// </summary>
        /// <param name="filterName">����������</param>
        /// <param name="parameterName">������</param>
        /// <param name="value">ֵ</param>
        IDisposable SetFilterParameter(string filterName, string parameterName, object value);

        /// <summary>
        /// ����/���Ĵ�UOW���⻧��ID��
        /// </summary>
        /// <param name="tenantId">tenant id.</param>
        /// <returns></returns>
        IDisposable SetTenantId(int? tenantId);

        /// <summary>
        /// ����/���Ĵ�UOW���⻧��ID��
        /// </summary>
        /// <param name="tenantId">tenant id</param>
        /// <param name="switchMustHaveTenantEnableDisable">
        /// True to enable/disable <see cref="IMustHaveTenant"/> based on given tenantId.
        /// Enables <see cref="IMustHaveTenant"/> filter if tenantId is not null.
        /// Disables <see cref="IMustHaveTenant"/> filter if tenantId is null.
        /// This value is true for <see cref="SetTenantId(int?)"/> method.
        /// </param>
        /// <returns>A disposable object to restore old TenantId value when you dispose it</returns>
        IDisposable SetTenantId(int? tenantId, bool switchMustHaveTenantEnableDisable);

        /// <summary>
        /// ��ȡ.TenantId
        /// </summary>
        /// <returns></returns>
        int? GetTenantId();
    }
}