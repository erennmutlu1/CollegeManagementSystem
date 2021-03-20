using CollegeManagementSystem.Models;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CollegeManagementSystem.Repositories
{
    public class CollegeContext : DbContext
    {
        public CollegeContext() : base("CollegeContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}