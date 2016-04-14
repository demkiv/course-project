using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.WebUI.Models
{
    public class JournalInfo
    {
        public int EducationalPlanId { get; set; }
        public int ClassId { get; set; }
		public int JournalId { get; set; }
		public int AssessmentJournalId { get; set; }
        public int VisitingJournalId { get; set; }

        public string SubjectName { get; set; }
        public string ClassType { get; set; }
        public string GroupName { get; set; }

        //TODO add numberOfPastLessons and numberOfLessons

        public string LecturerFirstName { get; set; }
        public string LecturerLastName { get; set; }
        public string LecturerMiddleName { get; set; }

        public List<DateTime> Date { get; set; }
        public List<JournalRecord> JournalRecords { get; set; } 
    }
}