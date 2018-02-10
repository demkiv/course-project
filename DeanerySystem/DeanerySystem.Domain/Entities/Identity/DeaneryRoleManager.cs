using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DeanerySystem.Domain.Entities.Identity
{
    public class DeaneryRoleManager : RoleManager<DeaneryRole, Guid>
    {
        // PASS CUSTOM APPLICATION ROLE AND INT AS TYPE ARGUMENTS TO CONSTRUCTOR:
        public DeaneryRoleManager(IRoleStore<DeaneryRole, Guid> roleStore)
            : base(roleStore)
        {
        }

        // PASS CUSTOM APPLICATION ROLE AS TYPE ARGUMENT:
        public static DeaneryRoleManager Create(
            IdentityFactoryOptions<DeaneryRoleManager> options, IOwinContext context)
        {
            return new DeaneryRoleManager(
                new DeaneryRoleStore(context.Get<DeaneryDbContext>()));
        }
    }
}
