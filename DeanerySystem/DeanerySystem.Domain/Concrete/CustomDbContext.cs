using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Configurations;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Concrete
{
    class CustomDbContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalForMarking> JournalsForMarking { get; set; }
        public DbSet<Cellule> Cellules { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<ClassNumberTime> ClassNumberTimes { get; set; }
        public DbSet<BookOfSuccess> BooksOfSuccesses { get; set; }
        public DbSet<Writing> Writings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new FacultyConfiguration());
            modelBuilder.Configurations.Add(new StreamConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProfessorConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new SemesterConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new JournalConfiguration());
            modelBuilder.Configurations.Add(new CelluleConfiguration());
            modelBuilder.Configurations.Add(new TimeTableConfiguration());
            modelBuilder.Configurations.Add(new ClassNumberTimeConfiguration());
            modelBuilder.Configurations.Add(new BookOfSuccessConfiguration());
            modelBuilder.Configurations.Add(new WritingConfiguration());
        }
    }
}
