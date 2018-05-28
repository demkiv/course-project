using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Abstract;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.Entities
{
    public class TimeTable : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Fractions Fraction { get; set; }

        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<ClassNumberTime> ClassNumberTimes { get; set; }
        public TimeTable()
        {
            this.ClassNumberTimes = new List<ClassNumberTime>();
        }
    }
}
