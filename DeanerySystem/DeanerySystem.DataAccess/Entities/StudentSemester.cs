using System;
using System.Collections.Generic;
using System.Text;

namespace DeanerySystem.DataAccess.Entities
{
    public class StudentSemester
    {
        public Guid StudentId { get; set; }
        public int SemesterId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
