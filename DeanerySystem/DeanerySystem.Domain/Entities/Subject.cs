using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfLectures { get; set; }
        public int NumberOfPracticalClasses { get; set; }
        public int NumberOflLaboratoryClasses { get; set; }
        public int NumberOfConsultations { get; set; }
        public SemesterControlTypes SemesterControl { get; set; }
        public DateTime? PassingDate { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<BookOfSuccess> BooksOfSuccess { get; set; }
        public virtual ICollection<Writing> Writings { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
        public Subject()
        {
            this.BooksOfSuccess = new List<BookOfSuccess>();
            this.Writings = new List<Writing>();
            this.Journals = new List<Journal>();
        }
    }
}
