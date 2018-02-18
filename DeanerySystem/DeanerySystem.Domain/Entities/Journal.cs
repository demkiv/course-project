using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Abstract;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.Entities
{
    public class Journal : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public JournalTypes JournalType { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<Cellule> Cellules { get; set; }
        public Journal()
        {
            this.Cellules = new List<Cellule>();
        }
    }
}
