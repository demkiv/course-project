using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Abstract;

namespace DeanerySystem.DataAccess.Entities
{
    public class Faculty : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UniversityId { get; set; }
        public Guid? DeanId { get; set; }

        public virtual University University { get; set; }
        public virtual Professor Dean { get; set; }
        public virtual ICollection<Stream> Streams { get; set; }
        public Faculty()
        {
            this.Streams = new List<Stream>();
        }
    }
}
