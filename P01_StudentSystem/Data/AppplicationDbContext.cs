using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;

namespace P01_StudentSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9Q6DBR4\\SQL22;Database=StudentSystem;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode(true);
            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode(true);
            modelBuilder.Entity<Resource>()
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode(true);
            modelBuilder.Entity<Resource>()
                .Property(r => r.Url)
                .IsUnicode(false);
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
