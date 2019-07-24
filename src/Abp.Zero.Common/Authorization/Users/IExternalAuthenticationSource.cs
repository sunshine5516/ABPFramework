using System.Threading.Tasks;
using Abp.MultiTenancy;

namespace Abp.Authorization.Users
{
    /// <summary>
    /// �����ⲿ��ȨԴ��
    /// </summary>
    /// <typeparam name="TTenant">Tenant type</typeparam>
    /// <typeparam name="TUser">User type</typeparam>
    public interface IExternalAuthenticationSource<TTenant, TUser>
        where TTenant : AbpTenant<TUser>
        where TUser : AbpUserBase
    {
        /// <summary>
        /// ��ԴΨһ����
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ���ڳ���ͨ����Դ���û����������֤��
        /// </summary>
        /// <param name="userNameOrEmailAddress">�û������ʼ�</param>
        /// <param name="plainPassword">����</param>
        /// <param name="tenant">�û����⻧ (if user is a host user)</param>
        /// <returns>True, ��ʾ��ʹ����ͨ����Դ��֤</returns>
        Task<bool> TryAuthenticateAsync(string userNameOrEmailAddress, string plainPassword, TTenant tenant);

        /// <summary>
        /// �˷������ɴ�Դ���������֤���û������û��в����ڡ���ˣ�sourceӦ����User��������ԡ�
        /// </summary>
        /// <param name="userNameOrEmailAddress">�û������ʼ�</param>
        /// <param name="tenant">�û����⻧(if user is a host user)</param>
        /// <returns>�½����û�</returns>
        Task<TUser> CreateUserAsync(string userNameOrEmailAddress, TTenant tenant);

        /// <summary>
        /// �����û����ڴ�Դ�������û����������֤����ô˷������������ڸ���Դ��ĳЩ�û����ԡ�
        /// </summary>
        /// <param name="user">�û�</param>
        /// <param name="tenant">�û����⻧ (if user is a host user)</param>
        Task UpdateUserAsync(TUser user, TTenant tenant);
    }
}