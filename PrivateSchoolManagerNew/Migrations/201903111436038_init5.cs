namespace PrivateSchoolManagerNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourses", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.TrainerCourses", "Trainer_ID", "dbo.Trainers");
            DropIndex("dbo.Students", new[] { "ID" });
            DropIndex("dbo.Trainers", new[] { "ID" });
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Trainers");
            AlterColumn("dbo.Students", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Trainers", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Students", "ID");
            AddPrimaryKey("dbo.Trainers", "ID");
            CreateIndex("dbo.Students", "ID");
            CreateIndex("dbo.Trainers", "ID");
            AddForeignKey("dbo.StudentCourses", "Student_ID", "dbo.Students", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TrainerCourses", "Trainer_ID", "dbo.Trainers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerCourses", "Trainer_ID", "dbo.Trainers");
            DropForeignKey("dbo.StudentCourses", "Student_ID", "dbo.Students");
            DropIndex("dbo.Trainers", new[] { "ID" });
            DropIndex("dbo.Students", new[] { "ID" });
            DropPrimaryKey("dbo.Trainers");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Trainers", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Students", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Trainers", "ID");
            AddPrimaryKey("dbo.Students", "ID");
            CreateIndex("dbo.Trainers", "ID");
            CreateIndex("dbo.Students", "ID");
            AddForeignKey("dbo.TrainerCourses", "Trainer_ID", "dbo.Trainers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "Student_ID", "dbo.Students", "ID", cascadeDelete: true);
        }
    }
}
