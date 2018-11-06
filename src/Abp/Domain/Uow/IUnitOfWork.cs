using System;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// �ýӿ���ABP�ڲ�ʹ�á�
    /// ����������IUnitOfWork�����ú�UOW��begin����
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