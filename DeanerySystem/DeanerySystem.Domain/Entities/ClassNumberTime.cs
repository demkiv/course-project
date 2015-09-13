using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class ClassNumberTime
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public TimeSpan TimeOfBeginning { get; set; }
        public TimeSpan TimeOfEnding { get; set; }

        public virtual TimeTable TimeTable { get; set; }
    }
}
