using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using AbpDemo.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace AbpDemo.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<AbpDemo.EntityFramework.AbpDemoDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpDemo";
        }

        protected override void Seed(AbpDemo.EntityFramework.AbpDemoDbContext context)
        {
            context.DisableAllFilters();
            new DefaultTestDataForTask(context).Create();
            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
