using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Stream
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreamAbbreviation { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public Stream()
        {
            this.Departments = new List<Department>();
        }
    }
}
