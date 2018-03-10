using System;
using DeanerySystem.DataAccess.Entities.Abstract;

namespace DeanerySystem.DataAccess.Entities
{
    public class Cellule : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Mark { get; set; }

        public Guid StudentId { get; set; }
        public int JournalId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Journal Journal { get; set; }
    }
}
