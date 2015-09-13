using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSemesters { get; set; }
        public int CurrentSemester { get; set; }
        public Tuitions Tuition { get; set; }

        public virtual Department Department { get; set; }
        public virtual Professor Mentor { get; set; }
        public virtual Semester ActualSemester { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public Group()
        {
            this.Students = new List<Student>();
            this.Subjects = new List<Subject>();
        }
    }
}
