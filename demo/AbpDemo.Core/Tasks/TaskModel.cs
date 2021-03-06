﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using AbpDemo.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpDemo.Tasks
{
    public partial class TaskModel : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024;//64kb
        public long? AssignedPersonId { get; set; }
        [ForeignKey("AssignedPersonId")]
        public User AssignedPerson { get; set; }

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; }
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        public TaskState State { get; set; }

        public DateTime CreationTime { get; set; }
        public TaskModel()
        {
            CreationTime = Clock.Now;
            State = TaskState.Open; ;
        }
        public TaskModel(string title, string description = null) : this()
        {
            Title = title;
            Description = description;
        }
    }
    public enum TaskState : byte
    {
        Open = 0,
        Completed = 1
    }
}
