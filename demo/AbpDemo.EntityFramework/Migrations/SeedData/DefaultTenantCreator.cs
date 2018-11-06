using System.Linq;
using AbpDemo.EntityFramework;
using AbpDemo.MultiTenancy;

namespace AbpDemo.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly AbpDemoDbContext _context;

        public DefaultTenantCreator(AbpDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
