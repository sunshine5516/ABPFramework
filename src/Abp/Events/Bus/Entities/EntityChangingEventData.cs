using System;
using Abp.Domain.Entities;

namespace Abp.Events.Bus.Entities
{
    /// <summary>
    /// 用于在实体（<see cref ="IEntity"/>）被更改（创建，更新或删除）时传递事件的数据。    
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