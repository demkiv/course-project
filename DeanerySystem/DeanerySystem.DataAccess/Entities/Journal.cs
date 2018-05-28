using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Abstract;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.Entities
{
    public class Journal : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public JournalTypes JournalType { get; set; }

        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<Cellule> Cellules { get; set; }
        public Journal()
        {
            this.Cellules = new List<Cellule>();
        }
    }
}
