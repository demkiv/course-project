using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Abstract;
using DeanerySystem.Domain.Entities.Identity;

namespace DeanerySystem.Domain.Entities
{
    public class DeaneryUser : IIdentifiableEntity<Guid>
    {
	    public virtual ApplicationUser Identity { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string LatinFirstName { get; set; }
        public string LatinLastName { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public Roles Role { get; set; }
    }
}
