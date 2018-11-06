using Abp.Domain.Entities;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// Standard filters of ABP.
    /// </summary>
    public static class AbpDataFilters
    {
        /// <summary>
        /// "SoftDelete".
        /// ��ɾ��������.
        /// ����ȡ��deleted��������
        /// See <see cref="ISoftDelete"/> interface.
        /// </summary>
        public const string SoftDelete = "SoftDelete";

        /// <summary>
        /// �⻧������.
        /// �⻧����������ȡ�����ڵ�ǰ���⻧
        /// </summary>
        public const string MustHaveTenant = "MustHaveTenant";

        /// <summary>
        /// �⻧������.
        /// �⻧����������ȡ�����ڵ�ǰ���⻧
        /// </summary>
        public const string MayHaveTenant = "MayHaveTenant";

        /// <summary>
        /// ����.
        /// </summary>
        public static class Parameters
        {
            /// <summary>
            /// "tenantId".
            /// </summary>
            public const string TenantId = "tenantId";
        }
    }
}