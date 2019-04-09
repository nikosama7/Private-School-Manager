namespace PrivateSchoolManagerNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marks", "Submitted Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marks", "Submitted Date");
        }
    }
}
