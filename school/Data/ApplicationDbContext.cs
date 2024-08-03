using Microsoft.EntityFrameworkCore;
using school.Models;

namespace school.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ClassModel> Classes {  get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<StudentModel> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherModel>()
                .HasMany(teacher => teacher.Classes)
                .WithOne(c => c.Teahcher)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentModel>()
                .HasMany(student => student.Classes)
                .WithMany(c => c.Students)
                .UsingEntity(e => e.ToTable("StudentClasses"));
        }
    }
}
