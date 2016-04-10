using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Concrete {
	public class DeaneryEntitiesRepository : IDeaneryEntitiesRepository {

		//public IEnumerable<Cellule> Cellules => context.Cellules;

		//public IEnumerable<Class> Classes => context.Classes;

		//public IEnumerable<ClassNumberTime> ClassNumberTimes => context.ClassNumberTimes;

		//public IEnumerable<Department> Departments => context.Departments;

		//public IEnumerable<EducationalPlan> EducationalPlans => context.EducationalPlans;

		//public IEnumerable<Faculty> Faculties => context.Faculties;

		//public IEnumerable<FailureTicket> FailureTickets => context.FailureTickets;

		//public IEnumerable<Group> Groups => context.Groups;

		//public IEnumerable<Journal> Journals => context.Journals;

		//public IEnumerable<Professor> Professors => context.Professors;

		//public IEnumerable<ProgressRecord> ProgressRecords => context.ProgressRecords;

		//public IEnumerable<Semester> Semesters => context.Semesters;

		//public IEnumerable<Stream> Streams => context.Streams;

		//public IEnumerable<Student> Students => context.Students;

		//public IEnumerable<Subject> Subjects => context.Subjects;

		//public IEnumerable<TimeTable> TimeTables => context.TimeTables;

		//public IEnumerable<University> Universities => context.Universities; 

        private DeaneryDbContext context;
        public DeaneryEntitiesRepository()
        {
            context = new DeaneryDbContext();
        }

		public IEnumerable<Cellule> Cellules 
        {
            get
            {
                return context.Cellules;
            }
        }

		public IEnumerable<ClassNumberTime> ClassNumberTimes 
                    {
            get
            {
                return context.ClassNumberTimes;
            }
        }

		public IEnumerable<Department> Departments        
        {
            get
            {
                return context.Departments;
            }
        }

		public IEnumerable<Faculty> Faculties 
                    {
            get
            {
                return context.Faculties;
            }
        }

		public IEnumerable<FailureTicket> FailureTickets 
                    {
            get
            {
                return context.FailureTickets;
            }
        }

		public IEnumerable<Group> Groups 
                    {
            get
            {
                return context.Groups;
            }
        }

		public IEnumerable<Class> Classes      
        {
            get
            {
                return context.Classes;
            }
        }

		public IEnumerable<Journal> Journals 
        {
            get
            {
                return context.Journals;
            }
        }

		public IEnumerable<Professor> Professors
        {
            get
            {
                return context.Professors;
            }
        }

		public IEnumerable<ProgressRecord> ProgressRecords
        {
            get
            {
                return context.ProgressRecords;
            }
        }

		public IEnumerable<Semester> Semesters 
        {
            get
            {
                return context.Semesters;
            }
        }

		public IEnumerable<EducationalPlan> EducationalPlans
        {
            get
            {
                return context.EducationalPlans;
            }
        }

		public IEnumerable<Stream> Streams 
        {
            get
            {
                return context.Streams;
            }
        }

		public IEnumerable<Student> Students 
        {
            get
            {
                return context.Students;
            }
        }

		public IEnumerable<Subject> Subjects 
        {
            get
            {
                return context.Subjects;
            }
        }

		public IEnumerable<TimeTable> TimeTables 
        {
            get
            {
                return context.TimeTables;
            }
        }

		public IEnumerable<University> Universities 
        {
            get
            {
                return context.Universities;
            }
        } 
	}
}
