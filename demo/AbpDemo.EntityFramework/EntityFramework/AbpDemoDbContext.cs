using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using AbpDemo.Authorization.Roles;
using AbpDemo.Authorization.Users;
using AbpDemo.MultiTenancy;
using AbpDemo.Tasks;

namespace AbpDemo.EntityFramework
{
    public class AbpDemoDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public IDbSet<TaskModel> Tasks { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public AbpDemoDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ABPMultiMVCDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AbpDemoDbContext since ABP automatically handles it.
         */
        public AbpDemoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public AbpDemoDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public AbpDemoDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
