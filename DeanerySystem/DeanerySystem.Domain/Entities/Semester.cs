using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.Entities
{
    public class Semester
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
	    public virtual ICollection<Student> Students { get; set; }

        public Semester()
        {
			this.EducationalPlans = new List<EducationalPlan>();
            this.Students = new List<Student>();
        }
    }
}
