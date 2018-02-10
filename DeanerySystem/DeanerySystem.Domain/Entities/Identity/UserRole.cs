using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeanerySystem.Domain.Entities.Identity
{
    public class DeaneryRole : IdentityRole<Guid, DeaneryUserRole>
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
