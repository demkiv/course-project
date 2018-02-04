using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeanerySystem.Domain.Entities.Identity
{
    public class DeaneryRoleStore: RoleStore<DeaneryRole, int, DeaneryUserRole>
    {
        public DeaneryRoleStore(DbContext context) : base(context)
        {
        }
    }
}
