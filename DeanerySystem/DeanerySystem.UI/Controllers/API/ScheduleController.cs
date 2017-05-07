using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.UI.Models.Education.Schedule;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace DeanerySystem.UI.Controllers.API
{
	[RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
		private IDeaneryEntitiesRepository repository;

		public ScheduleController(IDeaneryEntitiesRepository deaneryEntitiesRepository) {
			this.repository = deaneryEntitiesRepository;
		}

		[HttpGet]
		[Route("getSchedule")]
		public IHttpActionResult GetSchedule() {
			var scheduleInfo = new ScheduleModel();

			var currentSemester = repository.Semesters.First();
			var educationalPlans = repository.EducationalPlans.Where(plan => plan.Semester == currentSemester);

			foreach (var plan in educationalPlans) {
				if (!scheduleInfo.Groups.Exists(group => group.Id == plan.Group.Id)) {
					scheduleInfo.Groups.Add(new GroupModel() { Id = plan.Group.Id, Name = plan.Group.Name });
				}

				foreach (var _class in plan.Subject.Classes) {
					foreach (var timeTable in _class.TimeTables) {
						var dayInfo = scheduleInfo.Days.SingleOrDefault(day => day.Id == timeTable.DayOfWeek);
						if (dayInfo == null) {
							string dayName = getUkrainianDay(timeTable.DayOfWeek);
							dayInfo = new DayModel(timeTable.DayOfWeek, dayName);
							scheduleInfo.Days.Add(dayInfo);
						}

						foreach (var time in timeTable.ClassNumberTimes) {
							var lessonNumberInfo = dayInfo.LessonNumbers.SingleOrDefault(ln => ln.Number == time.Number);
							if (lessonNumberInfo == null) {
								lessonNumberInfo = new LessonNumberModel(time.Number, time.Start, time.End);
								dayInfo.LessonNumbers.Add(lessonNumberInfo);
							}

							var lessonGroupInfo = lessonNumberInfo.LessonGroups.SingleOrDefault(lg => lg.GroupId == plan.Group.Id);
							if (lessonGroupInfo == null) {
								lessonGroupInfo = new LessonGroupModel() {
									GroupId = plan.Group.Id,
								};
								lessonNumberInfo.LessonGroups.Add(lessonGroupInfo);
							}

							LessonModel lessonInfo = new LessonModel() {
								Fraction = timeTable.Fraction,
								Lector = _class.Professor.GetFullName(),
								Subject = plan.Subject.Name,
								Type = getClassType(_class.ClassType),
								JournalLink = Url.Link("Default", new {
									Controller = "Education",
									Action = "JournalLink",
									educationalPlanId = plan.Id,
									classId = _class.Id
								})
							};

							lessonGroupInfo.Lessons.Add(lessonInfo);
						}
					}
				}
			}

			// fill in empty sells in between 
			foreach (var dayInfo in scheduleInfo.Days) {
				for (int i = dayInfo.LessonNumbers.Min(ln => ln.Number) + 1; i < dayInfo.LessonNumbers.Max(ln => ln.Number); i++) {
					if (!dayInfo.LessonNumbers.Any(ln => ln.Number == i)) {
						var time = repository.ClassNumberTimes.Single(numberTime => numberTime.Number == i);
						dayInfo.LessonNumbers.Add(new LessonNumberModel(time.Number, time.Start, time.End));
					}
				}
				dayInfo.LessonNumbers = dayInfo.LessonNumbers.OrderBy(ln => ln.Number).ToList();
			}

			return Json(scheduleInfo);
		}

		private string getUkrainianDay(DayOfWeek day) {
			switch (day) {
				case DayOfWeek.Monday: return "Понеділок";
				case DayOfWeek.Tuesday: return "Вівторок";
				case DayOfWeek.Wednesday: return "Середа";
				case DayOfWeek.Thursday: return "Четвер";
				case DayOfWeek.Friday: return "П'ятниця";
				case DayOfWeek.Saturday: return "Субота";
				case DayOfWeek.Sunday: return "Неділя";
				default: return String.Empty;
			}
		}

		private string getClassType(ClassTypes classType) {
			string ukrClassType = "";
			switch (classType) {
				case ClassTypes.Lecture:
					ukrClassType = "Лекція"; break;
				case ClassTypes.PracticalClass:
					ukrClassType = "Практична"; break;
				case ClassTypes.LaboratoryClass:
					ukrClassType = "Лабораторна";
					break;
			}
			return ukrClassType;
		}
	}
}
