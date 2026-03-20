using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DepartmentDatabaseImplement.Models;

namespace DepartmentDatabaseImplement
{
    public class DepartmentDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=department_db;Username=department_user;Password=123456;SSL Mode=Prefer;Timeout=10");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentGroup>()
                .HasOne(x => x.Curator)
                .WithMany()
                .HasForeignKey(x => x.CuratorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AcademicPlanRecord>()
                .HasOne(x => x.AcademicPlanRecordParent)
                .WithMany(x => x.AcademicPlanRecords)
                .HasForeignKey(x => x.AcademicPlanRecordParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentOrderBlockStudent>()
                .HasOne(x => x.StudentGroupFrom)
                .WithMany(x => x.StudentFromOrderBlockStudents)
                .HasForeignKey(x => x.StudentGroupFromId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentOrderBlockStudent>()
                .HasOne(x => x.StudentGroupTo)
                .WithMany(x => x.StudentToOrderBlockStudents)
                .HasForeignKey(x => x.StudentGroupToId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentOrderBlockStudent>()
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentOrderBlockStudents)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentOrderBlockStudent>()
                .HasOne(x => x.StudentOrderBlock)
                .WithMany(x => x.StudentOrderBlockStudents)
                .HasForeignKey(x => x.StudentOrderBlockId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public virtual DbSet <AcademicPlan> AcademicPlans { get; set; }
        public virtual DbSet <AcademicPlanRecord> AcademicPlanRecords { get; set; }
        public virtual DbSet <Classroom> Classrooms { get; set; }
        public virtual DbSet <Discipline> Disciplines { get; set; }
        public virtual DbSet <DisciplineBlock> DisciplineBlocks { get; set; }
        public virtual DbSet <DisciplineStudentRecord> DisciplineStudentRecords { get; set; }
        public virtual DbSet <EducationDirection> EducationDirections { get; set; }
        public virtual DbSet <Lecturer> Lecturers { get; set; }
        public virtual DbSet <LecturerDepartmentPost> LecturerDepartmentPosts { get; set; }
        public virtual DbSet <LecturerStudyPost> LecturerStudyPosts { get; set; }
        public virtual DbSet <Student> Students { get; set; }
        public virtual DbSet <StudentGroup> StudentGroups { get; set; }
        public virtual DbSet <StudentOrder> StudentOrders { get; set; }
        public virtual DbSet <StudentOrderBlock> StudentOrderBlocks { get; set; }
        public virtual DbSet <StudentOrderBlockStudent> StudentOrderBlockStudents { get; set; }
    }
}
