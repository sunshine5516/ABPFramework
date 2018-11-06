using System;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// ʵ��IEntityDto�ӿ�
    /// </summary>
    [Serializable]
    public class EntityDto : EntityDto<int>, IEntityDto
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public EntityDto()
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="id">Id of the entity</param>
        public EntityDto(int id)
            : base(id)
        {
        }
    }
    /// <summary>
    /// ʵ��IEntityDto<TPrimaryKey>�ӿ�
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    [Serializable]
    public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        /// <summary>
        /// ʵ��ID.
        /// </summary>
        public TPrimaryKey Id { get; set; }

        /// <summary>
        /// ���캯��
        /// </summary>
        public EntityDto()
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="id">Id of the entity</param>
        public EntityDto(TPrimaryKey id)
        {
            Id = id;
        }
    }
}