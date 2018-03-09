using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DeanerySystem.DataAccess.Entities.Identity;
using System;
using Microsoft.EntityFrameworkCore;

namespace DeanerySystem.DataAccess.Concrete
{
    public class DeaneryDbContext : IdentityDbContext<DeaneryUser, DeaneryRole, Guid, DeaneryUserClaim, DeaneryUserRole, DeaneryUserLogin, DeaneryRoleClaim, DeaneryUserToken>
    {
        public DeaneryDbContext(DbContextOptions<DeaneryDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<DeaneryUser>().ToTable("Users", "dbo");
            builder.Entity<DeaneryRole>().ToTable("Roles", "dbo");
            builder.Entity<DeaneryUserRole>().ToTable("UserRoles", "dbo");
            builder.Entity<DeaneryUserClaim>().ToTable("UserClaims", "dbo");
            builder.Entity<DeaneryUserToken>().ToTable("UserTokens", "dbo");
            builder.Entity<DeaneryRoleClaim>().ToTable("RoleClaims", "dbo");

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
