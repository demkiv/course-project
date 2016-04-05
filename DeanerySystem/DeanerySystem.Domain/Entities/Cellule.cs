using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Cellule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Mark { get; set; }

        public virtual Student Student { get; set; }
        public virtual JournalForMarking JournalForMarking { get; set; }
    }
}
