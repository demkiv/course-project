using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.Entities
{
    public class Student : DeanaryUser
    {
        public string StudentCode { get; set; }
        public TuitionFees TuitionFee { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<ProgressRecord> ProgressRecords { get; set; }
        public virtual ICollection<Writing> Writings { get; set; }
        public virtual ICollection<Cellule> Cellules { get; set; }
	    public virtual ICollection<Semester> Semesters { get; set; }

        public Student()
        {
            this.ProgressRecords = new List<ProgressRecord>();
            this.Writings = new List<Writing>();
			this.Cellules = new List<Cellule>();
			this.Semesters = new List<Semester>();
        }
    }
}
