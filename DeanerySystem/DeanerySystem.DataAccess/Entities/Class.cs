using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Abstract;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.Entities
{
    public class Class : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ClassTypes ClassType { get; set; }

        public Guid? ProfessorId { get; set; }
        public int SubjectId { get; set; }

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
