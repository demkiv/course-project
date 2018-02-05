using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Configurations;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeanerySystem.Domain.Concrete
{
	public class DeaneryDbContext : IdentityDbContext<DeaneryUser, DeaneryRole, Guid, DeaneryUserLogin, DeaneryUserRole, DeaneryUserClaim> {
		public DbSet<Cellule> Cellules { get; set; }
		public DbSet<Class> Classes { get; set; }
		public DbSet<ClassNumberTime> ClassNumberTimes { get; set; }
		//public DbSet<DeaneryUser> DeaneryUsers { get; set; }
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Configurations.Add(new CelluleConfiguration());
			modelBuilder.Configurations.Add(new ClassConfiguration());
			modelBuilder.Configurations.Add(new ClassNumberTimeConfiguration());
			//modelBuilder.Configurations.Add(new DeanaryUserConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
			modelBuilder.Configurations.Add(new EducationalPlanConfiguration());
			modelBuilder.Configurations.Add(new FacultyConfiguration());
			modelBuilder.Configurations.Add(new FailureTicketConfiguration());
			modelBuilder.Configurations.Add(new GroupConfiguration());
			modelBuilder.Configurations.Add(new JournalConfiguration());
            modelBuilder.Configurations.Add(new ProfessorConfiguration());
            modelBuilder.Configurations.Add(new ProgressRecordConfiguration());
            modelBuilder.Configurations.Add(new SemesterConfiguration());
            modelBuilder.Configurations.Add(new StreamConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new TimeTableConfiguration());
			modelBuilder.Configurations.Add(new UniversityConfiguration());

            modelBuilder.Entity<DeaneryUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<DeaneryRole>().ToTable("Roles", "dbo");
            modelBuilder.Entity<DeaneryUserRole>().ToTable("UserRoles", "dbo");
            modelBuilder.Entity<DeaneryUserClaim>().ToTable("UserClaims", "dbo");
            modelBuilder.Entity<DeaneryUserLogin>().ToTable("UserLogins", "dbo");
        }

		public static DeaneryDbContext Create() {
			return new DeaneryDbContext();
		}
	}
}
