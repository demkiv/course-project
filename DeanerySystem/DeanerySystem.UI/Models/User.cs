using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.UI.Models {
	public class User {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string Email { get; set; }
		public Roles Role { get; set; }
	}
}
