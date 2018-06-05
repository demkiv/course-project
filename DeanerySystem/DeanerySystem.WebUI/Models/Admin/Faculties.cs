using System.Collections.Generic;

namespace DeanerySystem.WebUI.Models.Admin
{
    public class Faculties
    {
		public Faculties() {
			FacultiesList = new List<Faculty>();
		}

		public List<Faculty> FacultiesList { get; set; }
	}
}
