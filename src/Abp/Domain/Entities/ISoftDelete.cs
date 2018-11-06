namespace Abp.Domain.Entities
{
    /// <summary>
    /// 软删除的标志IsDeleted
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Used to mark an Entity as 'Deleted'. 
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
