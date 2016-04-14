﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.UI.Models.Education;
using DeanerySystem.WebUI.Models;

namespace DeanerySystem.UI.Controllers
{
	[Authorize]
    public class EducationController : Controller
    {
		private IDeaneryEntitiesRepository repository;
		public EducationController(IDeaneryEntitiesRepository deaneryEntitiesRepository) {
			this.repository = deaneryEntitiesRepository;
		}

		public ActionResult Schedule() {
			var currentSemester = repository.Semesters.First();
			var educationalPlans = repository.EducationalPlans.Where(plan => plan.Semester == currentSemester);

			var times = new Dictionary<DayOfWeek, List<ClassNumberTime>>();
			var numberOfTimes = new Dictionary<DayOfWeek, int>();

			foreach (var day in Enum.GetValues(typeof(DayOfWeek))) {
				times.Add((DayOfWeek)day, null);
				numberOfTimes.Add((DayOfWeek)day, 0);
            }

			foreach (var plan in educationalPlans) {
	            foreach (var _class in plan.Subject.Classes) {
		            foreach (var timeTable in _class.TimeTables) {
						foreach (var time in timeTable.ClassNumberTimes) {
							if (times[timeTable.DayOfWeek] == null) {
								times[timeTable.DayOfWeek] = new List<ClassNumberTime>();
							}
							if (!times[timeTable.DayOfWeek].Contains(time)) {
								times[timeTable.DayOfWeek].Add(time);
								numberOfTimes[timeTable.DayOfWeek]++;
							}
						}
                    }
	            }
			}

			//times = times.Where(pair => pair.Value != null)
			//		.OrderBy(pair => pair.Value.OrderBy(c => c.Number))
			//		.ToDictionary(pair => pair.Key, pair => pair.Value);

			return View(new ScheduleInfo() { Groups = repository.Groups.ToList(),
				Times = times,
				NumberOfTimes = numberOfTimes,
                EducationalPlans = educationalPlans.ToList() });
		}

		public ActionResult Journal(int educationalPlanId, int classId, int journalId) {
			var educationalPlan = repository.EducationalPlans.First(plan => plan.Id == educationalPlanId);
            Subject subject = educationalPlan.Subject;
			var _class = repository.Classes.First(c => c.Id == classId);
			List<DateTime> dates = GetDates(educationalPlan, _class);

			List<JournalRecord> journalRecords = new List<JournalRecord>();

			int number = 1;
			foreach (var student in educationalPlan.Group.Students) {
				string[] marks = new string[dates.Count];

				foreach (var cellule in _class.Journals.First(j => j.Id == journalId).Cellules) {
					if (cellule.Student == student) {
						marks[dates.IndexOf(cellule.Date)] = cellule.Mark;
					}
				}

				journalRecords.Add(new JournalRecord() {
					StudentFirstName = student.FirstName,
					StudentLastName = student.LastName,
					StudentMiddleName = student.MiddleName,
					Number = number,
					Marks = marks.ToList()
				});
				number++;
			}

			JournalInfo journalInfo = new JournalInfo {
				EducationalPlanId = educationalPlanId,
				ClassId = classId,
				JournalId = journalId,

				AssessmentJournalId = _class.Journals.First(j => j.JournalType == JournalTypes.Assessment).Id,
				VisitingJournalId = _class.Journals.First(j => j.JournalType == JournalTypes.Visiting).Id,

				SubjectName = subject.Name,
				GroupName = educationalPlan.Group.Name,
				ClassType = GetClassType(_class.ClassType),
				
				LecturerFirstName = _class.Professor.FirstName,
				LecturerLastName = _class.Professor.LastName,
				LecturerMiddleName = _class.Professor.MiddleName,

				JournalRecords = journalRecords,
				Date = dates
			};

			return View(journalInfo);
		}

		private List<DateTime> GetDates(EducationalPlan educationalPlan, Class _class) {
			List<DateTime> dates = new List<DateTime>();
			foreach (var schedule in _class.TimeTables) {
				foreach (var lesson in schedule.ClassNumberTimes) {
					bool isNumerator = true;
					DateTime firstDate = educationalPlan.Semester.Start;
					while (firstDate.DayOfWeek != schedule.DayOfWeek) {
						if (firstDate.DayOfWeek == DayOfWeek.Sunday) {
							isNumerator = false;
						}
						firstDate = firstDate.AddDays(1);
					}
					if (schedule.Fraction == Fractions.Numerator) {
						firstDate = (isNumerator) ? firstDate : firstDate.AddDays(7);
						dates.Add(new DateTime(firstDate.Year, firstDate.Month, firstDate.Day,
							lesson.Start.Hours, lesson.Start.Minutes, lesson.Start.Seconds));
					} else {
						firstDate = (!isNumerator) ? firstDate : firstDate.AddDays(7);
						dates.Add(new DateTime(firstDate.Year, firstDate.Month, firstDate.Day,
							lesson.Start.Hours, lesson.Start.Minutes, lesson.Start.Seconds));
					}
					for (DateTime date = firstDate.AddDays(14);
						date < educationalPlan.Semester.CreditSessionStart;
						date = date.AddDays(14)) {
						dates.Add(new DateTime(date.Year, date.Month, date.Day,
							lesson.Start.Hours, lesson.Start.Minutes, lesson.Start.Seconds));
					}
				}
			}
			dates.Sort();
			return dates;
		}

		[HttpPost]
		public void SaveMarkings(string marks, int educationalPlanId, int classId, int journalId) {
			var educationalPlan = repository.EducationalPlans.First(plan => plan.Id == educationalPlanId);
			var _class = repository.Classes.First(c => c.Id == classId);
			var journal = repository.Journals.First(j => j.Id == journalId);
			List<DateTime> dates = GetDates(educationalPlan, _class);

			string[] str = marks.Split(new char[] { '=', '&' });
			List<string> temp = str.ToList();
			List<string> realMarks = temp.Where(s => s != "mark").ToList();

			int rowId = 1;
			int columnId = 1;

			foreach (var mark in realMarks) {
				if (dates.Count == columnId - 1) {
					columnId = 1;
					rowId++;
				}

				if (mark != String.Empty) {
					Cellule cellule = repository.Cellules.FirstOrDefault(c => c.Journal == journal
						&& c.Date == dates.ElementAt(columnId - 1) 
						&& c.Student == educationalPlan.Group.Students.ElementAt(rowId - 1));

					if (cellule == null) {
						journal.Cellules.Add(new Cellule() {
							Id = repository.Cellules.Last().Id + 1,
							Date = dates.ElementAt(columnId - 1),
							Student = educationalPlan.Group.Students.ElementAt(rowId - 1),
							Mark = mark
						});
					} else {
						cellule.Mark = mark;
					}
				}

				columnId++;
			}
		}

		private string GetClassType(ClassTypes classType) {
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

		private string GetJournalType(JournalTypes journalType) {
			string ukrJournalType = "";
			switch (journalType) {
				case JournalTypes.Assessment:
					ukrJournalType = "Оцінювання";
					break;
				case JournalTypes.Visiting:
					ukrJournalType = "Відвідування";
					break;
			}
			return ukrJournalType;
		}
	}
}