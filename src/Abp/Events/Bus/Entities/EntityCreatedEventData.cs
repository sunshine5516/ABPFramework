using System;

namespace Abp.Events.Bus.Entities
{
    /// <summary>
    /// �����¼��������ڴ���ʵ�������֪ͨ��
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    [Serializable]
    public class EntityCreatedEventData<TEntity> : EntityChangedEventData<TEntity>
    {
        /// <summary>
        /// ���캯��.
        /// </summary>
        /// <param name="entity">The entity which is created</param>
        public EntityCreatedEventData(TEntity entity)
            : base(entity)
        {

        }
    }
}