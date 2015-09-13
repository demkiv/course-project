using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Abstract
{
    public interface IEntitiesRepository
    {
        IEnumerable<Student> Students { get; }
        IEnumerable<Professor> Professors { get; }
        IEnumerable<Faculty> Faculties { get; }
        IEnumerable<Stream> Streams { get; }
        IEnumerable<Department> Departments { get; }
        IEnumerable<Group> Groups { get; }
        IEnumerable<Semester> Semesters { get; }
        IEnumerable<BookOfSuccess> BooksOfSuccess{ get; }
        IEnumerable<Writing> Writings { get; }
        IEnumerable<Subject> Subjects { get; }
        IEnumerable<Cellule> Cellules { get; }
        IEnumerable<Journal> Journals { get; }
        IEnumerable<JournalForMarking> JournalsForMarking { get; }
        IEnumerable<TimeTable> TimeTables { get; }
        IEnumerable<ClassNumberTime> ClassNumberTimes { get; }
    }
}
