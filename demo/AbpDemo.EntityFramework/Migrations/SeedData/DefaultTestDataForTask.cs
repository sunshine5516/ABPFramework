using AbpDemo.EntityFramework;
using AbpDemo.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbpDemo.Migrations.SeedData
{
    public class DefaultTestDataForTask
    {
        private readonly AbpDemoDbContext _context;

        private static readonly List<TaskModel> _tasks;

        public DefaultTestDataForTask(AbpDemoDbContext context)
        {
            _context = context;
        }

        static DefaultTestDataForTask()
        {
            _tasks = new List<TaskModel>()
            {
                new TaskModel("Learning ABP deom", "Learning how to use abp framework to build a MPA application."),
                new TaskModel("Make Lunch", "Cook 2 dishs")
            };
        }

        public void Create()
        {
            foreach (var task in _tasks)
            {
                if (_context.Tasks.FirstOrDefault(t => t.Title == task.Title) == null)
                {
                    _context.Tasks.Add(task);
                }
                _context.SaveChanges();
            }
        }

    }
}
