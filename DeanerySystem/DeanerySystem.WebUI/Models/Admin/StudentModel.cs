using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeanerySystem.WebUI.Models.Admin
{
    public class StudentModel
    {
        public Guid? Id { get; set; }
        public string StudentCardId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameEng { get; set; }
        public string LastNameEng { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Stream { get; set; }
        public string Group { get; set; }
    }
}
