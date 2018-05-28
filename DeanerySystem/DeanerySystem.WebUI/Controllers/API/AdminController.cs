using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.WebUI.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DeanerySystem.WebUI.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
		private IUnitOfWork unitOfWork;
		public AdminController(IUnitOfWork unitOfWork) {
			this.unitOfWork = unitOfWork;
		}

		[HttpGet]
		[Route("universityData")]
		public UniversityModel GetUniversityData() {
			var university = unitOfWork.UniversityRepository.Get().FirstOrDefault();// ?? new Domain.Entities.University();

			var statisticsModel = new UniversityStatisticsModel() {
				FacultiesCount = 5,//university.Faculties.Count(),
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

			return universityModel;
		}
    }
}
