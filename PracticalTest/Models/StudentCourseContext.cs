using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.Models
{
    public class StudentCourseContext : DbContext
    {
        public StudentCourseContext(DbContextOptions<StudentCourseContext> options) : base(options)
        {
           
        }

        public DbSet<StudentModel> Student { get; set; }
        public DbSet<CourseModel> Course { get; set; }
        public DbSet<Student_CourseModel> Student_Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<StudentModel>().ToTable("Student");
            //modelBuilder.Entity<CourseModel>().ToTable("Course");
            //modelBuilder.Entity<Student_CourseModel>().ToTable("Student_Course");
            modelBuilder.Entity<StudentModel>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId)
                .HasColumnName("StudentId")
                .UseSqlServerIdentityColumn();

                entity.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .IsRequired();

                entity.Property(e => e.Surname)
                .HasColumnName("Surname")
                .IsRequired();

                entity.Property(e => e.EmailAddress)
                .HasColumnName("EmailAddress");

                entity.Property(e => e.IDNumber)
                .HasColumnName("IDNumber");
            });
            modelBuilder.Entity<CourseModel>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.CourseId)
                .HasColumnName("CourseId")
                .UseSqlServerIdentityColumn();

                entity.Property(e => e.CourseName)
                .HasColumnName("CourseName")
                .IsRequired();

                entity.Property(e => e.StartDate)
                .HasColumnName("StartDate");

                entity.Property(e => e.EndDate)
                .HasColumnName("EndDate");
            });
            modelBuilder.Entity<Student_CourseModel>(entity =>
            {
                entity.HasKey(e => e.Student_CourseId);

                entity.Property(e => e.Student_CourseId)
                .HasColumnName("Student_CourseId")
                .UseSqlServerIdentityColumn();

                entity.Property(e => e.StudentId).HasColumnName("StudentId");

                entity.HasOne(e => e.Student)
                .WithMany(d => d.Student_Courses)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Student");

                entity.Property(e => e.CourseId).HasColumnName("CourseId");

                entity.HasOne(e => e.Course)
                .WithMany(d => d.Student_Courses)
                .HasForeignKey(f => f.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Course_Student");
            });
        }
    }
}
