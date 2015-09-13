using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;
using DeanerySystem.WebUI.Models;

namespace DeanerySystem.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IEntitiesRepository repository;
        public HomeController(IEntitiesRepository entitiesRepository)
        {
            this.repository = entitiesRepository;
        }

        // GET: Home
        //public ActionResult Index()
        //{
        //    //StudentProfessorModel model = new StudentProfessorModel() { Students = repository.Students, Professors = repository.Professors };
        //    List<User> users = repository.Students.Cast<User>().ToList();
        //    users.AddRange(repository.Professors.Cast<User>());
        //    return View(users);
        //}

        public ActionResult Index()
        {
            return View(repository.Subjects.ToList());
        }

        public ActionResult Journal(int subjectId = 1, int journalId = 1, int actualJournalTypeId = 1)
        {
            Subject subject = repository.Subjects.First(s => s.Id == subjectId);
            List<DateTime> dates = GetDates(subjectId, journalId);
            
            List<JournalRecord> journalRecords = new List<JournalRecord>();

            int number = 1;
            foreach (var student in repository.Subjects.First(s => s.Id == subjectId).Group.Students)
            {
                string[] marks = new string[dates.Count];
                
                foreach (var cellule in repository.Subjects.First(s => s.Id == subjectId)
                    .Journals.First(j => j.Id == journalId)
                    .JournalsForMarking.First(j => j.Id == actualJournalTypeId).Cellules)
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
                SubjectId = subjectId,
                JournalId = journalId,

                AssessmentJournalId = repository.Journals.First(j => j.Id == journalId).JournalsForMarking.First(j => j.JournalType == JournalTypes.Assessment).Id,
                VisitingJournalId = repository.Journals.First(j => j.Id == journalId).JournalsForMarking.First(j => j.JournalType == JournalTypes.Visiting).Id,
                ActualJournalTypeId = actualJournalTypeId,

                SubjectName = subject.Name,
                GroupName = subject.Group.Name,
                ClassType = GetClassType(subject.Journals.First(j => j.Id == journalId).ClassType),
                //JournalType = actualJournalType,
                LecturerFirstName = subject.Journals.First(j => j.Id == journalId).Professor.FirstName,
                LecturerLastName = subject.Journals.First(j => j.Id == journalId).Professor.LastName,
                LecturerMiddleName = subject.Journals.First(j => j.Id == journalId).Professor.MiddleName,

                JournalRecords = journalRecords,
                Date = dates
            };

            return View(journalInfo);
        }

        private List<DateTime> GetDates(int subjectId, int journalId)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (var schedule in repository.Subjects.First(s => s.Id == subjectId).Journals.First(j => j.Id == journalId).TimeTables)
            {
                foreach (var lesson in schedule.ClassNumberTimes)
                {
                    bool isNumerator = true;
                    DateTime firstDate = repository.Subjects.First(s => s.Id == subjectId).Group.ActualSemester.DateOfBeginning;
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
                            lesson.TimeOfBeginning.Hours, lesson.TimeOfBeginning.Minutes, lesson.TimeOfBeginning.Seconds));
                    }
                    else
                    {
                        firstDate = (!isNumerator) ? firstDate : firstDate.AddDays(7);
                        dates.Add(new DateTime(firstDate.Year, firstDate.Month, firstDate.Day,
                            lesson.TimeOfBeginning.Hours, lesson.TimeOfBeginning.Minutes, lesson.TimeOfBeginning.Seconds));
                    }
                    for (DateTime date = firstDate.AddDays(14);
                        date < repository.Subjects.First().Group.ActualSemester.DateOfEndCreditSession;
                        date = date.AddDays(14))
                    {
                        dates.Add(new DateTime(date.Year, date.Month, date.Day,
                            lesson.TimeOfBeginning.Hours, lesson.TimeOfBeginning.Minutes, lesson.TimeOfBeginning.Seconds));
                    }
                }
            }
            dates.Sort();
            return dates;
        }
            
        [HttpPost]
        public void SaveMarkings(string marks, int subjectId, int journalId, int journalTypeId)
        {
            List<DateTime> dates = GetDates(subjectId, journalId);

            string[] str = marks.Split(new char[] {'=', '&'});
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
                    Cellule cellule = repository.Cellules.FirstOrDefault(c =>
                        c.Date == dates.ElementAt(columnId-1) &&
                        c.Student == repository.Subjects.First(s => s.Id == subjectId).Group.Students.ElementAt(rowId - 1));

                    if (cellule == null)
                    {
                        repository.Subjects.First(s => s.Id == subjectId)
                            .Journals.First(j => j.Id == journalId)
                            .JournalsForMarking.First(j => j.Id == journalTypeId)
                            .Cellules.Add(new Cellule()
                            {
                                Id = repository.Cellules.Last().Id + 1,
                                Date = dates.ElementAt(columnId - 1),
                                Student = repository.Subjects.First(s => s.Id == subjectId)
                                        .Group.Students.ElementAt(rowId - 1),
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

        private string GetClassType(ClassTypes classType)
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

        private string GetJournalType(JournalTypes journalType)
        {
            string ukrJournalType = "";
            switch (journalType)
            {
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