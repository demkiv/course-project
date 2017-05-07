using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Repositories;

namespace DeanerySystem.Domain
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Cellule> CelluleRepository { get; }
        IGenericRepository<Class> ClassRepository { get; }
        IGenericRepository<ClassNumberTime> ClassNumberTimeRepository { get; }
        IGenericRepository<DeaneryUser> DeaneryUserRepository { get; }
        IGenericRepository<Department> DepartmentRepository { get; }
        IGenericRepository<EducationalPlan> EducationalPlanRepository { get; }
        IGenericRepository<Faculty> FacultyRepository { get; }
        IGenericRepository<FailureTicket> FailureTicketRepository { get; }
        IGenericRepository<Group> GroupRepository { get; }
        IGenericRepository<Journal> JournalRepository { get; }
        IGenericRepository<Professor> ProfessorRepository { get; }
        IGenericRepository<ProgressRecord> ProgressRecordRepository { get; }
        IGenericRepository<Semester> SemesterRepository { get; }
        IGenericRepository<Stream> StreamRepository { get; }
        IGenericRepository<Student> StudentRepository { get; }
        IGenericRepository<Subject> SubjectRepository { get; }
        IGenericRepository<TimeTable> TimeTableRepository { get; }
        IGenericRepository<University> UniversityRepository { get; }
        void Save();
    }
}
