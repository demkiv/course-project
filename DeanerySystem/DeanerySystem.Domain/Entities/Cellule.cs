using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Abstract;

namespace DeanerySystem.Domain.Entities
{
    public class Cellule : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Mark { get; set; }

        public virtual Student Student { get; set; }
        public virtual Journal Journal { get; set; }
    }
}
