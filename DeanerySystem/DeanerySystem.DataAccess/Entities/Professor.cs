using System.Collections.Generic;
using DeanerySystem.DataAccess.Entities.Enums;
using DeanerySystem.DataAccess.Entities.Identity;

namespace DeanerySystem.DataAccess.Entities
{
    public class Professor : DeaneryUser
    {
        public Positions Position { get; set; }

        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
		public virtual University RectorOfUniversity { get; set; }
        public virtual Faculty DeanOfFaculty { get; set; }
        public virtual Department HeadOfDepartment { get; set; }
        public virtual Group MentorOfGroup { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

        public Professor()
        {
            this.Classes = new List<Class>();
        }

		public string GetFullName() {
			return $"{LastName} {FirstName} {MiddleName}";
		}
	}
}
