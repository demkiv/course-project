﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DeanerySystem.Domain;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.UI.Models.Education.Schedule;
using DeanerySystem.WebUI.Models;
using Rotativa;
using Orientation = Rotativa.Options.Orientation;
using Schedule = DeanerySystem.UI.Models.Education.Schedule;

namespace DeanerySystem.UI.Controllers
{
	[Authorize]
    public class EducationController : Controller
    {
		private IUnitOfWork unitOfWork;
		public EducationController(IUnitOfWork unitOfWork) {
			this.unitOfWork = unitOfWork;
		}

		public ActionResult Schedule() {
			var scheduleInfo = new Schedule.ScheduleInfo();

			var currentSemester = this.unitOfWork.SemesterRepository.Get().First();
			var educationalPlans = this.unitOfWork.EducationalPlanRepository.Get().Where(plan => plan.Semester == currentSemester);

			foreach (var plan in educationalPlans) {
				if (!scheduleInfo.GroupNames.ContainsKey(plan.Group.Id)) {
					scheduleInfo.GroupNames.Add(plan.Group.Id, plan.Group.Name);
				}
				
                foreach (var _class in plan.Subject.Classes) {
					foreach (var timeTable in _class.TimeTables) {
						if (!scheduleInfo.DayInfos.ContainsKey(timeTable.DayOfWeek)) {
							string dayName = getUkrainianDay(timeTable.DayOfWeek);
                            scheduleInfo.DayInfos.Add(timeTable.DayOfWeek, new DayInfo(dayName));
						}
						var dayInfo = scheduleInfo.DayInfos[timeTable.DayOfWeek];
                        foreach (var time in timeTable.ClassNumberTimes) {
							if (!dayInfo.LessonNumberInfos.ContainsKey(time.Number)) {
								dayInfo.LessonNumberInfos.Add(time.Number, new LessonNumberInfo(time.Number, time.Start, time.End));
							}

							var lessonNumberInfo = dayInfo.LessonNumberInfos[time.Number];
							if (!lessonNumberInfo.LessonGroupInfos.ContainsKey(plan.Group.Id)) {
								lessonNumberInfo.LessonGroupInfos.Add(plan.Group.Id, new LessonGroupInfo() {
									IsSolid = timeTable.Fraction == Fractions.Integer
								});
							}

							var lessonGroupInfo = lessonNumberInfo.LessonGroupInfos[plan.Group.Id];
							LessonInfo lessonInfo = new LessonInfo() {
								Fraction = timeTable.Fraction,
								Lector = _class.Professor.GetFullName(),
								Subject = plan.Subject.Name,
								Type = getClassType(_class.ClassType),
                                JornalLink = Url.Action("JournalLink", "Education", new {
									educationalPlanId = plan.Id,
									classId = _class.Id
								})
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

			foreach (var dayInfo in scheduleInfo.DayInfos.Values) {
				for (int i = dayInfo.LessonNumberInfos.First().Key + 1; i < dayInfo.LessonNumberInfos.Last().Key; i++) {
					if (!dayInfo.LessonNumberInfos.ContainsKey(i)) {
						var time = this.unitOfWork.ClassNumberTimeRepository.Get().Single(numberTime => numberTime.Number == i);
                        dayInfo.LessonNumberInfos.Add(i, new LessonNumberInfo(time.Number, time.Start, time.End));
					}
				}
				
			}
			
            return View("Schedule/Schedule", scheduleInfo);
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

		public ActionResult JournalLink(int educationalPlanId, int classId) {
			var journalId = this.unitOfWork.ClassRepository.Get().First(c => c.Id == classId).Journals.First(j => j.JournalType == JournalTypes.Assessment).Id;
            return RedirectToAction("Journal", new { educationalPlanId, classId, journalId });
		}

		public ActionResult Journal(int educationalPlanId, int classId, int journalId) {
			var educationalPlan = this.unitOfWork.EducationalPlanRepository.Get().First(plan => plan.Id == educationalPlanId);
            Subject subject = educationalPlan.Subject;
			var _class = this.unitOfWork.ClassRepository.Get().First(c => c.Id == classId);
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
				ClassType = getClassType(_class.ClassType),
				
				LecturerFirstName = _class.Professor.FirstName,
				LecturerLastName = _class.Professor.LastName,
				LecturerMiddleName = _class.Professor.MiddleName,

				JournalRecords = journalRecords,
				Date = dates
			};

			return View(journalInfo);
		}

		public ActionResult JournalPrint(int educationalPlanId, int classId, int journalId) {
			var educationalPlan = this.unitOfWork.EducationalPlanRepository.Get().First(plan => plan.Id == educationalPlanId);
			Subject subject = educationalPlan.Subject;
			var _class = this.unitOfWork.ClassRepository.Get().First(c => c.Id == classId);
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
				ClassType = getClassType(_class.ClassType),

				LecturerFirstName = _class.Professor.FirstName,
				LecturerLastName = _class.Professor.LastName,
				LecturerMiddleName = _class.Professor.MiddleName,

				JournalRecords = journalRecords,
				Date = dates
			};

			return View(journalInfo);
		}
		public ActionResult PrintJournal(JournalInfo journal) 
		{
			Dictionary<string, string> cookieCollection = new Dictionary<string, string>();

			foreach (var key in Request.Cookies.AllKeys) {
				try {
					cookieCollection.Add(key, Request.Cookies.Get(key).Value);
				} catch{
					continue;
				}
				
			}
				return new ActionAsPdf("JournalPrint", journal) { FileName = journal.GroupName + "_" + journal.SubjectName + ".pdf", Cookies = cookieCollection, PageOrientation = Orientation.Landscape};
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
			var educationalPlan = unitOfWork.EducationalPlanRepository.Get().First(plan => plan.Id == educationalPlanId);
			var _class = this.unitOfWork.ClassRepository.Get().First(c => c.Id == classId);
			var journal = this.unitOfWork.JournalRepository.Get().First(j => j.Id == journalId);
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
					Cellule cellule = this.unitOfWork.CelluleRepository.Get().FirstOrDefault(c => c.Journal == journal
						&& c.Date == dates.ElementAt(columnId - 1) 
						&& c.Student == educationalPlan.Group.Students.ElementAt(rowId - 1));

					if (cellule == null) {
						journal.Cellules.Add(new Cellule() {
							Id = this.unitOfWork.CelluleRepository.Get().Last().Id + 1,
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