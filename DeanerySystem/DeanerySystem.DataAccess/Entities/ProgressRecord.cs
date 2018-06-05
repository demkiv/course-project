using System;
using DeanerySystem.DataAccess.Entities.Abstract;

namespace DeanerySystem.DataAccess.Entities
{
    public class ProgressRecord : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public double TermMark { get; set; }
        public double ExamMark { get; set; }

        public Guid StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
