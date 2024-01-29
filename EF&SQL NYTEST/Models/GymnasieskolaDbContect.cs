using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF_SQL_NYTEST.Models
{
    public class CourseGrade
    {
        public string Course { get; set; }
        public double Average_Grade { get; set; }
        public int Max_Grade { get; set; }
        public int Min_Grade { get; set; }
    }
    public partial class GymnasieskolaDbContect : DbContext
    {
        public GymnasieskolaDbContect()
        {
        }

        public GymnasieskolaDbContect(DbContextOptions<GymnasieskolaDbContect> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmployee> TblEmployees { get; set; } = null!;
        public virtual DbSet<TblGradesBiology> TblGradesBiologies { get; set; } = null!;
        public virtual DbSet<TblGradesEnglish> TblGradesEnglishes { get; set; } = null!;
        public virtual DbSet<TblGradesMathematic> TblGradesMathematics { get; set; } = null!;
        public virtual DbSet<TblStudent> TblStudents { get; set; } = null!;
        public DbSet<CourseGrade> vWSnittbetyg { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = TOBBE; Initial Catalog = Gymnasieskola; Integrated security=true; TrustServerCertificate =True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__tbl_Empl__78113481278DAE02");

                entity.ToTable("tbl_Employees");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Middle_Name");

                entity.Property(e => e.Position)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGradesBiology>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_Grades_Biology");

                entity.Property(e => e.Biology1)
                    .HasMaxLength(1)
                    .HasColumnName("Biology 1")
                    .IsFixedLength();

                entity.Property(e => e.Biology2)
                    .HasMaxLength(1)
                    .HasColumnName("Biology 2")
                    .IsFixedLength();

                entity.Property(e => e.Biology3)
                    .HasMaxLength(1)
                    .HasColumnName("Biology 3")
                    .IsFixedLength();

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("date")
                    .HasColumnName("Last_Updated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__tbl_Grade__Emplo__4316F928");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__tbl_Grade__Stude__4222D4EF");
            });

            modelBuilder.Entity<TblGradesEnglish>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_Grades_English");

                entity.Property(e => e.EmployeId).HasColumnName("Employe_ID");

                entity.Property(e => e.English1)
                    .HasMaxLength(1)
                    .HasColumnName("English 1")
                    .IsFixedLength();

                entity.Property(e => e.English2)
                    .HasMaxLength(1)
                    .HasColumnName("English 2")
                    .IsFixedLength();

                entity.Property(e => e.English3)
                    .HasMaxLength(1)
                    .HasColumnName("English 3")
                    .IsFixedLength();

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("date")
                    .HasColumnName("Last_Updated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.HasOne(d => d.Employe)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeId)
                    .HasConstraintName("FK__tbl_Grade__Emplo__3B75D760");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__tbl_Grade__Stude__3A81B327");
            });

            modelBuilder.Entity<TblGradesMathematic>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_Grades_Mathematics");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("date")
                    .HasColumnName("Last_Updated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mathematics1)
                    .HasMaxLength(1)
                    .HasColumnName("Mathematics 1")
                    .IsFixedLength();

                entity.Property(e => e.Mathematics2)
                    .HasMaxLength(1)
                    .HasColumnName("Mathematics 2")
                    .IsFixedLength();

                entity.Property(e => e.Mathematics3)
                    .HasMaxLength(1)
                    .HasColumnName("Mathematics 3")
                    .IsFixedLength();

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__tbl_Grade__Emplo__3F466844");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__tbl_Grade__Stude__3E52440B");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__tbl_Stud__A2F4E9AC90D75797");

                entity.ToTable("tbl_Student");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.Property(e => e.Class)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("Middle_Name");

                entity.Property(e => e.Personnummer)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
