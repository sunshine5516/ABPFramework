using System;
using System.Threading.Tasks;

namespace Abp.Domain.Uow
{
    /// <summary>
    /// ����ӿڲ��ܱ�ע���ֱ��ʹ�á�ʹ�� <see cref="IUnitOfWorkManager"/> ʵ��.
    /// ������UOWͬ�����첽��complete������ʵ��UOW���ʱ����߼���
    /// </summary>
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        /// <summary>
        /// Completes this unit of work.
        /// �������У��ύ����
        /// </summary>
        void Complete();

        /// <summary>
        /// Completes this unit of work.
        /// �첽 �������У��ύ����.
        /// </summary>
        Task CompleteAsync();
    }
}