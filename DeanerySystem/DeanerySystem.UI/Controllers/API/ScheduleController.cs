using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.UI.Models.Education.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace DeanerySystem.UI.Controllers.API
{
	[RoutePrefix("api/schedule")]
	public class ScheduleController : ApiController
	{
		private IDeaneryEntitiesRepository repository;

		public ScheduleController(IDeaneryEntitiesRepository deaneryEntitiesRepository)
		{
			this.repository = deaneryEntitiesRepository;
		}

		[HttpGet]
		[Route("getSchedule")]
		public IHttpActionResult GetSchedule()
		{
			var schedule = new ScheduleModel();

			var currentSemester = repository.Semesters.First();
			var educationalPlans = repository.EducationalPlans.Where(plan => plan.Semester == currentSemester);

			foreach (var plan in educationalPlans)
			{
				addGroupNameIfNotExists(schedule, plan.Group);

				foreach (var _class in plan.Subject.Classes)
				{
					foreach (var timeTable in _class.TimeTables)
					{
						var day = getOrCreteDayModel(schedule.Days, timeTable);

						foreach (var time in timeTable.ClassNumberTimes)
						{
							var lessonNumber = getOrCreateLessonNumber(day.LessonNumbers, time);
							var lessonGroup = getOrCreateLessonGroup(lessonNumber.LessonGroups, plan.Group);

							LessonModel lesson = new LessonModel()
							{
								Fraction = timeTable.Fraction,
								Lector = _class.Professor.GetFullName(),
								Subject = plan.Subject.Name,
								Type = getClassType(_class.ClassType),
								JournalLink = getJournalLink(plan.Id, _class.Id)
							};

							lessonGroup.Lessons.Add(lesson);
						}
					}
				}
			}

			addMissingDayTimeNumbers(schedule);

			return Json(schedule);
		}

		private void addGroupNameIfNotExists(ScheduleModel schedule, Group group)
		{
			if (!schedule.Groups.Exists(g => g.Id == group.Id))
			{
				schedule.Groups.Add(new GroupModel()
				{
					Id = group.Id,
					Name = group.Name
				});
			}
		}

		private DayModel getOrCreteDayModel(List<DayModel> days, TimeTable timeTable) {
			var day = days.SingleOrDefault(d => d.Id == timeTable.DayOfWeek);
			if (day == null)
			{
				string dayName = getUkrainianDay(timeTable.DayOfWeek);
				day = new DayModel(timeTable.DayOfWeek, dayName);
				days.Add(day);
			}
			return day;
		}

		private LessonNumberModel getOrCreateLessonNumber(List<LessonNumberModel> lessonNumbers, ClassNumberTime time) {
			var lessonNumber = lessonNumbers.SingleOrDefault(ln => ln.Number == time.Number);
			if (lessonNumber == null)
			{
				lessonNumber = new LessonNumberModel(time.Number, time.Start, time.End);
				lessonNumbers.Add(lessonNumber);
			}
			return lessonNumber;
		}

		private LessonGroupModel getOrCreateLessonGroup(List<LessonGroupModel> lessonGroups, Group group)
		{
			var lessonGroup = lessonGroups.SingleOrDefault(lg => lg.GroupId == group.Id);
			if (lessonGroup == null)
			{
				lessonGroup = new LessonGroupModel(group.Id);
				lessonGroups.Add(lessonGroup);
			}
			return lessonGroup;
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

		/// <summary>
		/// If there is a gap between lessons in the schedule fills it in 
		/// with lessons time information without lesson data.
		/// </summary>
		private void addMissingDayTimeNumbers(ScheduleModel schedule)
		{
			// fill in empty sells in between 
			foreach (var day in schedule.Days)
			{
				var lessonNumbers = day.LessonNumbers;
				for (int i = lessonNumbers.Min(ln => ln.Number) + 1; i < lessonNumbers.Max(ln => ln.Number); i++)
				{
					if (!lessonNumbers.Any(ln => ln.Number == i))
					{
						var time = repository.ClassNumberTimes.Single(numberTime => numberTime.Number == i);
						lessonNumbers.Add(new LessonNumberModel(time.Number, time.Start, time.End));
					}
				}
			}
		}

		private string getUkrainianDay(DayOfWeek day)
		{
			switch (day)
			{
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

		private string getClassType(ClassTypes classType)
		{
			string ukrClassType = "";
			switch (classType)
			{
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
