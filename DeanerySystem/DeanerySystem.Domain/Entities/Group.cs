using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Tuitions Tuition { get; set; }

        public virtual Department Department { get; set; }
        public virtual Professor Mentor { get; set; }
	    public virtual ICollection<EducationalPlan> EducationalPlans { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public Group()
        {
			this.EducationalPlans = new List<EducationalPlan>();
            this.Students = new List<Student>();
        }
    }
}
