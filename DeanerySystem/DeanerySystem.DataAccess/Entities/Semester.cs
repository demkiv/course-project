using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Abstract;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.Entities
{
    public class Semester : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime CreditSessionStart { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SecondWritingStart { get; set; }
        public DateTime ThirdWritingStart { get; set; }
        public DateTime End { get; set; }
        public SemesterNumber Number { get; set; }

        public virtual ICollection<EducationalPlan> EducationalPlans { get; set; }
        public virtual ICollection<StudentSemester> StudentSemesters { get; set; }

        public Semester()
        {
            this.EducationalPlans = new List<EducationalPlan>();
            this.StudentSemesters = new List<StudentSemester>();
        }
    }
}
