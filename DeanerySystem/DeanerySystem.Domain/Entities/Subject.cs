using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfLectures { get; set; }
        public int NumberOfPracticalClasses { get; set; }
        public int NumberOflLaboratoryClasses { get; set; }
        public int NumberOfConsultations { get; set; }
        public SemesterControlTypes SemesterControl { get; set; }
        public DateTime? PassingDate { get; set; }

        public virtual ICollection<EducationalPlan> EducationalPlans { get; set; }
        public virtual ICollection<ProgressRecord> ProgressRecords { get; set; }
        public virtual ICollection<FailureTicket> FailureTickets { get; set; }
        public virtual ICollection<Class> Classes { get; set; }

        public Subject()
        {
			this.EducationalPlans = new List<EducationalPlan>();
            this.ProgressRecords = new List<ProgressRecord>();
            this.FailureTickets = new List<FailureTicket>();
            this.Classes = new List<Class>();
        }
    }
}
