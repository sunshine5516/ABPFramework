using Abp.Domain.Repositories;
using AbpDemo.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbpDemo.IRepositories
{
    public interface IBackendTaskRepository:IRepository<TaskModel>
    {
        /// <summary>
        /// 获取某个用户分配了哪些任务
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        List<TaskModel> GetTaskByAssignedPersonId(long personId);
    }
}
