using Abp.Configuration;
using Castle.DynamicProxy;

namespace Abp.Dependency
{
    /// <summary>
    /// �������Դ�ͳ��ʽע����ʱ��������/ѡ�
    /// </summary>
    public class ConventionalRegistrationConfig : DictionaryBasedConfig
    {
        /// <summary>
        /// �Ƿ�ע�����е�<see cref ="IInterceptor"/>ʵ�֡�
        /// Ĭ��: true. 
        /// </summary>
        public bool InstallInstallers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConventionalRegistrationConfig()
        {
            InstallInstallers = true;
        }
    }
}