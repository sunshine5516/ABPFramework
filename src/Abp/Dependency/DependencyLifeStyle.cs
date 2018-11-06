namespace Abp.Dependency
{
    /// <summary>
    /// 依赖注入系统中使用的类型。
    /// </summary>
    public enum DependencyLifeStyle
    {
        /// <summary>
        /// 单例模式. 首次解析时创建一个对象，同一个实例用于后续解析。
        /// </summary>
        Singleton,

        /// <summary>
        /// 瞬态对象，为每次解析创建一个对象。
        /// </summary>
        Transient
    }
}