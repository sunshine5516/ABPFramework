using System;
using System.Threading.Tasks;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// 这个接口不能被注入或直接使用。使用 <see cref="IUnitOfWorkManager"/> 实现.
    /// 定义了UOW同步和异步的complete方法。实现UOW完成时候的逻辑。
    /// </summary>
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        /// <summary>
        /// Completes this unit of work.
        /// 保存所有，提交事务
        /// </summary>
        void Complete();

        /// <summary>
        /// Completes this unit of work.
        /// 异步 保存所有，提交事务.
        /// </summary>
        Task CompleteAsync();
    }
}