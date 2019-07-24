using System;

namespace Abp.Events.Bus.Entities
{
    /// <summary>
    /// �����¼������ڴ���ʵ��֮ǰ֪ͨ��
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    [Serializable]
    public class EntityCreatingEventData<TEntity> : EntityChangingEventData<TEntity>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="entity">The entity which is being created</param>
        public EntityCreatingEventData(TEntity entity)
            : base(entity)
        {

        }
    }
}