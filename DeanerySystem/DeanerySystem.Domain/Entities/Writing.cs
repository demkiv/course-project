using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Writing
    {
        public int Id { get; set; }
        public DateTime PassingDate { get; set; }
        public WritingTypes WritingType { get; set; }
        public bool IsPassed { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
