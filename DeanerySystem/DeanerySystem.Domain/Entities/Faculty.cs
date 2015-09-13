using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Professor Dean { get; set; }
        public virtual ICollection<Stream> Streams { get; set; }
        public Faculty()
        {
            this.Streams = new List<Stream>();
        }
    }
}
