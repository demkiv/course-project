using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.UI.Models.Education;
using DeanerySystem.UI.Models.Education.Schedule;
using DeanerySystem.WebUI.Models;
using Rotativa;
using Orientation = Rotativa.Options.Orientation;
using Schedule = DeanerySystem.UI.Models.Education.Schedule;
using ScheduleInfo = DeanerySystem.UI.Models.Education.ScheduleInfo;

namespace DeanerySystem.UI.Controllers
{
	[Authorize]
    public class EducationController : Controller
    {
		private IDeaneryEntitiesRepository repository;
		public EducationController(IDeaneryEntitiesRepository deaneryEntitiesRepository) {
			this.repository = deaneryEntitiesRepository;
		}

		public struct CellGenerationInfo {
			public Group Group { get; set; }
			public ClassNumberTime ClassNumberTime { get; set; }
		}

		public ActionResult Schedule() {
			var currentSemester = repository.Semesters.First();
			var educationalPlans = repository.EducationalPlans.Where(plan => plan.Semester == currentSemester);

			var times = new Dictionary<DayOfWeek, List<ClassNumberTime>>();
			var timeTables = new Dictionary<ClassNumberTime, List<TimeTable>>();
			var numeratorDenomerators = new Dictionary<Tuple<ClassNumberTime, Group>, NumeratorDenomerator>();

			var numberOfTimeTables = new Dictionary<TimeTable, List<ClassNumberTime>>();
			var numberOfTimes = new Dictionary<DayOfWeek, int>();

			foreach (var day in Enum.GetValues(typeof(DayOfWeek))) {
				times.Add((DayOfWeek)day, null);
				numberOfTimes.Add((DayOfWeek)day, 0);
			}

			foreach (var timeTable in repository.TimeTables) {
				numberOfTimeTables.Add(timeTable, null);
			}

			foreach (var time in repository.ClassNumberTimes) {
				timeTables.Add(time, null);
				//numeratorDenomerators.Add(time, null);
            }

			foreach (var plan in educationalPlans) {
				foreach (var _class in plan.Subject.Classes) {
					foreach (var timeTable in _class.TimeTables) {
						if (times[timeTable.DayOfWeek] == null) {
							times[timeTable.DayOfWeek] = new List<ClassNumberTime>();
						}

						if (numberOfTimeTables[timeTable] == null) {
							numberOfTimeTables[timeTable] = new List<ClassNumberTime>();
                        }
						
						foreach (var time in timeTable.ClassNumberTimes) {
							if (!times[timeTable.DayOfWeek].Contains(time)) {
								times[timeTable.DayOfWeek].Add(time);
							}

							if (timeTables[time] == null) {
								timeTables[time] = new List<TimeTable>();
							}

							if (timeTables[time].Count(t => t.Fraction == timeTable.Fraction) == 0) {
								timeTables[time].Add(timeTable);
							}

							Tuple<ClassNumberTime, Group> tuple = new Tuple<ClassNumberTime, Group>(time, plan.Group);
							if (!numeratorDenomerators.ContainsKey(tuple)) {
								numeratorDenomerators.Add(tuple, new NumeratorDenomerator());
							}

							if (timeTable.Fraction == Fractions.Numerator) {
								numeratorDenomerators[tuple].NumeratorTimeTable = timeTable;
								numeratorDenomerators[tuple].MergeSell = false;
                            } else {
								numeratorDenomerators[tuple].DenumeratorTimeTable = timeTable;
								numeratorDenomerators[tuple].MergeSell = false;
							}

							if (!numberOfTimeTables[timeTable].Contains(time)) {
								numberOfTimeTables[timeTable].Add(time);
								numberOfTimes[timeTable.DayOfWeek]++;
							}
						}
					}
				}
			}

			//times = new Dictionary<DayOfWeek, List<ClassNumberTime>>();
			//times = times.Where(pair => pair.Value != null)
			//		.OrderBy(pair => pair.Value.OrderBy(c => c.Number))
			//		.ToDictionary(pair => pair.Key, pair => pair.Value);

			var timesSorted = new Dictionary<DayOfWeek, List<ClassNumberTime>>();
			foreach (var time in times.Keys) {
				if (times[time] != null) {
					timesSorted.Add(time, times[time].OrderBy(t=>t.Number).ToList());
					//times[time] = times[time].OrderBy(c => c.Number).ToList();
				}
			}

			var timeTablesSorted = new Dictionary<ClassNumberTime, List<TimeTable>>();
			foreach (var timeTable in timeTables.Keys) {
				if (timeTables[timeTable] != null) {
					timeTablesSorted.Add(timeTable, timeTables[timeTable].OrderBy(t => t.Fraction).ToList());
					//times[time] = times[time].OrderBy(c => c.Number).ToList();
				}
			}

			foreach (var val in numeratorDenomerators) {
				Class numeratorClass = null;
				Class demumeratorClass = null;
				
				if (val.Value.NumeratorTimeTable != null) {
					val.Value.NumeratorPlan = educationalPlans.FirstOrDefault(plan => plan.Group == val.Key.Item2
						&& plan.Subject.Classes.Count(c => c.TimeTables.Count(t => t.ClassNumberTimes.Contains(val.Key.Item1) && t.Fraction == Fractions.Numerator) != 0) != 0);
					numeratorClass = val.Value.NumeratorPlan.Subject.Classes.First(c => c.TimeTables.Contains(val.Value.NumeratorTimeTable));
					// EducationalPlan educationalPlan = @Model.EducationalPlans.FirstOrDefault(plan => plan.Group == group
					//				&& plan.Subject.Classes.Count(c => c.TimeTables.Count(t => t.ClassNumberTimes.Contains(time)) != 0) != 0);
				}
				if (val.Value.DenumeratorTimeTable != null) {
					val.Value.DenumeratorPlan = educationalPlans.FirstOrDefault(plan => plan.Group == val.Key.Item2
						&& plan.Subject.Classes.Count(c => c.TimeTables.Count(t => t.ClassNumberTimes.Contains(val.Key.Item1) && t.Fraction == Fractions.Denominator) != 0) != 0);
					demumeratorClass = val.Value.DenumeratorPlan.Subject.Classes.First(c => c.TimeTables.Contains(val.Value.DenumeratorTimeTable));
					// EducationalPlan educationalPlan = @Model.EducationalPlans.FirstOrDefault(plan => plan.Group == group
					//				&& plan.Subject.Classes.Count(c => c.TimeTables.Count(t => t.ClassNumberTimes.Contains(time)) != 0) != 0);
				}

				
				if (numeratorClass == demumeratorClass) {
					val.Value.MergeSell = true;
				}
			}

			Dictionary<DayOfWeek, string> dayNames = new Dictionary<DayOfWeek, string>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek))) {
				dayNames.Add(day, getUkrainianDay(day));
			}

			return View(new ScheduleInfo() { Groups = repository.Groups.ToList(),
				TimeTables = timeTablesSorted,
				Times = timesSorted,
				NumeratorDenomerators = numeratorDenomerators,
                NumberOfTimes = numberOfTimes,
				DayNames = dayNames,
                EducationalPlans = educationalPlans.ToList() });
		}

		public ActionResult ScheduleNew() {
			var scheduleInfo = new Schedule.ScheduleInfo();

			var currentSemester = repository.Semesters.First();
			var educationalPlans = repository.EducationalPlans.Where(plan => plan.Semester == currentSemester);

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
						var time = repository.ClassNumberTimes.Single(numberTime => numberTime.Number == i);
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