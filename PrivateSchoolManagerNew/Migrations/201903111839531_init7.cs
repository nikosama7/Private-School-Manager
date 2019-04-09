namespace PrivateSchoolManagerNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        AssignmentID = c.Int(nullable: false),
                        OralMark = c.Decimal(name: "Oral Mark", precision: 5, scale: 2),
                        TotalMark = c.Decimal(name: "Total Mark", precision: 5, scale: 2),
                        Submitted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.AssignmentID })
                .ForeignKey("dbo.Assignments", t => t.AssignmentID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.AssignmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Marks", "AssignmentID", "dbo.Assignments");
            DropIndex("dbo.Marks", new[] { "AssignmentID" });
            DropIndex("dbo.Marks", new[] { "StudentID" });
            DropTable("dbo.Marks");
        }
    }
}
