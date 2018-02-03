using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.Domain.Entities.Identity;
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roles = Enum.GetNames(typeof(Roles));
            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole(role));
                }
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var newApplicationUser = new ApplicationUser()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };
            userManager.Create(newApplicationUser, password: "budka123");
            userManager.AddToRole(newApplicationUser.Id, Roles.SuperAdministrator.ToString());
            //using (var unit = new UnitOfWork())
            //{
            //    unit.SemesterRepository.Insert(new Semester() {CreditSessionStart = DateTime.Now, End = DateTime.Now, Id = 1, Number = SemesterNumber.First, SecondWritingStart = DateTime.Now, ThirdWritingStart = DateTime.Now, Start = DateTime.Now, SessionStart = DateTime.Now });
            //    unit.Save();
            //}
        }
    }
}
