using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.Entities
{
    public class Professor : DeanaryUser
    {
        public Positions Position { get; set; }

        public virtual Department Department { get; set; }

		public virtual University Rector { get; set; }
        public virtual Faculty Dean { get; set; }
        public virtual Department Head { get; set; }
        public virtual Group Mentor { get; set; }

        public virtual ICollection<Journal> Journals { get; set; }

        public Professor()
        {
            this.Journals = new List<Journal>();
        }
    }
}
