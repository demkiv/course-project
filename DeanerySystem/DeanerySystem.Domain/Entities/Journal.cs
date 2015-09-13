using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Journal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ClassTypes ClassType { get; set; }
        //public JournalTypes JournalType { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<JournalForMarking> JournalsForMarking { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
        public Journal()
        {
            this.JournalsForMarking = new List<JournalForMarking>();
            this.TimeTables = new List<TimeTable>();
        }
    }
}
