namespace Abp.Dependency
{
    /// <summary>
    /// ����ע��ϵͳ��ʹ�õ����͡�
    /// </summary>
    public enum DependencyLifeStyle
    {
        /// <summary>
        /// ����ģʽ. �״ν���ʱ����һ������ͬһ��ʵ�����ں���������
        /// </summary>
        Singleton,

        /// <summary>
        /// ˲̬����Ϊÿ�ν�������һ������
        /// </summary>
        Transient
    }
}