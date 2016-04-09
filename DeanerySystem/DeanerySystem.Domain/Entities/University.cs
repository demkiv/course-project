﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities {
	public class University {
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual Professor Rector { get; set; }
		public virtual ICollection<Faculty> Faculties { get; set; }

		public University() {
			Faculties = new List<Faculty>();
		}
	}
}