using System;
using Abp.Domain.Entities;

namespace Abp.Events.Bus.Entities
{
    /// <summary>
    /// ������ʵ�壨<see cref ="IEntity"/>�������ģ����������»�ɾ����ʱ�����¼������ݡ�    
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    [Serializable]
    public class EntityChangingEventData<TEntity> : EntityEventData<TEntity>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="entity">Changing entity in this event</param>
        public EntityChangingEventData(TEntity entity)
            : base(entity)
        {

        }
    }
}