namespace PrivateSchoolManagerNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 50),
                        SubmissionDate = c.DateTime(name: "Submission Date", nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        StartDate = c.DateTime(name: "Start Date", nullable: false, storeType: "date"),
                        EndDate = c.DateTime(name: "End Date", nullable: false, storeType: "date"),
                        Stream = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        DateofBirth = c.DateTime(name: "Date of Birth", storeType: "date"),
                        TuitionFees = c.Decimal(name: "Tuition Fees", storeType: "money"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Subject = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_ID, t.Course_ID })
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.Student_ID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        Trainer_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_ID, t.Course_ID })
                .ForeignKey("dbo.Trainers", t => t.Trainer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.Trainer_ID)
                .Index(t => t.Course_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Students", "ID", "dbo.Users");
            DropForeignKey("dbo.Trainers", "ID", "dbo.Users");
            DropForeignKey("dbo.TrainerCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.TrainerCourses", "Trainer_ID", "dbo.Trainers");
            DropForeignKey("dbo.StudentCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_ID", "dbo.Students");
            DropIndex("dbo.TrainerCourses", new[] { "Course_ID" });
            DropIndex("dbo.TrainerCourses", new[] { "Trainer_ID" });
            DropIndex("dbo.StudentCourses", new[] { "Course_ID" });
            DropIndex("dbo.StudentCourses", new[] { "Student_ID" });
            DropIndex("dbo.Trainers", new[] { "ID" });
            DropIndex("dbo.Students", new[] { "ID" });
            DropIndex("dbo.Assignments", new[] { "CourseID" });
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Trainers");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
