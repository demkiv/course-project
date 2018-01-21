using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Abstract;

namespace DeanerySystem.Domain.Entities
{
    public class ClassNumberTime : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public virtual TimeTable TimeTable { get; set; }
    }
}
