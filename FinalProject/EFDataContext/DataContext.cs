using System.Configuration;
using System.Data.Entity;
using FinalProject.Models;

namespace FinalProject.EFDataContext
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {
             Database.Connection.ConnectionString =
                ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<CourseTaken> CoursesTaken { get; set; }
        public DbSet<Grades> Grades { get; set; }
    }
}
