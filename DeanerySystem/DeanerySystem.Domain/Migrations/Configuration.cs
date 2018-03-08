using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.Domain.Entities.Identity;
using DeanerySystem.Domain.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeanerySystem.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DeanerySystem.Domain.Concrete.DeaneryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DeanerySystem.Domain.Concrete.DeaneryDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
            try
            {
                var roleManager = new RoleManager<DeaneryRole, Guid>(new DeaneryRoleStore(context));
                var roles = Enum.GetNames(typeof(Roles));
                foreach (var role in roles)
                {
                    if (!roleManager.RoleExists(role))
                    {
                        roleManager.Create(new DeaneryRole(role));
                    }
                }

                var userManager = new UserManager<DeaneryUser, Guid>(new DeaneryUserStore(context));
                var newApplicationUser = new DeaneryUser()
                {
                    UserName = "admin@edeanery.com",
                    Email = "admin@edeanery.com",
                    EmailConfirmed = true
                };
                userManager.Create(newApplicationUser, password: "ChangeItAsap!");
                userManager.AddToRole(newApplicationUser.Id, Roles.SuperAdministrator.ToString());
                
                //Uncomment this line to prepopulate database with test data.
                //DataBaseUtilities.FeedDataBase();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
