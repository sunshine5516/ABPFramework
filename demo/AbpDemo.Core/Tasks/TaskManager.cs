using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;
using AbpDemo.Authorization.Users;

namespace AbpDemo.Tasks
{
    public class TaskManager : DomainService,ITaskManager
    {
        public void AssignTaskToPerson(TaskModel task, User user)
        {
            throw new NotImplementedException();
        }
    }
}
