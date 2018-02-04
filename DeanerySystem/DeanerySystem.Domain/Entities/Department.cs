using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Abstract;

namespace DeanerySystem.Domain.Entities
{
    public class Department : IIdentifiableEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }


        public virtual Stream Stream { get; set; }
        public virtual Professor Head { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Professor> Professors { get; set; }
        public Department()
        {
            this.Groups = new List<Group>();
            this.Professors = new List<Professor>();
        }
    }
}
