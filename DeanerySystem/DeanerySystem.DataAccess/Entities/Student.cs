using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Enums;
using DeanerySystem.DataAccess.Entities.Identity;

namespace DeanerySystem.DataAccess.Entities
{
    public class Student : DeaneryUser
    {
        public string StudentCode { get; set; }
        public TuitionFees TuitionFee { get; set; }

        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<ProgressRecord> ProgressRecords { get; set; }
        public virtual ICollection<FailureTicket> FailureTickets { get; set; }
        public virtual ICollection<Cellule> Cellules { get; set; }
        public virtual ICollection<StudentSemester> StudentSemesters { get; set; }

        public Student()
        {
            this.ProgressRecords = new List<ProgressRecord>();
            this.FailureTickets = new List<FailureTicket>();
            this.Cellules = new List<Cellule>();
            this.StudentSemesters = new List<StudentSemester>();
        }
    }
}
