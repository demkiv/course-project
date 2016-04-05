using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities {
	public class SemesterEducationalPlan {
		public int Id { get; set; }

		public virtual Semester Semester { get; set; }
		public virtual Group Group { get; set; }
		public virtual ICollection<Subject> Subjects { get; set; }

		public SemesterEducationalPlan() {
			Subjects = new List<Subject>();
		}
	}
}
