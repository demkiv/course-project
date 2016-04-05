using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class ProgressRecord
    {
        public int Id { get; set; }
        public double TermMark { get; set; }
        public double ExamMark { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
