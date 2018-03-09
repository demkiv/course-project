using System;
using Microsoft.AspNetCore.Identity;

namespace DeanerySystem.DataAccess.Entities.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class DeaneryUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string LatinFirstName { get; set; }
        public string LatinLastName { get; set; }

        public DeaneryUser()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
