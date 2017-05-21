using System;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

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

		IGenericRepository<IdentityRole> IdentityRoleRepository { get; }
		IGenericRepository<Entities.Identity.ApplicationUser> IdentityUserRepository { get; }
		IGenericRepository<IdentityUserRole> IdentityUserRoleRepository { get; }
		IGenericRepository<IdentityUserClaim> IdentityUserClaimRepository { get; }
		IGenericRepository<IdentityUserLogin> IdentityUserLoginRepository { get; }
		
		
		void Save();
    }
}
