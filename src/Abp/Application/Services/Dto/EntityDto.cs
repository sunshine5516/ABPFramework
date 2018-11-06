using System;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// 实现IEntityDto接口
    /// </summary>
    [Serializable]
    public class EntityDto : EntityDto<int>, IEntityDto
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityDto()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">Id of the entity</param>
        public EntityDto(int id)
            : base(id)
        {
        }
    }
    /// <summary>
    /// 实现IEntityDto<TPrimaryKey>接口
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    [Serializable]
    public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        /// <summary>
        /// 实体ID.
        /// </summary>
        public TPrimaryKey Id { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityDto()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">Id of the entity</param>
        public EntityDto(TPrimaryKey id)
        {
            Id = id;
        }
    }
}