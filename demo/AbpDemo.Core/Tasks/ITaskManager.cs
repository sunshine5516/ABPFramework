using Abp.Domain.Services;
using AbpDemo.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbpDemo.Tasks
{
    public interface ITaskManager:IDomainService
    {
        void AssignTaskToPerson(TaskModel task,User user);
    }
}
