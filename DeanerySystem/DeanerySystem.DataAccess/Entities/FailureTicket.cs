using System;
using DeanerySystem.DataAccess.Entities.Abstract;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.Entities
{
    public class FailureTicket : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public DateTime PassingDate { get; set; }
        public FailureTicketTypes Type { get; set; }
        public bool IsPassed { get; set; }

        public Guid StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
