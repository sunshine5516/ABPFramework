using System;

namespace Abp
{
    /// <summary>
    /// 用于生成ID。
    /// </summary>
    public interface IGuidGenerator
    {
        /// <summary>
        /// Creates a GUID.
        /// </summary>
        Guid Create();
    }
}
