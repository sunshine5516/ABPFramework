using Abp.Application.Features;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Abp.Authorization
{
    /// <summary>
    /// �ڷ��� <see cref="AuthorizationProvider.SetPermissions"/> ʹ��.
    /// </summary>
    public interface IPermissionDefinitionContext
    {
        /// <summary>
        /// ��������´���һ���µ�Ȩ�ޡ�
        /// </summary>
        /// <param name="name">Ȩ��Ψһ����</param>
        /// <param name="displayName">��ʾ����</param>
        /// <param name="description">����</param>
        /// <param name="multiTenancySides">ʹ�÷�Χ</param>
        /// <param name="featureDependency">Depended feature(s) of this permission</param>
        /// <returns></returns>
        Permission CreatePermission(
            string name, 
            ILocalizableString displayName = null, 
            ILocalizableString description = null, 
            MultiTenancySides multiTenancySides = MultiTenancySides.Host | MultiTenancySides.Tenant,
            IFeatureDependency featureDependency = null
            );

        /// <summary>
        /// ��ȡ�������Ƶ�Ȩ�ޣ�����Ҳ������򷵻�null��
        /// </summary>
        /// <param name="name">Ψһ����</param>
        /// <returns>Permission object or null</returns>
        Permission GetPermissionOrNull(string name);
    }
}