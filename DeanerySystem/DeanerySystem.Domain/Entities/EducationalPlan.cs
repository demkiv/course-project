using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities {
	public class EducationalPlan {
		public int Id { get; set; }

		public virtual Semester Semester { get; set; }
		public virtual Group Group { get; set; }
		public virtual Subject Subject { get; set; }
	}
}
