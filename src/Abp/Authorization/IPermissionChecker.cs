using System.Threading.Tasks;

namespace Abp.Authorization
{
    /// <summary>
    /// �û���Ȩ�޼��ӿڡ�
    /// </summary>
    public interface IPermissionChecker
    {
        /// <summary>
        /// ��鵱ǰ�û��Ƿ�����Ȩ�ޡ�
        /// </summary>
        /// <param name="permissionName">Ȩ������</param>
        Task<bool> IsGrantedAsync(string permissionName);

        /// <summary>
        /// ��鵱ǰ�û��Ƿ�����Ȩ�ޡ�
        /// </summary>
        /// <param name="user">�û�</param>
        /// <param name="permissionName">Ȩ������</param>
        Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName);
    }
}