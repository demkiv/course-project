using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.WebUI.Models.Admin;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace DeanerySystem.WebUI.Controllers
{
    public class AdminController : Controller
    {
		private IUnitOfWork unitOfWork;
		public AdminController(IUnitOfWork unitOfWork) 
		{
			this.unitOfWork = unitOfWork;
		}

		public IActionResult Index()
        {
			var university = unitOfWork.UniversityRepository.Get().FirstOrDefault();// ?? new Domain.Entities.University();

			var statisticsModel = new UniversityStatisticsModel() {
				FacultiesCount = university.Faculties.Count(),
				StreamsCount = 12, //UniversityProvider.GetStreams(university).Count(),
				DepartmentsCount = 28, //UniversityProvider.GetDepartments(university).Count(),
				GroupsCount = 56, //UniversityProvider.GetGroups(university).Count(),
				ProfessorsCount = 119, //UniversityProvider.GetProfessors(university).Count(),
				StudentsCount = 528 //UniversityProvider.GetStudents(university).Count(),
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
                BirthDate = DateTime.Now,
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
				facultiesModel.FacultiesList.Add(new Faculty()
				{
					Name = faculty.Name,
					DeanName = faculty.Dean?.GetFullName() ?? "",
					NumberOfStreams = faculty.Streams.Count()
				});
			}
			return View(facultiesModel);
		}
	}
}
