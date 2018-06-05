using DeanerySystem.DataAccess.Entities;
using DeanerySystem.WebUI.Models.Education.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeanerySystem.WebUI.Providers
{
	public static class ScheduleProvider
	{
		public static ScheduleModel GetSchedule(IEnumerable<EducationalPlan> educationalPlans, 
			IEnumerable<ClassNumberTime> classNumberTimes, 
			Func<int, int, string> getJournalUrlCallback)
		{
			var schedule = new ScheduleModel();

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
								Lector = _class.Professor?.GetFullName() ?? "",
								Subject = plan.Subject.Name,
								Type = ResourcesProvider.GetClassTypeDisplay(_class.ClassType),
								JournalLink = getJournalUrlCallback(plan.Id, _class.Id)
							};

							lessonGroup.Lessons.Add(lesson);
						}
					}
				}
			}

			addMissingDayTimeNumbers(schedule, classNumberTimes);

			return schedule;
		}

		private static void addGroupNameIfNotExists(ScheduleModel schedule, Group group)
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

		private static DayModel getOrCreteDayModel(List<DayModel> days, TimeTable timeTable) {
			var day = days.SingleOrDefault(d => d.Id == timeTable.DayOfWeek);
			if (day == null)
			{
				string dayName = ResourcesProvider.GetWeekDayDisplay(timeTable.DayOfWeek);
				day = new DayModel(timeTable.DayOfWeek, dayName);
				days.Add(day);
			}
			return day;
		}

		private static LessonNumberModel getOrCreateLessonNumber(List<LessonNumberModel> lessonNumbers, ClassNumberTime time) {
			var lessonNumber = lessonNumbers.SingleOrDefault(ln => ln.Number == time.Number);
			if (lessonNumber == null)
			{
				lessonNumber = new LessonNumberModel(time.Number, time.Start, time.End);
				lessonNumbers.Add(lessonNumber);
			}
			return lessonNumber;
		}

		private static LessonGroupModel getOrCreateLessonGroup(List<LessonGroupModel> lessonGroups, Group group)
		{
			var lessonGroup = lessonGroups.SingleOrDefault(lg => lg.GroupId == group.Id);
			if (lessonGroup == null)
			{
				lessonGroup = new LessonGroupModel(group.Id);
				lessonGroups.Add(lessonGroup);
			}
			return lessonGroup;
		}
		
		/// <summary>
		/// If there is a gap between lessons in the schedule fills it in 
		/// with lessons time information without lesson data.
		/// </summary>
		private static void addMissingDayTimeNumbers(ScheduleModel schedule, IEnumerable<ClassNumberTime> classNumberTimes)
		{
			// fill in empty sells in between 
			foreach (var day in schedule.Days)
			{
				var lessonNumbers = day.LessonNumbers;
				for (int i = lessonNumbers.Min(ln => ln.Number) + 1; i < lessonNumbers.Max(ln => ln.Number); i++)
				{
					if (!lessonNumbers.Any(ln => ln.Number == i))
					{
						var time = classNumberTimes.Single(numberTime => numberTime.Number == i);
						lessonNumbers.Add(new LessonNumberModel(time.Number, time.Start, time.End));
					}
				}
			}
		}
	}
}
