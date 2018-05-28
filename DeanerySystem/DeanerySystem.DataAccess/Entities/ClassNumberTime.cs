using System;
using DeanerySystem.DataAccess.Entities.Abstract;

namespace DeanerySystem.DataAccess.Entities
{
    public class ClassNumberTime : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public int TimeTableId { get; set; }

        public virtual TimeTable TimeTable { get; set; }
    }
}
