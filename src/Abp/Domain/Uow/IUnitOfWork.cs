using System;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// 该接口由ABP内部使用。
    /// 定义了外层的IUnitOfWork的引用和UOW的begin方法
    /// Use <see cref="IUnitOfWorkManager.Begin()"/> to start a new unit of work.
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        /// <summary>
        /// id
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 
        /// </summary>
        IUnitOfWork Outer { get; set; }
        
        /// <summary>
        /// Begins the unit of work with given options.
        /// </summary>
        /// <param name="options">Unit of work options</param>
        void Begin(UnitOfWorkOptions options);
    }
}