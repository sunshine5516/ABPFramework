namespace Abp.Runtime.Validation
{
    /// <summary>
    /// This interface is used to normalize inputs before method execution.
    /// </summary>
    public interface IShouldNormalize
    {
        /// <summary>
        /// 该方法可以在Validation 后，使用前，对DTO做最后的处理。
        /// </summary>
        void Normalize();
    }
}