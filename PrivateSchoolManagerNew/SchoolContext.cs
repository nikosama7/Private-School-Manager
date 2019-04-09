namespace PrivateSchoolManagerNew
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using PrivateSchoolManagerNew.Models;

    public class SchoolContext : DbContext
    {
        // Your context has been configured to use a 'SchoolContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PrivateSchoolManagerNew.SchoolContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SchoolContext' 
        // connection string in the application configuration file.
        public SchoolContext() : base("name=SchoolContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mark>().Property(x => x.OralMark).HasPrecision(5, 2).IsOptional();
            modelBuilder.Entity<Mark>().Property(x => x.TotalMark).HasPrecision(5, 2).IsOptional();
            
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}