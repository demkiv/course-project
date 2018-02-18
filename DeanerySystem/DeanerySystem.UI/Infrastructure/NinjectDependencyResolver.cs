using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DeanerySystem.Domain;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Concrete;
using DeanerySystem.Domain.DataFeeders;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.Domain.Repositories;
using Moq;
using Ninject;
using System.Linq.Expressions;

namespace DeanerySystem.UI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            #region UnitOfWork

            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uw => uw.Context).Returns(() => null);

            #region UniversitiesUoW
            var universityRepositoryMock = MockFactory.GetMock<University, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.UniversityRepository).Returns(() => universityRepositoryMock.Object);
            #endregion

            #region FacultiesUoW
            var facultyRepositoryMock = MockFactory.GetMock<Faculty, int>(unitOfWorkMock.Object);           
            unitOfWorkMock.Setup(uw => uw.FacultyRepository).Returns(() => facultyRepositoryMock.Object);
            #endregion

            #region StreamsUoW
            var streamRepositoryMock = MockFactory.GetMock<Stream, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.StreamRepository).Returns(() => streamRepositoryMock.Object);
            #endregion

            #region DepartmentsUoW   
            var departmentRepositoryMock = MockFactory.GetMock<Department, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.DepartmentRepository).Returns(() => departmentRepositoryMock.Object);
            #endregion

            #region ProfessorsUoW
            var professorRepositoryMock = MockFactory.GetMock<Professor, Guid>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.ProfessorRepository).Returns(() => professorRepositoryMock.Object);
            #endregion

            #region SemestersUoW
            var semesterRepositoryMock = MockFactory.GetMock<Semester, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.SemesterRepository).Returns(() => semesterRepositoryMock.Object);
            #endregion

            #region GroupsUoW
            var groupRepositoryMock = MockFactory.GetMock<Group, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.GroupRepository).Returns(() => groupRepositoryMock.Object);
            #endregion

            #region StudentsUoW      
            var studentRepositoryMock = MockFactory.GetMock<Student, Guid>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.StudentRepository).Returns(() => studentRepositoryMock.Object);
            #endregion
            
            #region SubjectsUoW
            var subjectRepositoryMock = MockFactory.GetMock<Subject, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.SubjectRepository).Returns(() => subjectRepositoryMock.Object);
            #endregion

            #region ClassesUoW
            var classRepositoryMock = MockFactory.GetMock<Class, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.ClassRepository).Returns(() => classRepositoryMock.Object);
            #endregion

            #region JournalUoW
            var journalRepositoryMock = MockFactory.GetMock<Journal, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.JournalRepository).Returns(() => journalRepositoryMock.Object);
            #endregion

            #region CellulesUoW
            var celluleRepositoryMock = MockFactory.GetMock<Cellule, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.CelluleRepository).Returns(() => celluleRepositoryMock.Object);
            #endregion

            #region TimeTableUoW
            var timeTableRepositoryMock = MockFactory.GetMock<TimeTable, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.TimeTableRepository).Returns(() => timeTableRepositoryMock.Object);
            #endregion

            #region ClassNumberTimesUow
            var classNumberTimeRepositoryMock = MockFactory.GetMock<ClassNumberTime, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.ClassNumberTimeRepository).Returns(() => classNumberTimeRepositoryMock.Object);
            #endregion

            #region EducationalPlanUoW
            var educationlPlanRepositoryMock = MockFactory.GetMock<EducationalPlan, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.EducationalPlanRepository).Returns(() => educationlPlanRepositoryMock.Object);
            #endregion
            
            #region UnitOfWorkSetup           
            unitOfWorkMock.Setup(uw => uw.Save());
            unitOfWorkMock.Setup(uw => uw.Dispose());
            #endregion

            #endregion

            kernel.Bind<IUnitOfWork>().ToConstant(unitOfWorkMock.Object);
            //kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
	}
}
