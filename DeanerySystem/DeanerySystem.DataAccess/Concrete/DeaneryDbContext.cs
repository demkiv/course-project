using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DeanerySystem.DataAccess.Entities.Identity;
using System;
using DeanerySystem.DataAccess.Configurations;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DeanerySystem.DataAccess.Concrete
{
    public class DeaneryDbContext : IdentityDbContext<DeaneryUser, DeaneryRole, Guid, DeaneryUserClaim, DeaneryUserRole, DeaneryUserLogin, DeaneryRoleClaim, DeaneryUserToken>
    {
        public DeaneryDbContext(DbContextOptions<DeaneryDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cellule> Cellules { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassNumberTime> ClassNumberTimes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationalPlan> EducationalPlans { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FailureTicket> FailureTickets { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ProgressRecord> ProgressRecords { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddConfiguration(new CelluleConfiguration());
            modelBuilder.AddConfiguration(new ClassConfiguration());
            modelBuilder.AddConfiguration(new ClassNumberTimeConfiguration());
            modelBuilder.AddConfiguration(new DepartmentConfiguration());
            modelBuilder.AddConfiguration(new EducationalPlanConfiguration());
            modelBuilder.AddConfiguration(new FacultyConfiguration());
            modelBuilder.AddConfiguration(new FailureTicketConfiguration());
            modelBuilder.AddConfiguration(new GroupConfiguration());
            modelBuilder.AddConfiguration(new JournalConfiguration());
            modelBuilder.AddConfiguration(new ProfessorConfiguration());
            modelBuilder.AddConfiguration(new ProgressRecordConfiguration());
            modelBuilder.AddConfiguration(new SemesterConfiguration());
            modelBuilder.AddConfiguration(new StreamConfiguration());
            modelBuilder.AddConfiguration(new StudentConfiguration());
            modelBuilder.AddConfiguration(new StudentSemesterConfiguration());
            modelBuilder.AddConfiguration(new SubjectConfiguration());
            modelBuilder.AddConfiguration(new TimeTableConfiguration());
            modelBuilder.AddConfiguration(new UniversityConfiguration());

            modelBuilder.Entity<DeaneryUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<DeaneryRole>().ToTable("Roles", "dbo");
            modelBuilder.Entity<DeaneryUserRole>().ToTable("UserRoles", "dbo");
            modelBuilder.Entity<DeaneryUserClaim>().ToTable("UserClaims", "dbo");
            modelBuilder.Entity<DeaneryUserToken>().ToTable("UserTokens", "dbo");
            modelBuilder.Entity<DeaneryRoleClaim>().ToTable("RoleClaims", "dbo");
        }
    }
}
