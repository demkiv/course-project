using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class JournalForMarking
    {
        public int Id { get; set; }
        public JournalTypes JournalType { get; set; }

        public virtual Journal Journal { get; set; }
        public virtual ICollection<Cellule> Cellules { get; set; }
        public JournalForMarking()
        {
            this.Cellules = new List<Cellule>();
        }
    }
}
