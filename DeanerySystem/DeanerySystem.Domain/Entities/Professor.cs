using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Professor : User
    {
        public Positions Position { get; set; }

        public virtual Department Department { get; set; }
        public virtual Faculty DeanFaculty { get; set; }
        public virtual Department HeadDepartment { get; set; }
        public virtual Group MentorGroup { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
        public Professor()
        {
            this.Journals = new List<Journal>();
        }
    }
}
