using AbpDemo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace AbpDemo.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly AbpDemoDbContext _context;

        public InitialHostDbBuilder(AbpDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
