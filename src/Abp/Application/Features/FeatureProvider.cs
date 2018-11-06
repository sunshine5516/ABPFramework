using Abp.Dependency;

namespace Abp.Application.Features
{
    /// <summary>
    /// ������࣬������IFeatureDefinitionContext����FeatureManager�������Feature.
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