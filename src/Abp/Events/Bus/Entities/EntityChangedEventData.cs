using System;
using Abp.Domain.Entities;

namespace Abp.Events.Bus.Entities
{
    /// <summary>
    /// 用于在实体（<see cref ="IEntity"/>）更改（创建，更新或删除）时传递事件的数据。
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    [Serializable]
    public class EntityChangedEventData<TEntity> : EntityEventData<TEntity>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="entity">Changed entity in this event</param>
        public EntityChangedEventData(TEntity entity)
            : base(entity)
        {

        }
    }
}