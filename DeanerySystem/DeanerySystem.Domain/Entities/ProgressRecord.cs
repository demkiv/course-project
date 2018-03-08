using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Abstract;

namespace DeanerySystem.Domain.Entities
{
    public class ProgressRecord : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public double TermMark { get; set; }
        public double ExamMark { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
