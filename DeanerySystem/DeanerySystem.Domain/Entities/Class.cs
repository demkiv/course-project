using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ClassTypes ClassType { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
        public Class()
        {
            this.Journals = new List<Journal>();
            this.TimeTables = new List<TimeTable>();
        }
    }
}
