using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Abstract;

namespace DeanerySystem.DataAccess.Entities
{
    public class Department : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public Guid? HeadId { get; set; }
        public int StreamId { get; set; }

        public virtual Stream Stream { get; set; }
        public virtual Professor Head { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Professor> Professors { get; set; }
        public Department()
        {
            this.Groups = new List<Group>();
            this.Professors = new List<Professor>();
        }
    }
}
