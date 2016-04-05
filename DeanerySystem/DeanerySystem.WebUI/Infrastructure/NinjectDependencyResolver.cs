using Ninject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using Moq;
using System.Web.Mvc;
using DeanerySystem.Domain;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Concrete;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.WebUI.Infrastructure
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
			Mock<IDeaneryEntitiesRepository> entitiesMock = new Mock<IDeaneryEntitiesRepository>();
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



			entitiesMock.Setup(m => m.Semesters).Returns(new List<Semester>
			{
				new Semester
				{
					Id = 1,
					Number = 2,
					DateOfBeginning = new DateTime(2015, 1, 22),
					DateOfEndCreditSession = new DateTime(2015, 6, 6)
				}
			});

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
				}
			});
			#endregion

			#region Groups
			entitiesMock.Setup(m => m.Groups).Returns(new List<Group>
			{
				new Group
				{
					Id = 1,
					Name = "ПМІ-31",
					CurrentSemester = 6,
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
					SemesterEducationalPlan = new SemesterEducationalPlan()
					{
						Semester = entitiesMock.Object.Semesters.ElementAt(0)
					}
				},
				new Group
				{
					Id = 2,
					Name = "ПМІ-32",
					CurrentSemester = 6,
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
					SemesterEducationalPlan = new SemesterEducationalPlan()
					{
						Semester = entitiesMock.Object.Semesters.ElementAt(0)
					}
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
					TimeOfBeginning = new TimeSpan(0, 8, 30, 0, 0),
					TimeOfEnding = new TimeSpan(0, 9, 50, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 2,
					Number = 2,
					TimeOfBeginning = new TimeSpan(0, 10, 10, 0, 0),
					TimeOfEnding = new TimeSpan(0, 11, 30, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 3,
					Number = 3,
					TimeOfBeginning = new TimeSpan(0, 11, 50, 0, 0),
					TimeOfEnding = new TimeSpan(0, 13, 10, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 4,
					Number = 4,
					TimeOfBeginning = new TimeSpan(0, 13, 30, 0, 0),
					TimeOfEnding = new TimeSpan(0, 14, 50, 0, 0)
				},
				new ClassNumberTime()
				{
					Id = 5,
					Number = 5,
					TimeOfBeginning = new TimeSpan(0, 15, 15, 0, 0),
					TimeOfEnding = new TimeSpan(0, 16, 25, 0, 0)
				}
			});
			#endregion

			#region TimeTables
			entitiesMock.Setup(m => m.TimeTables).Returns(new List<TimeTable>
			{
				new TimeTable
				{
					Id = 1,
					DayOfWeek = DayOfWeek.Tuesday,
					Fraction = Fractions.Numerator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(3),
						entitiesMock.Object.ClassNumberTimes.ElementAt(4)
					}
				},
				new TimeTable
				{
					Id = 2,
					DayOfWeek = DayOfWeek.Tuesday,
					Fraction = Fractions.Denominator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(3),
						entitiesMock.Object.ClassNumberTimes.ElementAt(4)
					}
				},
				new TimeTable
				{
					Id = 3,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Numerator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(1)
					}
				},
				new TimeTable
				{
					Id = 4,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Denominator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(1)
					}
				},
				new TimeTable
				{
					Id = 5,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Numerator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(2)
					}
				},
				new TimeTable
				{
					Id = 6,
					DayOfWeek = DayOfWeek.Monday,
					Fraction = Fractions.Denominator,
					ClassNumberTimes = new List<ClassNumberTime>
					{
						entitiesMock.Object.ClassNumberTimes.ElementAt(2)
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

			#region JournalsForMarking
			entitiesMock.Setup(m => m.JournalsForMarking).Returns(new List<JournalForMarking>
			{
				new JournalForMarking
				{
					Id = 1,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
						entitiesMock.Object.Cellules.ElementAt(0),
						entitiesMock.Object.Cellules.ElementAt(1),
						entitiesMock.Object.Cellules.ElementAt(2),
						entitiesMock.Object.Cellules.ElementAt(3),
						entitiesMock.Object.Cellules.ElementAt(4),
						entitiesMock.Object.Cellules.ElementAt(5),
						entitiesMock.Object.Cellules.ElementAt(6)
					}
				},
				new JournalForMarking
				{
					Id = 2,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new JournalForMarking
				{
					Id = 3,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new JournalForMarking
				{
					Id = 4,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new JournalForMarking
				{
					Id = 5,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new JournalForMarking
				{
					Id = 6,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new JournalForMarking
				{
					Id = 7,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new JournalForMarking
				{
					Id = 8,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				},
				new JournalForMarking
				{
					Id = 9,
					JournalType = JournalTypes.Assessment,
					Cellules = new List<Cellule>()
					{
					},
				},
				new JournalForMarking
				{
					Id = 10,
					JournalType = JournalTypes.Visiting,
					Cellules = new List<Cellule>()
					{
					},
				}
			});
			#endregion

			#region Journals
			entitiesMock.Setup(m => m.Journals).Returns(new List<Journal>
			{
				new Journal
				{
					Id = 1,
					ClassType = ClassTypes.PracticalClass,
					Professor = entitiesMock.Object.Professors.ElementAt(1),
					JournalsForMarking = new List<JournalForMarking>
					{
						entitiesMock.Object.JournalsForMarking.ElementAt(0),
						entitiesMock.Object.JournalsForMarking.ElementAt(1)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(0),
						entitiesMock.Object.TimeTables.ElementAt(1)
					}
				},
				new Journal
				{
					Id = 2,
					ClassType = ClassTypes.Lecture,
					Professor = entitiesMock.Object.Professors.ElementAt(3),
					JournalsForMarking = new List<JournalForMarking>
					{
						entitiesMock.Object.JournalsForMarking.ElementAt(2),
						entitiesMock.Object.JournalsForMarking.ElementAt(3)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(2),
						entitiesMock.Object.TimeTables.ElementAt(3)
					}
				},
				new Journal
				{
					Id = 3,
					ClassType = ClassTypes.Lecture,
					Professor = entitiesMock.Object.Professors.ElementAt(3),
					JournalsForMarking = new List<JournalForMarking>
					{
						entitiesMock.Object.JournalsForMarking.ElementAt(4),
						entitiesMock.Object.JournalsForMarking.ElementAt(5)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(2),
						entitiesMock.Object.TimeTables.ElementAt(3)
					}
				},
				new Journal
				{
					Id = 4,
					ClassType = ClassTypes.Lecture,
					Professor = entitiesMock.Object.Professors.ElementAt(4),
					JournalsForMarking = new List<JournalForMarking>
					{
						entitiesMock.Object.JournalsForMarking.ElementAt(6),
						entitiesMock.Object.JournalsForMarking.ElementAt(7)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(4),
						entitiesMock.Object.TimeTables.ElementAt(5)
					}
				},
				new Journal
				{
					Id = 5,
					ClassType = ClassTypes.Lecture,
					Professor = entitiesMock.Object.Professors.ElementAt(4),
					JournalsForMarking = new List<JournalForMarking>
					{
						entitiesMock.Object.JournalsForMarking.ElementAt(8),
						entitiesMock.Object.JournalsForMarking.ElementAt(9)
					},
					TimeTables = new List<TimeTable>
					{
						entitiesMock.Object.TimeTables.ElementAt(4),
						entitiesMock.Object.TimeTables.ElementAt(5)
					}
				},
			});
			#endregion

			entitiesMock.Setup(m => m.SemesterEducationalPlans).Returns(new List<SemesterEducationalPlan> 
			{
				new SemesterEducationalPlan()
				{
					Group = entitiesMock.Object.Groups.ElementAt(0),
					Semester = entitiesMock.Object.Semesters.ElementAt(0)
				},
				new SemesterEducationalPlan()
				{
					Group = entitiesMock.Object.Groups.ElementAt(1),
					Semester = entitiesMock.Object.Semesters.ElementAt(0)
				}
			});

			entitiesMock.Setup(m => m.Subjects).Returns(new List<Subject>
			{
				new Subject
				{
					Id = 1,
					Name = "Адміністрування корпоративних систем",
					SemesterControl = SemesterControlTypes.Credit,
					NumberOfConsultations = 0,
					NumberOfLectures = 0,
					NumberOfPracticalClasses = 17,
					NumberOflLaboratoryClasses = 0,
					PassingDate = new DateTime(2015, 6, 6),
					SemesterEducationalPlan = entitiesMock.Object.SemesterEducationalPlans.ElementAt(0),
					Journals = new List<Journal>()
					{
						entitiesMock.Object.Journals.ElementAt(0)
					}
				},
                // PMI-31 Monday Numerator, Denominator
                new Subject
				{
					Id = 2,
					Name = "Комп'ютерні мережі",
					SemesterControl = SemesterControlTypes.Credit,
					PassingDate = new DateTime(2015, 6, 6),
					SemesterEducationalPlan = entitiesMock.Object.SemesterEducationalPlans.ElementAt(0),
					Journals = new List<Journal>()
					{
						entitiesMock.Object.Journals.ElementAt(1)
					}
				},
                // PMI-32 Monday Numerator, Denominator
                new Subject
				{
					Id = 3,
					Name = "Комп'ютерні мережі",
					SemesterControl = SemesterControlTypes.Credit,
					PassingDate = new DateTime(2015, 6, 6),
					SemesterEducationalPlan = entitiesMock.Object.SemesterEducationalPlans.ElementAt(1),
					Journals = new List<Journal>()
					{
						entitiesMock.Object.Journals.ElementAt(2)
					}
				},
				new Subject
				{
					Id = 4,
					Name = "Методи оптимізації",
					SemesterControl = SemesterControlTypes.Exam,
					PassingDate = new DateTime(2015, 6, 6),
					SemesterEducationalPlan = entitiesMock.Object.SemesterEducationalPlans.ElementAt(0),
					Journals = new List<Journal>()
					{
						entitiesMock.Object.Journals.ElementAt(3)
					}
				},
				new Subject
				{
					Id = 5,
					Name = "Методи оптимізації",
					SemesterControl = SemesterControlTypes.Exam,
					PassingDate = new DateTime(2015, 6, 6),
					SemesterEducationalPlan = entitiesMock.Object.SemesterEducationalPlans.ElementAt(1),
					Journals = new List<Journal>()
					{
						entitiesMock.Object.Journals.ElementAt(4)
					}
				},
			});

			kernel.Bind<IDeaneryEntitiesRepository>().ToConstant(entitiesMock.Object);
			//kernel.Bind<IDeaneryEntitiesRepository>().To<DeaneryEntitiesRepository>();   
		}

	}
}