using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbpDemo.Tasks.Dto;
using AutoMapper;

namespace AbpDemo.Tasks
{
    public class TaskDtoMapping : IDtoMapping
    {
        public void CreateMapping(IMapperConfigurationExpression mapperConfig)
        {
            mapperConfig.CreateMap<GetTasksInput, TaskModel>();
            mapperConfig.CreateMap<UpdateTaskInput, TaskModel>();
            mapperConfig.CreateMap<TaskDto, UpdateTaskInput>();

            var taskDtoMapper = mapperConfig.CreateMap<TaskModel, TaskDto>();
            taskDtoMapper.ForMember(dto => dto.AssignedPersonName, map => map.MapFrom(m => m.AssignedPerson.FullName));
        }
    }
}
