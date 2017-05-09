using DeanerySystem.Domain;
using DeanerySystem.UI.Providers;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace DeanerySystem.UI.Controllers.API
{
	[RoutePrefix("api/schedule")]
	public class ScheduleController : ApiController
	{
		private IUnitOfWork unitOfWork;
		public ScheduleController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		[HttpGet]
		[Route("getSchedule")]
		public IHttpActionResult GetSchedule()
		{
			var currentSemester = unitOfWork.SemesterRepository.Get().First();
			var educationalPlans = unitOfWork.EducationalPlanRepository.Get().Where(plan => plan.Semester == currentSemester);

			return Json(ScheduleProvider.GetSchedule(educationalPlans, unitOfWork.ClassNumberTimeRepository.Get(), getJournalLink));
		}

		private string getJournalLink(int planId, int classId)
		{
			return Url.Link("Default", new
			{
				Controller = "Education",
				Action = "JournalLink",
				educationalPlanId = planId,
				classId = classId
			});
		}
	}
}
