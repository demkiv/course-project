using System;
using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Entities.Identity;
using DeanerySystem.DataAccess.Repositories;

namespace DeanerySystem.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Cellule> CelluleRepository { get; }
        IGenericRepository<Class> ClassRepository { get; }
        IGenericRepository<ClassNumberTime> ClassNumberTimeRepository { get; }
        IGenericRepository<DeaneryUser> DeaneryUserRepository { get; }
        IGenericRepository<Department> DepartmentRepository { get; }
        EducationalPlanRepository EducationalPlanRepository { get; }
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
        DeaneryDbContext Context { get; }
        void Save();
    }
}
