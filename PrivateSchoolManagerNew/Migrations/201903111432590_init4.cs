namespace PrivateSchoolManagerNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainers", "ID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "ID" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "ID");
            CreateIndex("dbo.Students", "ID");
            AddForeignKey("dbo.Students", "ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Trainers", "ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "ID", "dbo.Users");
            DropForeignKey("dbo.Students", "ID", "dbo.Users");
            DropIndex("dbo.Students", new[] { "ID" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "ID");
            CreateIndex("dbo.Users", "ID");
            AddForeignKey("dbo.Trainers", "ID", "dbo.Users", "ID");
        }
    }
}
