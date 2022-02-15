using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AdvisoryTeacher> AdvisoryTeachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(ConfigureBook);
            modelBuilder.Entity<StudentCourse>(ConfigureStudentCourse);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureBook(EntityTypeBuilder<Book> modelBuilder)
        {
            modelBuilder.HasKey(mc => new { mc.StudentId, mc.Id });
        }

        private void ConfigureStudentCourse(EntityTypeBuilder<StudentCourse> modelBuilder)
        {
            modelBuilder.HasKey(mc => new { mc.StudentId, mc.CourseId });
            modelBuilder.HasOne(mc => mc.Student).WithMany(g => g.StudentCourses).HasForeignKey(mg => mg.StudentId);
            modelBuilder.HasOne(mc => mc.Course).WithMany(g => g.StudentCourses).HasForeignKey(mg => mg.CourseId);
        }

        public override int SaveChanges() => base.SaveChanges();
    }
}
