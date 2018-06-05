using Microsoft.AspNetCore.Identity;
using System;

namespace DeanerySystem.DataAccess.Entities.Identity
{
    public class DeaneryRole: IdentityRole<Guid>
    {
        public DeaneryRole()
        {
            base.Id = Guid.NewGuid();
        }

        public DeaneryRole(string name) : this()
        {
            Name = name;
        }
    }
}
