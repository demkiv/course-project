using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Entities.Enums;
using DeanerySystem.WebUI.Models;
using DeanerySystem.WebUI.Providers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeanerySystem.WebUI.Controllers 
{
	//[Authorize]
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
				includeProperties: "Group,Subject");
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
			var journalId = this.unitOfWork.ClassRepository.Get().First(c => c.Id == classId).Journals.First(j => j.JournalType == JournalTypes.Assessment).Id;
			return RedirectToAction("Journal", new { educationalPlanId, classId, journalId });
		}

		public ActionResult Journal(int educationalPlanId, int classId, int journalId) 
		{
			var educationalPlan = this.unitOfWork.EducationalPlanRepository.Get().First(plan => plan.Id == educationalPlanId);
			Subject subject = educationalPlan.Subject;
			var _class = this.unitOfWork.ClassRepository.Get().First(c => c.Id == classId);
			List<DateTime> dates = GetDates(educationalPlan, _class);

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
				EducationalPlanId = educationalPlanId,
				ClassId = classId,
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

			return View(journalInfo);
		}

		public ActionResult JournalPrint(int educationalPlanId, int classId, int journalId) 
		{
			var educationalPlan = this.unitOfWork.EducationalPlanRepository.Get().First(plan => plan.Id == educationalPlanId);
			Subject subject = educationalPlan.Subject;
			var _class = this.unitOfWork.ClassRepository.Get().First(c => c.Id == classId);
			List<DateTime> dates = GetDates(educationalPlan, _class);

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
				EducationalPlanId = educationalPlanId,
				ClassId = classId,
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

			return View(journalInfo);
		}

		private List<DateTime> GetDates(EducationalPlan educationalPlan, Class _class) 
		{
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

		[HttpPost]
		public void SaveMarkings(string marks, int educationalPlanId, int classId, int journalId) 
		{
			var educationalPlan = unitOfWork.EducationalPlanRepository.Get().First(plan => plan.Id == educationalPlanId);
			var _class = this.unitOfWork.ClassRepository.Get().First(c => c.Id == classId);
			var journal = this.unitOfWork.JournalRepository.Get().First(j => j.Id == journalId);
			List<DateTime> dates = GetDates(educationalPlan, _class);

			string[] str = marks.Split(new char[] { '=', '&' });
			List<string> temp = str.ToList();
			List<string> realMarks = temp.Where(s => s != "mark").ToList();

			int rowId = 1;
			int columnId = 1;

			foreach (var mark in realMarks)
			{
				if (dates.Count == columnId - 1)
				{
					columnId = 1;
					rowId++;
				}

				if (mark != String.Empty)
				{
					Cellule cellule = this.unitOfWork.CelluleRepository.Get().FirstOrDefault(c => c.Journal == journal
						&& c.Date == dates.ElementAt(columnId - 1)
						&& c.Student == educationalPlan.Group.Students.ElementAt(rowId - 1));

					if (cellule == null)
					{
						journal.Cellules.Add(new Cellule()
						{
							Id = this.unitOfWork.CelluleRepository.Get().Last().Id + 1,
							Date = dates.ElementAt(columnId - 1),
							Student = educationalPlan.Group.Students.ElementAt(rowId - 1),
							Mark = mark
						});
					}
					else
					{
						cellule.Mark = mark;
					}
				}

				columnId++;
			}
		}
	}
}
