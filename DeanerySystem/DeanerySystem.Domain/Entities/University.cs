using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Abstract;

namespace DeanerySystem.Domain.Entities {
	public class University : IIdentifiableEntity<int>
    {
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual Professor Rector { get; set; }
		public virtual ICollection<Faculty> Faculties { get; set; }

		public University() {
			Faculties = new List<Faculty>();
		}
	}
}
