using Abp.EntityFramework;
using AbpDemo.IRepositories;
using AbpDemo.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AbpDemo.EntityFramework.Repositories
{
    public class BackendTaskRepository : ABPMultiMVCRepositoryBase<TaskModel>, IBackendTaskRepository
    {
        public BackendTaskRepository(IDbContextProvider<AbpDemoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public List<TaskModel> GetTaskByAssignedPersonId(long personId)
        {
            var query = GetAll();
            if (personId > 0)
            {
                query = query.Where(t => t.AssignedPersonId == personId);
            }
            return query.ToList();
        }
    }
}
