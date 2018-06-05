using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities.Enums;
using DeanerySystem.WebUI.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace DeanerySystem.WebUI.Controllers 
{
	[Authorize]
	public class EducationController : Controller 
	{
		private IUnitOfWork unitOfWork;
		public EducationController(IUnitOfWork unitOfWork) 
		{
			this.unitOfWork = unitOfWork;
		}

		public ActionResult Schedule() 
		{
			var currentSemester = unitOfWork.SemesterRepository.Get().First();
			var educationalPlans = unitOfWork.EducationalPlanRepository.Get(
				filter: plan => plan.Semester == currentSemester,
				includeProperties: "Group,Subject,Subject.Classes,Subject.Classes.Professor,Subject.Classes.TimeTables,Subject.Classes.TimeTables.ClassNumberTimes");
			var scheduleModel = ScheduleProvider.GetSchedule(educationalPlans, unitOfWork.ClassNumberTimeRepository.Get(), getJournalLink);
			ViewData["data"] = JsonConvert.SerializeObject(scheduleModel);
			return View();
		}

		private string getJournalLink(int planId, int classId) {
			return Url.Link("Default", new
			{
				Controller = "Education",
				Action = "JournalLink",
				educationalPlanId = planId,
				classId = classId
			});
		}

		public ActionResult JournalLink(int educationalPlanId, int classId) 
		{
			var journalId = this.unitOfWork.ClassRepository.Get(filter: c => c.Id == classId,
				includeProperties: "Journals").First().Journals.First(j => j.JournalType == JournalTypes.Assessment).Id;
			return RedirectToAction("Journal", new { educationalPlanId, classId, journalId });
		}

		public ActionResult Journal(int educationalPlanId, int classId, int journalId) 
		{
			var educationalPlan = this.unitOfWork.EducationalPlanRepository.Get(includeProperties: "Group,Group.Students,Semester,Subject")
				.First(plan => plan.Id == educationalPlanId);
			var _class = this.unitOfWork.ClassRepository.Get(includeProperties: "Professor,Journals,Journals.Cellules,TimeTables,TimeTables.ClassNumberTimes")
				.First(c => c.Id == classId);

			var journalInfo = JournalProvider.GenerateJournalInfo(educationalPlan, _class, journalId);
			return View(journalInfo);
		}

		public ActionResult JournalPrint(int educationalPlanId, int classId, int journalId) 
		{
			var educationalPlan = this.unitOfWork.EducationalPlanRepository.Get(includeProperties: "Group,Group.Students,Semester,Subject")
				.First(plan => plan.Id == educationalPlanId);
			var _class = this.unitOfWork.ClassRepository.Get(includeProperties: "Professor,Journals,Journals.Cellules,TimeTables,TimeTables.ClassNumberTimes")
				.First(c => c.Id == classId);

			var journalInfo = JournalProvider.GenerateJournalInfo(educationalPlan, _class, journalId);
			return View(journalInfo);
		}

		public ActionResult Assessment() {
			return View();
		}
	}
}
