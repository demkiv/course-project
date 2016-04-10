using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Concrete {
	public class DeaneryEntitiesRepository : IDeaneryEntitiesRepository {

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

		public IEnumerable<Journal> Journals      
        {
            get
            {
                return context.Journals;
            }
        }

		public IEnumerable<JournalForMarking> JournalsForMarking 
        {
            get
            {
                return context.JournalsForMarking;
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

		public IEnumerable<SemesterEducationalPlan> SemesterEducationalPlans
        {
            get
            {
                return context.SemesterEducationalPlans;
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
