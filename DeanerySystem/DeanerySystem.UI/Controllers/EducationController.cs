using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.UI.Models.Education.Schedule;
using DeanerySystem.WebUI.Models;
using Rotativa;
using Orientation = Rotativa.Options.Orientation;

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
									IsSolid = timeTable.Fraction == Fractions.Integer
								};
								lessonNumberInfo.LessonGroups.Add(lessonGroupInfo);
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
			foreach (var dayInfo in scheduleInfo.Days) {
				for (int i = dayInfo.LessonNumbers.Min(ln => ln.Number) + 1; i < dayInfo.LessonNumbers.Max(ln => ln.Number); i++) {
					if (!dayInfo.LessonNumbers.Any(ln => ln.Number == i)) {
						var time = repository.ClassNumberTimes.Single(numberTime => numberTime.Number == i);
						dayInfo.LessonNumbers.Add(new LessonNumberModel(time.Number, time.Start, time.End));
					}
				}
				dayInfo.LessonNumbers = dayInfo.LessonNumbers.OrderBy(ln => ln.Number).ToList();
			}

			return View("Schedule/Schedule", scheduleInfo);
		}

		public ActionResult ScheduleNew() {
			return View("Schedule/ScheduleNew");
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
			var journalId = repository.Classes.First(c => c.Id == classId).Journals.First(j => j.JournalType == JournalTypes.Assessment).Id;
            return RedirectToAction("Journal", new { educationalPlanId, classId, journalId });
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