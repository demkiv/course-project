using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.WebUI.Models.Admin;
using DeanerySystem.WebUI.Providers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using DeanerySystem.BusinessLogic.UserImport;
using DeanerySystem.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace DeanerySystem.WebUI.Controllers
{
	[Authorize]
	public class AdminController : Controller
    {
		private IUnitOfWork unitOfWork;
		public AdminController(IUnitOfWork unitOfWork) 
		{
			this.unitOfWork = unitOfWork;
		}

		public IActionResult Index()
        {
			var university = unitOfWork.UniversityRepository.Get(includeProperties: "Faculties,Faculties.Streams,Faculties.Streams.Departments,Faculties.Streams.Departments.Professors,Faculties.Streams.Departments.Groups,Faculties.Streams.Departments.Groups.Students")
				.FirstOrDefault();

			var statisticsModel = new UniversityStatisticsModel() {
				FacultiesCount = university.Faculties.Count(),
				StreamsCount = UniversityProvider.GetStreams(university).Count(),
				DepartmentsCount = UniversityProvider.GetDepartments(university).Count(),
				GroupsCount = UniversityProvider.GetGroups(university).Count(),
				ProfessorsCount = UniversityProvider.GetProfessors(university).Count(),
				StudentsCount = UniversityProvider.GetStudents(university).Count()
			};

			var universityModel = new UniversityModel {
				Name = university.Name,
				UniversityStatisticsModel = statisticsModel
			};

			var rector = university.Rector;
			if (rector != null) {
				universityModel.RectorModel = new UserModel() {
					Id = rector.Id,
					FirstName = rector.FirstName,
					LastName = rector.LastName
				};
			}

			ViewData["data"] = JsonConvert.SerializeObject(universityModel);
			return View("Dashboard");
        }

        public IActionResult StudentAccounts()
        {
            var students = unitOfWork.StudentRepository.Get(includeProperties: "Group");
            var accounts = students.Select(student => new StudentModel()
            {
                Id = student.Id,
                StudentCardId = student.StudentCode,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                FirstNameEng = student.LatinFirstName,
                LastNameEng = student.LatinLastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,               
                Stream = student.Group.Department.Stream.Name,
                Group = student.Group.Name
            });
            ViewData["Data"] = JsonConvert.SerializeObject(accounts);
            return View();
        }

        public IActionResult ProfessorAccounts()
        {
            var accounts = unitOfWork.StudentRepository.Get(includeProperties: "Group").Select(student => new StudentModel()
            {
                Id = student.Id,
                StudentCardId = student.StudentCode,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                FirstNameEng = student.LatinFirstName,
                LastNameEng = student.LatinLastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                BirthDate = DateTime.Now,
                Stream = student.Group.Department.Stream.Name,
                Group = student.Group.Name
            });
            ViewData["Data"] = JsonConvert.SerializeObject(accounts);
            return View();
        }

		public ActionResult Faculties() {
			var faculties = unitOfWork.FacultyRepository.Get(includeProperties: "Streams");
			var facultiesModel = new Faculties();
			foreach (var faculty in faculties)
			{
				facultiesModel.FacultiesList.Add(new Models.Admin.Faculty()
				{
					Name = faculty.Name,
					DeanName = faculty.Dean?.GetFullName() ?? "",
					NumberOfStreams = faculty.Streams.Count()
				});
			}
			return View(facultiesModel);
		}

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImportFile(IFormFile file)
        {
            var students = new List<Student>();
            var filePath = Path.GetTempFileName();
            using (var stream = file.OpenReadStream())
            {
                var excelImporter = new ExcelImporter();
                var users = excelImporter.ImportData(stream);
                users.ForEach(student =>
                {
                    var studentEntity = this.GetStudentEntity(student);
                    this.unitOfWork.StudentRepository.Insert(studentEntity);
                    this.unitOfWork.Save();
                    students.Add(studentEntity);
                });
                var accounts = students.Select(student => this.GetStudentModel(student));
                ViewData["Data"] = JsonConvert.SerializeObject(accounts);
                return View("StudentAccounts");
            }
        }

        private Student GetStudentEntity(BusinessLogic.UserImport.Models.UserModel student)
        {
            var studentEntity = new Student()
            {
                StudentCode = student.StudentCardNumber,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                LatinFirstName = student.LatinFirstName,
                LatinLastName = student.LatinLastName,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email,
                UserName = student.Email,
                Group = this.unitOfWork.GroupRepository.GetById(1)
            };
            return studentEntity;
        }

        private StudentModel GetStudentModel(Student student)
        {
            var studentModel = new StudentModel()
            {
                Id = student.Id,
                StudentCardId = student.StudentCode,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                FirstNameEng = student.LatinFirstName,
                LastNameEng = student.LatinLastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                BirthDate = DateTime.Now,
                Stream = "Комп'ютерні науки",
                Group = student.Group.Name
            };
            return studentModel;
        }
    }
}
