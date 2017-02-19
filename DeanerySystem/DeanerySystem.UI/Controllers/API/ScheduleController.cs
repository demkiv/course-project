using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.UI.Models.Education.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

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
		[Route("json/{id}")]
		public IHttpActionResult GetJson(int id) 
		{
			return Json("Markiyasyk" + id);
		}

		[HttpGet]
		[Route("schedule")]
		public IHttpActionResult GetSchedule() {
			var scheduleInfo = new ScheduleModel();

			var currentSemester = repository.Semesters.First();
			var educationalPlans = repository.EducationalPlans.Where(plan => plan.Semester == currentSemester);

			foreach (var plan in educationalPlans) {
				if (!scheduleInfo.GroupModels.Exists(group => group.Id == plan.Group.Id)) {
					scheduleInfo.GroupModels.Add(new GroupModel() { Id = plan.Group.Id, Name = plan.Group.Name });
				}

				foreach (var _class in plan.Subject.Classes) {
					foreach (var timeTable in _class.TimeTables) {
						var dayInfo = scheduleInfo.DayModels.SingleOrDefault(day => day.DayOfWeek == timeTable.DayOfWeek);
						if (dayInfo == null) {
							string dayName = getUkrainianDay(timeTable.DayOfWeek);
							dayInfo = new DayModel(timeTable.DayOfWeek, dayName);
							scheduleInfo.DayModels.Add(dayInfo);
						}

						foreach (var time in timeTable.ClassNumberTimes) {
							var lessonNumberInfo = dayInfo.LessonNumberModels.SingleOrDefault(ln => ln.Number == time.Number);
							if (lessonNumberInfo == null) {
								lessonNumberInfo = new LessonNumberModel(time.Number, time.Start, time.End);
								dayInfo.LessonNumberModels.Add(lessonNumberInfo);
							}

							var lessonGroupInfo = lessonNumberInfo.LessonGroupModels.SingleOrDefault(lg => lg.GroupId == plan.Group.Id);
							if (lessonGroupInfo == null) {
								lessonGroupInfo = new LessonGroupModel() {
									GroupId = plan.Group.Id,
									IsSolid = timeTable.Fraction == Fractions.Integer
								};
								lessonNumberInfo.LessonGroupModels.Add(lessonGroupInfo);
							}


							LessonModel lessonInfo = new LessonModel() {
								Fraction = timeTable.Fraction,
								Lector = _class.Professor.GetFullName(),
								Subject = plan.Subject.Name,
								Type = getClassType(_class.ClassType),
								PlanId = plan.Id,
								ClassId = _class.Id
							};

							if (timeTable.Fraction == Fractions.Denominator) {
								lessonGroupInfo.SecondRowLesson = lessonInfo;
							} else {
								lessonGroupInfo.FirstRowLesson = lessonInfo;
							}
						}
					}
				}
			}

			// fill in empty sells in between 
			foreach (var dayInfo in scheduleInfo.DayModels) {
				for (int i = dayInfo.LessonNumberModels.Min(ln => ln.Number) + 1; i < dayInfo.LessonNumberModels.Max(ln => ln.Number); i++) {
					if (!dayInfo.LessonNumberModels.Any(ln => ln.Number == i)) {
						var time = repository.ClassNumberTimes.Single(numberTime => numberTime.Number == i);
						dayInfo.LessonNumberModels.Add(new LessonNumberModel(time.Number, time.Start, time.End));
					}
				}
				dayInfo.LessonNumberModels = dayInfo.LessonNumberModels.OrderBy(ln => ln.Number).ToList();
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
