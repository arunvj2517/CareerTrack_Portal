using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

namespace MyMvcApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Interview> Interviews { get; set; }

        // 👇 ADD THIS:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = "S001",
                    Name = "John Doe",
                    Email = "john@example.com",
                    Major = "Computer Science",
                    PasswordHash = "hashed_password",
                    GraduationYear = 2025
                },
                new Student
                {
                    StudentId = "S002",
                    Name = "Jane Smith",
                    Email = "jane@example.com",
                    Major = "Data Analytics",
                    PasswordHash = "hashed_password",
                    GraduationYear = 2024
                }
            );
        }
    }
}
