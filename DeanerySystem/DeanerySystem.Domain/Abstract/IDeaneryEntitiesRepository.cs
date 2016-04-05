using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Abstract
{
    public interface IDeaneryEntitiesRepository
    {
		IEnumerable<Cellule> Cellules { get; }
		IEnumerable<ClassNumberTime> ClassNumberTimes { get; }
		IEnumerable<Department> Departments { get; }
		IEnumerable<Faculty> Faculties { get; }
		IEnumerable<FailureTicket> FailureTickets { get; }
		IEnumerable<Group> Groups { get; }
		IEnumerable<Journal> Journals { get; }
		IEnumerable<JournalForMarking> JournalsForMarking { get; }
		IEnumerable<Professor> Professors { get; }
		IEnumerable<ProgressRecord> ProgressRecords { get; }
		IEnumerable<Semester> Semesters { get; }
		IEnumerable<SemesterEducationalPlan> SemesterEducationalPlans { get; }
        IEnumerable<Stream> Streams { get; }
		IEnumerable<Student> Students { get; }
		IEnumerable<Subject> Subjects { get; }
		IEnumerable<TimeTable> TimeTables { get; }
		IEnumerable<University> Universities { get; }
    }
}
