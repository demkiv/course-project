using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Entities.Enums;
using DeanerySystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeanerySystem.WebUI.Providers
{
    public static class JournalProvider
    {
		public static JournalInfo GenerateJournalInfo(EducationalPlan educationalPlan, Class _class, int journalId) {
			Subject subject = educationalPlan.Subject;
			List<DateTime> dates = JournalProvider.GetDates(educationalPlan, _class);
			List<JournalRecord> journalRecords = new List<JournalRecord>();

			int number = 1;
			foreach (var student in educationalPlan.Group.Students)
			{
				string[] marks = new string[dates.Count];

				foreach (var cellule in _class.Journals.First(j => j.Id == journalId).Cellules)
				{
					if (cellule.Student == student)
					{
						marks[dates.IndexOf(cellule.Date)] = cellule.Mark;
					}
				}

				journalRecords.Add(new JournalRecord()
				{
					StudentFirstName = student.FirstName,
					StudentLastName = student.LastName,
					StudentMiddleName = student.MiddleName,
					Number = number,
					Marks = marks.ToList()
				});
				number++;
			}

			JournalInfo journalInfo = new JournalInfo
			{
				EducationalPlanId = educationalPlan.Id,
				ClassId = _class.Id,
				JournalId = journalId,

				AssessmentJournalId = _class.Journals.First(j => j.JournalType == JournalTypes.Assessment).Id,
				VisitingJournalId = _class.Journals.First(j => j.JournalType == JournalTypes.Visiting).Id,

				AssessmentJournalName = ResourcesProvider.GetJournalTypeDisplay(JournalTypes.Assessment),
				VisitingJournalName = ResourcesProvider.GetJournalTypeDisplay(JournalTypes.Visiting),

				SubjectName = subject.Name,
				GroupName = educationalPlan.Group.Name,
				ClassType = ResourcesProvider.GetClassTypeDisplay(_class.ClassType),

				LecturerFirstName = _class.Professor.FirstName,
				LecturerLastName = _class.Professor.LastName,
				LecturerMiddleName = _class.Professor.MiddleName,

				JournalRecords = journalRecords,
				Date = dates
			};
			return journalInfo;
		}

		public static List<DateTime> GetDates(EducationalPlan educationalPlan, Class _class) {
			List<DateTime> dates = new List<DateTime>();
			foreach (var schedule in _class.TimeTables)
			{
				foreach (var lesson in schedule.ClassNumberTimes)
				{
					bool isNumerator = true;
					DateTime firstDate = educationalPlan.Semester.Start;
					while (firstDate.DayOfWeek != schedule.DayOfWeek)
					{
						if (firstDate.DayOfWeek == DayOfWeek.Sunday)
						{
							isNumerator = false;
						}
						firstDate = firstDate.AddDays(1);
					}
					if (schedule.Fraction == Fractions.Numerator)
					{
						firstDate = (isNumerator) ? firstDate : firstDate.AddDays(7);
						dates.Add(new DateTime(firstDate.Year, firstDate.Month, firstDate.Day,
							lesson.Start.Hours, lesson.Start.Minutes, lesson.Start.Seconds));
					}
					else
					{
						firstDate = (!isNumerator) ? firstDate : firstDate.AddDays(7);
						dates.Add(new DateTime(firstDate.Year, firstDate.Month, firstDate.Day,
							lesson.Start.Hours, lesson.Start.Minutes, lesson.Start.Seconds));
					}
					for (DateTime date = firstDate.AddDays(14);
						date < educationalPlan.Semester.CreditSessionStart;
						date = date.AddDays(14))
					{
						dates.Add(new DateTime(date.Year, date.Month, date.Day,
							lesson.Start.Hours, lesson.Start.Minutes, lesson.Start.Seconds));
					}
				}
			}
			dates.Sort();
			return dates;
		}
	}
}
