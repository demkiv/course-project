using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Concrete;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeanerySystem.Domain.Entities.Identity
{
    public class DeaneryUserStore: UserStore<DeaneryUser, DeaneryRole, Guid, DeaneryUserLogin, DeaneryUserRole, DeaneryUserClaim>
    {
        public DeaneryUserStore(DeaneryDbContext context) : base(context)
        {
        }
    }
}
