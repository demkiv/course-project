using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Semester
    {
        public int Id { get; set; }
        public DateTime DateOfBeginning { get; set; }
        public DateTime DateOfEnding { get; set; }
        public DateTime DateOfBeginCreditSession { get; set; }
        public DateTime DateOfEndCreditSession { get; set; }
        public DateTime DateOfBeginSession { get; set; }
        public DateTime DateOfEndSession { get; set; }
        public DateTime DateOfEndSecondWriting { get; set; }
        public DateTime DateOfEndThirdWriting { get; set; }
        // first or second
        public int Number { get; set; }

	    public virtual SemesterEducationalPlan SemesterEducationalPlan { get; set; }
	    public virtual ICollection<Student> Students { get; set; }

        public Semester()
        {
			this.Students = new List<Student>();
        }
    }
}
