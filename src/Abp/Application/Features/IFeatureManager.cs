using System.Collections.Generic;

namespace Abp.Application.Features
{
    /// <summary>
    /// Feature管理.
    /// </summary>
    public interface IFeatureManager
    {
        /// <summary>
        /// 通过指定的名称获取<see cref ="Feature"/>。
        /// </summary>
        /// <param name="name">唯一名称</param>
        Feature Get(string name);

        /// <summary>
        /// 通过指定名称获取<see cref ="Feature"/>，否则返回null。
        /// </summary>
        /// <param name="name">The name.</param>
        Feature GetOrNull(string name);

        /// <summary>
        /// 获取所有<see cref="Feature"/>s.
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Feature> GetAll();
    }
}