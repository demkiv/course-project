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

            #region FacultiesUoW
            var facultyRepositoryMock = MockFactory.GetMock<Faculty, int>(unitOfWorkMock.Object);           
            unitOfWorkMock.Setup(uw => uw.FacultyRepository).Returns(() => facultyRepositoryMock.Object);

            #endregion

            #region StreamsUoW
            var streamRepositoryMock = MockFactory.GetMock<Stream, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.StreamRepository).Returns(() => streamRepositoryMock.Object);

            //var streamDataFeeder = new StreamDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<Stream>> streamRepositoryMock = new Mock<IGenericRepository<Stream>>();
            //streamRepositoryMock.Setup(sr => sr.Get(null, null, "")).Returns(streamDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.StreamRepository).Returns(() => streamRepositoryMock.Object);
            #endregion

            #region DepartmentsUoW   

            var departmentRepositoryMock = MockFactory.GetMock<Department, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.DepartmentRepository).Returns(() => departmentRepositoryMock.Object);

            //var departmentDataFeeder = new DepartmentDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<Department>> departmentRepositoryMock = new Mock<IGenericRepository<Department>>();
            //departmentRepositoryMock.Setup(dr => dr.Get(null, null, "")).Returns(departmentDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.DepartmentRepository).Returns(() => departmentRepositoryMock.Object);
            #endregion

            #region SemestersUoW

            var semesterRepositoryMock = MockFactory.GetMock<Semester, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.SemesterRepository).Returns(() => semesterRepositoryMock.Object);
            //var semesterDataFeeder = new SemesterDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<Semester>> semesterRepositoryMock = new Mock<IGenericRepository<Semester>>();
            //semesterRepositoryMock.Setup(sr => sr.Get(null, null, "")).Returns(semesterDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.SemesterRepository).Returns(() => semesterRepositoryMock.Object);
            #endregion

            #region StudentsUoW      

            var studentRepositoryMock = MockFactory.GetMock<Student, Guid>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.StudentRepository).Returns(() => studentRepositoryMock.Object);
            //var studentDataFeeder = new StudentDataFeeder(unitOfWorkMock.Object);     
            //Mock<IGenericRepository<Student>> studentRepositoryMock = new Mock<IGenericRepository<Student>>();
            //studentRepositoryMock.Setup(sr => sr.Get(null, null, "")).Returns(studentDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.StudentRepository).Returns(() => studentRepositoryMock.Object);
            #endregion

            #region ProfessorsUoW

            var professorRepositoryMock = MockFactory.GetMock<Professor, Guid>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.ProfessorRepository).Returns(() => professorRepositoryMock.Object);
            //var professorDataFeeder = new ProfessorDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<Professor>> professorRepositoryMock = new Mock<IGenericRepository<Professor>>();
            //professorRepositoryMock.Setup(pr => pr.Get(null, null, "")).Returns(professorDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.ProfessorRepository).Returns(() => professorRepositoryMock.Object);
            #endregion

            #region GroupsUoW

            var groupRepositoryMock = MockFactory.GetMock<Group, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.GroupRepository).Returns(() => groupRepositoryMock.Object);
            //var groupDataFeeder = new GroupDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<Group>> groupRepositoryMock = new Mock<IGenericRepository<Group>>();
            //groupRepositoryMock.Setup(gr => gr.Get(null, null, "")).Returns(groupDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.GroupRepository).Returns(() => groupRepositoryMock.Object);

            #endregion

            #region ClassNumberTimesUow

            var classNumberTimeRepositoryMock = MockFactory.GetMock<ClassNumberTime, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.ClassNumberTimeRepository).Returns(() => classNumberTimeRepositoryMock.Object);
            //var classNumberTimeDataFeeder = new ClassNumberTimeDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<ClassNumberTime>> classNumberTimeRepositoryMock =
            //    new Mock<IGenericRepository<ClassNumberTime>>();
            //classNumberTimeRepositoryMock.Setup(cnt => cnt.Get(null, null, "")).Returns(classNumberTimeDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.ClassNumberTimeRepository).Returns(() => classNumberTimeRepositoryMock.Object);
            #endregion

            #region TimeTableUoW

            var timeTableRepositoryMock = MockFactory.GetMock<TimeTable, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.TimeTableRepository).Returns(() => timeTableRepositoryMock.Object);
            //var timeTableDataFeeder = new TimeTableDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<TimeTable>> timeTableRepositoryMock = new Mock<IGenericRepository<TimeTable>>();
            //timeTableRepositoryMock.Setup(ttr => ttr.Get(null, null, "")).Returns(timeTableDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.TimeTableRepository).Returns(() => timeTableRepositoryMock.Object);
            #endregion

            #region CellulesUoW

            var celluleRepositoryMock = MockFactory.GetMock<Cellule, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.CelluleRepository).Returns(() => celluleRepositoryMock.Object);
            //var cellulesDataFeeder = new CellulesDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<Cellule>> celluleRepositoryMock = new Mock<IGenericRepository<Cellule>>();
            //celluleRepositoryMock.Setup(cr => cr.Get(null, null, "")).Returns(cellulesDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.CelluleRepository).Returns(() => celluleRepositoryMock.Object);
            #endregion

            #region JournalUoW

            var journalRepositoryMock = MockFactory.GetMock<Journal, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.JournalRepository).Returns(() => journalRepositoryMock.Object);
            //var journalDataFeeder = new JournalDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<Journal>> journalRepository = new Mock<IGenericRepository<Journal>>();
            //journalRepository.Setup(jr => jr.Get(null, null, "")).Returns(journalDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.JournalRepository).Returns(() => journalRepository.Object);
            #endregion

            #region ClassesUoW

            var classRepositoryMock = MockFactory.GetMock<Class, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.ClassRepository).Returns(() => classRepositoryMock.Object);
            //var classDataFeeder = new ClassDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<Class>> classRepository = new Mock<IGenericRepository<Class>>();
            //classRepository.Setup(cr => cr.Get(null, null, "")).Returns(classDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.ClassRepository).Returns(() => classRepository.Object);
            #endregion

            #region SubjectsUoW

            var subjectRepositoryMock = MockFactory.GetMock<Subject, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.SubjectRepository).Returns(() => subjectRepositoryMock.Object);
            //var subjectDataFeeder = new SubjectDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<Subject>> subjectRepositoryMock = new Mock<IGenericRepository<Subject>>();
            //subjectRepositoryMock.Setup(sr => sr.Get(null, null, "")).Returns(subjectDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.SubjectRepository).Returns(() => subjectRepositoryMock.Object);
            #endregion

            #region EducationalPlanUoW

            var educationlPlanRepositoryMock = MockFactory.GetMock<EducationalPlan, int>(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(uw => uw.EducationalPlanRepository).Returns(() => educationlPlanRepositoryMock.Object);
            //var educationalPlanDataFeeder = new EducationalPlanDataFeeder(unitOfWorkMock.Object);
            //Mock<IGenericRepository<EducationalPlan>> educationlPlanRepositoryMock =
            //    new Mock<IGenericRepository<EducationalPlan>>();
            //educationlPlanRepositoryMock.Setup(epr => epr.Get(null, null, "")).Returns(educationalPlanDataFeeder.GetData());
            //unitOfWorkMock.Setup(uw => uw.EducationalPlanRepository).Returns(() => educationlPlanRepositoryMock.Object);
            #endregion
            
            #region UnitOfWorkSetup           




            unitOfWorkMock.Setup(uw => uw.Save());
            unitOfWorkMock.Setup(uw => uw.Dispose());
            #endregion

            #endregion

            //------------------------------------------------------------------------------------

            #region Repository
            Mock<IDeaneryEntitiesRepository> entitiesMock = new Mock<IDeaneryEntitiesRepository>();

            #region Faculties

            entitiesMock.Setup(m => m.Faculties).Returns(new List<Faculty>
            {
                new Faculty {Id = 1, Name = "Biology"},
                new Faculty {Id = 2, Name = "Geography"},
                new Faculty {Id = 3, Name = "Geology"},
                new Faculty {Id = 4, Name = "Economics"},
                new Faculty {Id = 5, Name = "Electronics"},
                new Faculty {Id = 6, Name = "Jornalism"},
                new Faculty {Id = 7, Name = "Foreign Languages"},
                new Faculty {Id = 8, Name = "History"},
                new Faculty {Id = 9, Name = "Culture and Arts"},
                new Faculty {Id = 10, Name = "International Relations"},
                new Faculty {Id = 11, Name = "Mechanics and Mathematics"},
                new Faculty {Id = 12, Name = "Applied Mathematics and Information Science"},
                new Faculty {Id = 13, Name = "Physics"},
                new Faculty {Id = 14, Name = "Philology"},
                new Faculty {Id = 15, Name = "Philosophy"},
                new Faculty {Id = 16, Name = "Chemistry"},
                new Faculty {Id = 17, Name = "Law"}
            });

            #endregion

            #region Streams

            entitiesMock.Setup(m => m.Streams).Returns(new List<Stream>
            {
                new Stream()
                {
                    Id = 1,
                    Name = "Інформатика",
                    StreamAbbreviation = "ПМІ",
                    Faculty = entitiesMock.Object.Faculties.ElementAt(11)
                }
            });

            #endregion

            #region Departments

            entitiesMock.Setup(m => m.Departments).Returns(new List<Department>
            {
                new Department()
                {
                    Id = 1,
                    Name = "Інформаційні системи",
                    //Head = entitiesMock.Object.Professors.ElementAt(1),
                    Number = 2
                    //Stream = entitiesMock.Object.Streams.ElementAt(0)
                }
            });

            #endregion

            #region Semesters

            entitiesMock.Setup(m => m.Semesters).Returns(new List<Semester>
            {
                new Semester
                {
                    Id = 1,
                    Number = SemesterNumber.Second,
                    Start = new DateTime(2016, 2, 9),
                    CreditSessionStart = new DateTime(2016, 5, 13)
                }
            });

            #endregion

            #region Students
            entitiesMock.Setup(m => m.Students).Returns(new List<Student>
			{
				new Student
				{
                    //Id = 1,
                    FirstName = "Богдан",
					LastName = "Андрусяк",
					MiddleName = "Тарасович",
                    //UserName = "ABT1",
                    //Password = "1",
                    //Role = Roles.Student,
                    StudentCode = "BC123456",
					TuitionFee = TuitionFees.Scholar
				},
				new Student
				{
                    //Id = 2,
                    FirstName = "Володимир",
					LastName = "Будзан",
					MiddleName = "Іванович",
                    //UserName = "VBV2",
                    //Password = "1",
                    //Role = Roles.Student,
                    StudentCode = "BC123457",
					TuitionFee = TuitionFees.Scholar
				},
				new Student
				{
					//Id = 3,
                    FirstName = "Микола",
					LastName = "Ванькович",
					MiddleName = "Дмитрович",
                    //UserName = "MVM3",
                    //Password = "1",
                    //Role = Roles.Student,
                    StudentCode = "BC123458",
					TuitionFee = TuitionFees.Scholar
				},
				new Student
				{
                    //Id = 4,
                    FirstName = "Соломія",
					LastName = "Демків",
					MiddleName = "Тарасівна"
				},
				new Student
				{
                    //Id = 5,
                    FirstName = "Марія-Ярина",
					LastName = "Джала",
					MiddleName = "Юріївна"
				},
				new Student
				{
                    //Id = 6,
                    FirstName = "Андрій",
					LastName = "Дячук",
					MiddleName = "Валерійович"
				},
				new Student
				{
                    //Id = 7,
                    FirstName = "Назарій",
					LastName = "Корчак",
					MiddleName = "Юрійович"
				},
				new Student
				{
                    //Id = 8,
                    FirstName = "Орест",
					LastName = "Купин",
					MiddleName = "Андрійович"
				},
				new Student
				{
                    //Id = 9,
                    FirstName = "Анастасія",
					LastName = "Ладанівська",
					MiddleName = "Борисівна"
				},
				new Student
				{
                    //Id = 10,
                    FirstName = "Денис",
					LastName = "Лебедович",
					MiddleName = "Олегович"
				},
				new Student
				{
                    //Id = 11,
                    FirstName = "Ігор",
					LastName = "Михаляк",
					MiddleName = "Ярославович"
				},
				new Student
				{
                    //Id = 12,
                    FirstName = "Юрій",
					LastName = "Олексишин",
					MiddleName = "Юрійович"
				},
				new Student
				{
                    //Id = 13,
                    FirstName = "Володимир",
					LastName = "Пабирівський",
					MiddleName = "Вікторович"
				},
				new Student
				{
                    //Id = 14,
                    FirstName = "Маркіян",
					LastName = "Різун",
					MiddleName = "Тарасович"
				},
				new Student
				{
                    //Id = 15,
                    FirstName = "Михайло",
					LastName = "Рімель",
					MiddleName = "Йосифович"
				},
				new Student
				{
                    //Id = 16,
                    FirstName = "Роман",
					LastName = "Слєпко",
					MiddleName = "Ігорович"
				},
				new Student
				{
                    //Id = 17,
                    FirstName = "Василь",
					LastName = "Хміль",
					MiddleName = "Ігорович"
				},
				new Student
				{
                    //Id = 18,
                    FirstName = "Володимир",
					LastName = "Хміль",
					MiddleName = "Ярославович"
				},
				new Student
				{
                    //Id = 19,
                    FirstName = "Мар’яна",
					LastName = "Ходачник",
					MiddleName = "Ростиславівна"
				},
				new Student
				{
                    //Id = 20,
                    FirstName = "Анна-Марія",
					LastName = "Юрочко",
					MiddleName = "Вікторівна"
				},
				new Student
				{
					FirstName = "Маркіян",
					LastName = "Воробель",
					MiddleName = "Романович"
				},
				new Student
				{
					FirstName = "Назар",
					LastName = "Герман",
					MiddleName = "Романович"
				},
				new Student
				{
					FirstName = "Андрій",
					LastName = "Глова",
					MiddleName = "Романович"
				},
				new Student
				{
					FirstName = "Соломія",
					LastName = "Гнідець",
					MiddleName = "Святославівна"
				},
				new Student
				{
					FirstName = "Андрій",
					LastName = "Євчак",
					MiddleName = "Михайлович"
				},
				new Student
				{
					FirstName = "Олег",
					LastName = "Занік",
					MiddleName = "Павлович"
				},
				new Student
				{
					FirstName = "Олексій",
					LastName = "Кондратюк",
					MiddleName = "Анатолійович"
				},
				new Student
				{
					FirstName = "Михайло",
					LastName = "Копилець",
					MiddleName = "Миколайович"
				},new Student
				{
					FirstName = "Христина",
					LastName = "Михайлюк",
					MiddleName = "Володимирівна"
				},
				new Student
				{
					FirstName = "Олеся",
					LastName = "Мідяна",
					MiddleName = "Іванівна"
				},
				new Student
				{
					FirstName = "Микола",
					LastName = "Молочій",
					MiddleName = "Вікторівна"
				},
				new Student
				{
					FirstName = "Юрій",
					LastName = "Плоский",
					MiddleName = "Васильович"
				},
				new Student
				{
					FirstName = "Ігор",
					LastName = "Романчук",
					MiddleName = "Володимирович"
				},new Student
				{
					FirstName = "Тарас",
					LastName = "Романчук",
					MiddleName = "Григорович"
				},new Student
				{
					FirstName = "Богдан",
					LastName = "Смачило",
					MiddleName = "Васильович"
				},
				new Student
				{
					FirstName = "Маркіян",
					LastName = "Фостяк",
					MiddleName = "Романович"
				},
				new Student
				{
					FirstName = "Софія",
					LastName = "Хомин",
					MiddleName = "Андріївна"
				},new Student
				{
					FirstName = "Володимир",
					LastName = "Чіх",
					MiddleName = "Іванович"
				},
				new Student
				{
					FirstName = "Данило",
					LastName = "Юристовський",
					MiddleName = "Орестович"
				},
				new Student
				{
					FirstName = "Вікторія",
					LastName = "Юріяк",
					MiddleName = "Віталіївна"
				}
			});
			#endregion

			#region Professors
			entitiesMock.Setup(m => m.Professors).Returns(new List<Professor>
			{
				new Professor
				{
                    //Id = 4,
                    FirstName = "Георгій",
					LastName = "Шинкаренко",
					MiddleName = "Андрійович",
                    //UserName = "Shef",
                    //Password = "1",
                    //Role = Roles.Professor,
                    Position = Positions.Professor
				},
				new Professor
				{
                    //Id = 5,
                    FirstName = "Віталій",
					LastName = "Горлач",
					MiddleName = "Михайлович",
                    //UserName = "VHM5",
                    //Password = "1",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 6,
                    FirstName = "Петро",
					LastName = "Вагін",
					MiddleName = "Петрович",
                    //UserName = "PVP6",
                    //Password = "1",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 7,
                    FirstName = "Роман",
					LastName = "Рикалюк",
					MiddleName = "Євстахович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 8,
                    FirstName = "Марта",
					LastName = "Жук",
					MiddleName = "Вікторівна",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 8,
                    FirstName = "Михайло",
					LastName = "Щербатий",
					MiddleName = "Васильович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 8,
                    FirstName = "Роман",
					LastName = "Шандра",
					MiddleName = "Станіславович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 8,
                    FirstName = "Валерія",
					LastName = "Семків",
					MiddleName = "Олегівна",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 8,
                    FirstName = "Віталій",
					LastName = "Чорненький",
					MiddleName = "Ігорович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 8,
                    FirstName = "Надія",
					LastName = "Колос",
					MiddleName = "Мирославівна",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 8,
                    FirstName = "Святослав",
					LastName = "Літинський",
					MiddleName = "Володимирович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				},
				new Professor
				{
                    //Id = 8,
                    FirstName = "Володимир",
					LastName = "Вовк",
					MiddleName = "Дмитрович",
                    //Role = Roles.Professor,
                    Position = Positions.AssociateProfessor
				}
			});
			#endregion

			#region Groups
			entitiesMock.Setup(m => m.Groups).Returns(new List<Group>
			{
				new Group
				{
					Id = 1,
					Name = "ПМІ-41",
                    //Mentor = entitiesMock.Object.Professors.ElementAt(0),
                    Department = entitiesMock.Object.Departments.ElementAt(0),
					Students = new List<Student>()
					{
						entitiesMock.Object.Students.ElementAt(20),
						entitiesMock.Object.Students.ElementAt(21),
						entitiesMock.Object.Students.ElementAt(22),
						entitiesMock.Object.Students.ElementAt(23),
						entitiesMock.Object.Students.ElementAt(24),
						entitiesMock.Object.Students.ElementAt(25),
						entitiesMock.Object.Students.ElementAt(26),
						entitiesMock.Object.Students.ElementAt(27),
						entitiesMock.Object.Students.ElementAt(28),
						entitiesMock.Object.Students.ElementAt(29),
						entitiesMock.Object.Students.ElementAt(30),
						entitiesMock.Object.Students.ElementAt(31),
						entitiesMock.Object.Students.ElementAt(32),
						entitiesMock.Object.Students.ElementAt(33),
						entitiesMock.Object.Students.ElementAt(34),
						entitiesMock.Object.Students.ElementAt(35),
						entitiesMock.Object.Students.ElementAt(36),
						entitiesMock.Object.Students.ElementAt(37),
						entitiesMock.Object.Students.ElementAt(38),
						entitiesMock.Object.Students.ElementAt(39)
					},
					//EducationalPlans = new List<EducationalPlan>()
					//{
					//	new EducationalPlan() { Semester = entitiesMock.Object.Semesters.ElementAt(0) }
					//}
				},
				new Group
				{
					Id = 2,
					Name = "ПМІ-42",
					Mentor = entitiesMock.Object.Professors.ElementAt(0),
					Department = entitiesMock.Object.Departments.ElementAt(0),
					Students = new List<Student>()
					{
						entitiesMock.Object.Students.ElementAt(0),
						entitiesMock.Object.Students.ElementAt(1),
						entitiesMock.Object.Students.ElementAt(2),
						entitiesMock.Object.Students.ElementAt(3),
						entitiesMock.Object.Students.ElementAt(4),
						entitiesMock.Object.Students.ElementAt(5),
						entitiesMock.Object.Students.ElementAt(6),
						entitiesMock.Object.Students.ElementAt(7),
						entitiesMock.Object.Students.ElementAt(8),
						entitiesMock.Object.Students.ElementAt(9),
						entitiesMock.Object.Students.ElementAt(10),
						entitiesMock.Object.Students.ElementAt(11),
						entitiesMock.Object.Students.ElementAt(12),
						entitiesMock.Object.Students.ElementAt(13),
						entitiesMock.Object.Students.ElementAt(14),
						entitiesMock.Object.Students.ElementAt(15),
						entitiesMock.Object.Students.ElementAt(16),
						entitiesMock.Object.Students.ElementAt(17),
						entitiesMock.Object.Students.ElementAt(18),
						entitiesMock.Object.Students.ElementAt(19)
					},
					//EducationalPlans = new List<EducationalPlan>()
					//{
					//	new EducationalPlan() { Semester = entitiesMock.Object.Semesters.ElementAt(0) }
					//}
				}
			});
			#endregion

			#region ClassNumberTimes
			entitiesMock.Setup(m => m.ClassNumberTimes).Returns(new List<ClassNumberTime>
			{
				new ClassNumberTime()
				{
					Id = 1,
					Number = 1,
					Start = new TimeSpan(0, 8, 30, 0, 0),
					End = new TimeSpan(0, 9, 50, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 2,
					Number = 2,
					Start = new TimeSpan(0, 10, 10, 0, 0),
					End = new TimeSpan(0, 11, 30, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 3,
					Number = 3,
					Start = new TimeSpan(0, 11, 50, 0, 0),
					End = new TimeSpan(0, 13, 10, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 4,
					Number = 4,
					Start = new TimeSpan(0, 13, 30, 0, 0),
					End = new TimeSpan(0, 14, 50, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 5,
					Number = 5,
					Start = new TimeSpan(0, 15, 15, 0, 0),
					End = new TimeSpan(0, 16, 25, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 6,
					Number = 6,
					Start = new TimeSpan(0, 16, 40, 0, 0),
					End = new TimeSpan(0, 18, 0, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 7,
					Number = 7,
					Start = new TimeSpan(0, 18, 10, 0, 0),
					End = new TimeSpan(0, 19, 30, 0, 0)
				}
			});
			#endregion

			#region TimeTables
			entitiesMock.Setup(m => m.TimeTables).Returns(new List<TimeTable>
			{
				new TimeTable //щербатий лекція
				{
					Id = 1,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Integer,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(5)
					}
				},
				new TimeTable //щербатий лекція // not used
				{
					Id = 2,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Denominator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(5)
					}
				},
				new TimeTable // право лекція
				{
					Id = 3,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Numerator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(6)
					}
				},
				new TimeTable // право практична
				{
					Id = 4,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Denominator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(6)
					}
				},
				new TimeTable // мод 42
				{
					Id = 5,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Numerator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(4)
					}
				},
				new TimeTable // мод 42
				{
					Id = 6,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Integer,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(5)
					}
				},
				new TimeTable // мод 42 // not used
				{
					Id = 7,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Denominator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(5)
					}
				},
				new TimeTable // колос
				{
					Id = 8,
					DayOfWeek = DayOfWeek.Tuesday,
					Fraction = Fractions.Integer,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(0)
					}
				},
				new TimeTable // колос // not used
				{
					Id = 9,
					DayOfWeek = DayOfWeek.Tuesday,
					Fraction = Fractions.Denominator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(2)
					}
				},
				new TimeTable // вовк
				{
					Id = 10,
					DayOfWeek = DayOfWeek.Tuesday,
					Fraction = Fractions.Integer,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(3)
					}
				},
				new TimeTable // літик
				{
					Id = 11,
					DayOfWeek = DayOfWeek.Tuesday,
					Fraction = Fractions.Denominator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(3)
					}
				}
			});
			#endregion

			#region Cellules
			entitiesMock.Setup(m => m.Cellules).Returns(new List<Cellule>
			{
				new Cellule
				{
					Id = 1,
					Date = new DateTime(2015, 3, 24,  15, 15, 0),
					Mark = "7",
					Student = entitiesMock.Object.Students.ElementAt(1)
				},
				new Cellule
				{
					Id = 2,
					Date = new DateTime(2015, 2, 10, 13, 30, 0),
					Mark = "15",
					Student = entitiesMock.Object.Students.ElementAt(2)
				},
				new Cellule
				{
					Id = 3,
					Date = new DateTime(2015, 3, 3, 15, 15, 0),
					Mark = "22",
					Student = entitiesMock.Object.Students.ElementAt(4)
				},
				new Cellule
				{
					Id = 4,
					Date = new DateTime(2015, 3, 3, 15, 15, 0),
					Mark = "21",
					Student = entitiesMock.Object.Students.ElementAt(8)
				},
				new Cellule
				{
					Id = 5,
					Date = new DateTime(2015, 3, 3, 15, 15, 0),
					Mark = "17",
					Student = entitiesMock.Object.Students.ElementAt(10)
				},
				new Cellule
				{
					Id = 6,
					Date = new DateTime(2015, 3, 3, 15, 15, 0),
					Mark = "19",
					Student = entitiesMock.Object.Students.ElementAt(14)
				},
				new Cellule
				{
					Id = 7,
					Date = new DateTime(2015, 3, 3, 15, 15, 0),
					Mark = "22",
					Student = entitiesMock.Object.Students.ElementAt(11)
				},
				new Cellule
				{
					Id = 8,
					Date = new DateTime(2015, 3, 3, 15, 15, 0),
					Mark = "н",
					Student = entitiesMock.Object.Students.ElementAt(4)
				}
			});
			#endregion

			#region Journals
			entitiesMock.Setup(m => m.Journals).Returns(new List<Journal>
			{
				new Journal
				{
					Id = 1,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
						//entitiesMock.Object.Cellules.ElementAt(0),
						//entitiesMock.Object.Cellules.ElementAt(1),
						//entitiesMock.Object.Cellules.ElementAt(2),
						//entitiesMock.Object.Cellules.ElementAt(3),
						//entitiesMock.Object.Cellules.ElementAt(4),
						//entitiesMock.Object.Cellules.ElementAt(5),
						//entitiesMock.Object.Cellules.ElementAt(6)
					}
				},
				new Journal
				{
					Id = 2,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 3,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 4,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 5,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 6,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 7,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 8,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 9,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 10,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 11,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 12,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 13,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 14,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 15,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 16,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 17,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 18,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 19,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new Journal
				{
					Id = 20,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				}
			});
			#endregion

			#region Classes
			entitiesMock.Setup(m => m.Classes).Returns(new List<Class>
			{
				new Class
				{
					Id = 1,
					ClassType = ClassTypes.Lecture,
					Professor = entitiesMock.Object.Professors.ElementAt(5),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(0),
						entitiesMock.Object.Journals.ElementAt(1)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(0),
						//entitiesMock.Object.TimeTables.ElementAt(1)
					}
				},
				new Class // право
				{
					Id = 2,
					ClassType = ClassTypes.Lecture,
					Professor = entitiesMock.Object.Professors.ElementAt(6),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(2),
						entitiesMock.Object.Journals.ElementAt(3)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(2)
					}
				},
				new Class // право
				{
					Id = 3,
					ClassType = ClassTypes.PracticalClass,
					Professor = entitiesMock.Object.Professors.ElementAt(7),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(4),
						entitiesMock.Object.Journals.ElementAt(5)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(3)
					}
				},
				new Class
				{
					Id = 4,
					ClassType = ClassTypes.PracticalClass,
					Professor = entitiesMock.Object.Professors.ElementAt(5),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(6),
						entitiesMock.Object.Journals.ElementAt(7)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(4)
					}
				},
				new Class
				{
					Id = 5,
					ClassType = ClassTypes.Lecture,
					Professor = entitiesMock.Object.Professors.ElementAt(5),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(8),
						entitiesMock.Object.Journals.ElementAt(9)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(5),
						//entitiesMock.Object.TimeTables.ElementAt(6)
					}
				},
				new Class // право
				{
					Id = 6,
					ClassType = ClassTypes.Lecture,
					Professor = entitiesMock.Object.Professors.ElementAt(6),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(10),
						entitiesMock.Object.Journals.ElementAt(11)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(2)
					}
				},
				new Class // право
				{
					Id = 7,
					ClassType = ClassTypes.PracticalClass,
					Professor = entitiesMock.Object.Professors.ElementAt(8),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(12),
						entitiesMock.Object.Journals.ElementAt(13)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(3)
					}
				},
				new Class // колос
				{
					Id = 8,
					ClassType = ClassTypes.PracticalClass,
					Professor = entitiesMock.Object.Professors.ElementAt(9),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(14),
						entitiesMock.Object.Journals.ElementAt(15)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(7),
						//entitiesMock.Object.TimeTables.ElementAt(8)
					}
				},
				new Class // вовк
				{
					Id = 9,
					ClassType = ClassTypes.PracticalClass,
					Professor = entitiesMock.Object.Professors.ElementAt(11),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(16),
						entitiesMock.Object.Journals.ElementAt(17)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(9),
						//entitiesMock.Object.TimeTables.ElementAt(10)
					}
				},
				new Class // літик
				{
					Id = 10,
					ClassType = ClassTypes.PracticalClass,
					Professor = entitiesMock.Object.Professors.ElementAt(10),
					Journals = new List<Journal>
					{
						entitiesMock.Object.Journals.ElementAt(18),
						entitiesMock.Object.Journals.ElementAt(19)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(10)
					}
				}
			});
            #endregion

            #region Subjects
            entitiesMock.Setup(m => m.Subjects).Returns(new List<Subject>
			{
				new Subject
				{
					Id = 1,
					Name = "Моделювання складних систем",
					SemesterControl = SemesterControlTypes.Credit,
					NumberOfConsultations = 0,
					NumberOfLectures = 0,
					NumberOfPracticalClasses = 17,
					NumberOflLaboratoryClasses = 0,
					PassingDate = new DateTime(2015, 6, 6),
					Classes = new List<Class>()
					{
						entitiesMock.Object.Classes.ElementAt(0)
					}
				},
				new Subject
				{
					Id = 2,
					Name = "Основи права та основи конституційного права",
					SemesterControl = SemesterControlTypes.Credit,
					PassingDate = new DateTime(2015, 6, 6),
					Classes = new List<Class>()
					{
						entitiesMock.Object.Classes.ElementAt(1),
						entitiesMock.Object.Classes.ElementAt(2)
					}
				},
				new Subject
				{
					Id = 3,
					Name = "Моделювання складних систем",
					SemesterControl = SemesterControlTypes.Credit,
					PassingDate = new DateTime(2015, 6, 6),
					Classes = new List<Class>()
					{
						entitiesMock.Object.Classes.ElementAt(3),
						entitiesMock.Object.Classes.ElementAt(4)
					}
				},
				new Subject
				{
					Id = 4,
					Name = "Основи права та основи конституційного права",
					SemesterControl = SemesterControlTypes.Exam,
					PassingDate = new DateTime(2015, 6, 6),
					Classes = new List<Class>()
					{
						entitiesMock.Object.Classes.ElementAt(5),
						entitiesMock.Object.Classes.ElementAt(6)
					}
				},
				new Subject
				{
					Id = 5,
					Name = "Системи штучного інтелекту",
					SemesterControl = SemesterControlTypes.Exam,
					PassingDate = new DateTime(2015, 6, 6),
					Classes = new List<Class>()
					{
						entitiesMock.Object.Classes.ElementAt(7)
					}
				},
				new Subject
				{
					Id = 6,
					Name = "Чисельні методи математичної фізики",
					SemesterControl = SemesterControlTypes.Exam,
					PassingDate = new DateTime(2015, 6, 6),
					Classes = new List<Class>()
					{
						entitiesMock.Object.Classes.ElementAt(8)
					}
				},
				new Subject
				{
					Id = 7,
					Name = "Програмування під UNIX-подібними системами",
					SemesterControl = SemesterControlTypes.Exam,
					PassingDate = new DateTime(2015, 6, 6),
					Classes = new List<Class>()
					{
						entitiesMock.Object.Classes.ElementAt(9)
					}
				}
			});
            #endregion

            #region EducationalPlans
            entitiesMock.Setup(m => m.EducationalPlans).Returns(new List<EducationalPlan>
            {
                new EducationalPlan()
                {
                    Id = 1,
                    Group = entitiesMock.Object.Groups.ElementAt(0),
                    Semester = entitiesMock.Object.Semesters.ElementAt(0),
                    Subject = entitiesMock.Object.Subjects.ElementAt(0)
                },
                new EducationalPlan()
                {
                    Id = 2,
                    Group = entitiesMock.Object.Groups.ElementAt(0),
                    Semester = entitiesMock.Object.Semesters.ElementAt(0),
                    Subject = entitiesMock.Object.Subjects.ElementAt(1)
                },
                new EducationalPlan()
                {
                    Id = 3,
                    Group = entitiesMock.Object.Groups.ElementAt(1),
                    Semester = entitiesMock.Object.Semesters.ElementAt(0),
                    Subject = entitiesMock.Object.Subjects.ElementAt(2)
                },
                new EducationalPlan()
                {
                    Id = 4,
                    Group = entitiesMock.Object.Groups.ElementAt(1),
                    Semester = entitiesMock.Object.Semesters.ElementAt(0),
                    Subject = entitiesMock.Object.Subjects.ElementAt(3)
                },
                new EducationalPlan()
                {
                    Id = 5,
                    Group = entitiesMock.Object.Groups.ElementAt(1),
                    Semester = entitiesMock.Object.Semesters.ElementAt(0),
                    Subject = entitiesMock.Object.Subjects.ElementAt(4)
                },
                new EducationalPlan()
                {
                    Id = 6,
                    Group = entitiesMock.Object.Groups.ElementAt(1),
                    Semester = entitiesMock.Object.Semesters.ElementAt(0),
                    Subject = entitiesMock.Object.Subjects.ElementAt(5)
                },
                new EducationalPlan()
                {
                    Id = 7,
                    Group = entitiesMock.Object.Groups.ElementAt(0),
                    Semester = entitiesMock.Object.Semesters.ElementAt(0),
                    Subject = entitiesMock.Object.Subjects.ElementAt(6)
                }
            });
            #endregion

            #endregion

            //kernel.Bind<IDeaneryEntitiesRepository>().ToConstant(entitiesMock.Object);
			kernel.Bind<IDeaneryEntitiesRepository>().To<DeaneryEntitiesRepository>();  
            //---kernel.Bind<IUnitOfWork>().ToConstant(unitOfWorkMock.Object);
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
	}
}
