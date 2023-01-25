using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LABB34.Models;

namespace LABB34.Data
{
    public partial class Labb4Context : DbContext
    {
        public Labb4Context()
        {
        }

        public Labb4Context(DbContextOptions<Labb4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<StaffContactList> StaffContactLists { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentContactList> StudentContactLists { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=USER-PC; Initial Catalog=Labb2ER_modelleringOchSQL;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FkStaffId).HasColumnName("FK_StaffId");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.Property(e => e.Grades).HasMaxLength(2);

                entity.Property(e => e.Subject).HasMaxLength(40);

                entity.HasOne(d => d.FkStaff)
                    .WithMany()
                    .HasForeignKey(d => d.FkStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Staff");

                entity.HasOne(d => d.FkStudent)
                    .WithMany()
                    .HasForeignKey(d => d.FkStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Student");
            });

            modelBuilder.Entity<StaffContactList>(entity =>
            {
                entity.HasKey(e => e.StaffContactId);

                entity.ToTable("StaffContactList");

                entity.Property(e => e.StaffContactId).ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FkStaffId).HasColumnName("FK_StaffId");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SocialSecufrityNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Startdate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkStaff)
                    .WithMany(p => p.StaffContactLists)
                    .HasForeignKey(d => d.FkStaffId)
                    .HasConstraintName("FK_StaffContactList_Staff");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Socialsecuritynumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentContactList>(entity =>
            {
                entity.HasKey(e => e.StudentContactId);

                entity.ToTable("StudentContactList");

                entity.Property(e => e.StudentContactId).ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkStudent)
                    .WithMany(p => p.StudentContactLists)
                    .HasForeignKey(d => d.FkStudentId)
                    .HasConstraintName("FK_StudentContactList_Student");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PaycheckEachMonth)
                    .HasMaxLength(50)
                    .HasColumnName("Paycheck each month");

                entity.Property(e => e.Position).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
