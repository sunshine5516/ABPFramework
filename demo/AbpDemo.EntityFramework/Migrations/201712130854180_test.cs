namespace AbpDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tasks", newName: "TaskModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TaskModels", newName: "Tasks");
        }
    }
}
