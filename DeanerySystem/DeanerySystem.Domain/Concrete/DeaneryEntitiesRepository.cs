using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Concrete {
	public class DeaneryEntitiesRepository : IDeaneryEntitiesRepository {
		private CustomDbContext context = new CustomDbContext();

		public IEnumerable<Cellule> Cellules => context.Cellules;

		public IEnumerable<ClassNumberTime> ClassNumberTimes => context.ClassNumberTimes;

		public IEnumerable<Department> Departments => context.Departments;

		public IEnumerable<Faculty> Faculties => context.Faculties;

		public IEnumerable<Group> Groups => context.Groups;

		public IEnumerable<Journal> Journals => context.Journals;

		public IEnumerable<JournalForMarking> JournalsForMarking => context.JournalsForMarking;

		public IEnumerable<Professor> Professors => context.Professors;

		public IEnumerable<ProgressRecord> ProgressRecords => context.ProgressRecords;

		public IEnumerable<Semester> Semesters => context.Semesters;

		public IEnumerable<SemesterEducationalPlan> SemesterEducationalPlans => context.SemesterEducationalPlans; 

		public IEnumerable<Stream> Streams => context.Streams;

		public IEnumerable<Student> Students => context.Students;

		public IEnumerable<Subject> Subjects => context.Subjects;

		public IEnumerable<TimeTable> TimeTables => context.TimeTables;

		public IEnumerable<University> Universities => context.Universities; 

		public IEnumerable<Writing> Writings => context.Writings;
	}
}
