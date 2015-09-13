using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class TimeTable
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Fractions Fraction { get; set; }

        public virtual Journal Journal { get; set; }
        public virtual ICollection<ClassNumberTime> ClassNumberTimes { get; set; }
        public TimeTable()
        {
            this.ClassNumberTimes = new List<ClassNumberTime>();
        }
    }
}
