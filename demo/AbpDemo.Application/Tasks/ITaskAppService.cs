using Abp.Application.Services;
using AbpDemo.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpDemo.Application.Tasks
{
    public interface ITaskAppService
    {
        GetTasksOutput GetTasks(GetTasksInput input);
        void UpdateTask(UpdateTaskInput input);
        int CreateTask(CreateTaskInput input);

        Task<TaskDto> GetTaskByIdAsync(int taskId);
        TaskDto GetTaskById(int taskId);
        void DeleteTask(int taskId);
        IList<TaskDto> GetAllTasks();

    }
}
