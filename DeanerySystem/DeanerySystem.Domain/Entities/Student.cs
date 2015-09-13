using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Student : User
    {
        public string StudentCode { get; set; }
        public TuitionFees TuitionFee { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<BookOfSuccess> BooksOfSuccess { get; set; }
        public virtual ICollection<Writing> Writings { get; set; }
        public virtual ICollection<Cellule> Cellules { get; set; }
        public Student()
        {
            this.BooksOfSuccess = new List<BookOfSuccess>();
            this.Writings = new List<Writing>();
            this.Cellules = new List<Cellule>();
        }
    }
}
