using Abp.Dependency;

namespace Abp.Application.Features
{
    /// <summary>
    /// 抽象基类，用于向IFeatureDefinitionContext对象（FeatureManager）中添加Feature.
    /// </summary>
    public abstract class FeatureProvider : ITransientDependency
    {
        /// <summary>
        /// Used to set <see cref="Feature"/>s.
        /// </summary>
        /// <param name="context">Feature definition context</param>
        public abstract void SetFeatures(IFeatureDefinitionContext context);
    }
}