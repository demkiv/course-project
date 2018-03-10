using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Abstract;

namespace DeanerySystem.DataAccess.Entities
{
    public class University : IIdentifiableEntity<int>
    {
		public int Id { get; set; }
		public string Name { get; set; }

        public Guid? RectorId { get; set; }

		public virtual Professor Rector { get; set; }
		public virtual ICollection<Faculty> Faculties { get; set; }

		public University() {
			Faculties = new List<Faculty>();
		}
	}
}
