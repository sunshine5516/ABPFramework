using System.Threading.Tasks;

namespace Abp.Events.Bus.Entities
{
    /// <summary>
    /// ���ڴ���ʵ������¼�.
    /// </summary>
    public interface IEntityChangeEventHelper
    {
        void TriggerEvents(EntityChangeReport changeReport);

        Task TriggerEventsAsync(EntityChangeReport changeReport);

        void TriggerEntityCreatingEvent(object entity);

        void TriggerEntityCreatedEventOnUowCompleted(object entity);

        void TriggerEntityUpdatingEvent(object entity);
        
        void TriggerEntityUpdatedEventOnUowCompleted(object entity);

        void TriggerEntityDeletingEvent(object entity);
        
        void TriggerEntityDeletedEventOnUowCompleted(object entity);
    }
}