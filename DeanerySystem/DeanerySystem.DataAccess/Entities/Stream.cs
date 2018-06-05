using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Abstract;

namespace DeanerySystem.DataAccess.Entities
{
    public class Stream : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreamAbbreviation { get; set; }

        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public Stream()
        {
            this.Departments = new List<Department>();
        }
    }
}
