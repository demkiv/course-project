using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.Entities.Enums;
using DeanerySystem.DataAccess.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DeanerySystem.DataAccess.Identity {
	public class IdentityUtilityManager {
		private readonly DeaneryDbContext context;
		public IdentityUtilityManager(IUnitOfWork unitOfWork) {
			this.context = unitOfWork.Context;
		}

	    public IdentityUtilityManager(DeaneryDbContext context)
	    {
	        this.context = context;
	    }
        public void CreateAccount(DeaneryUser user, Roles role)
		{
		    var userStore = new UserStore<DeaneryUser, DeaneryRole, DeaneryDbContext, Guid, DeaneryUserClaim, DeaneryUserRole, DeaneryUserLogin, DeaneryUserToken, DeaneryRoleClaim>(this.context);
            var hasher = new PasswordHasher<DeaneryUser>();
            var options = new IdentityOptions();
		    var validators = new List<IUserValidator<DeaneryUser>>
		    {
		        new UserValidator<DeaneryUser>()
		    };
		    var passwordValidators = new List<IPasswordValidator<DeaneryUser>>
		    {
		        new PasswordValidator<DeaneryUser>()
		    };
		    var logger = new Logger<UserManager<DeaneryUser>>(new NullLoggerFactory());
            var userManager = new UserManager<DeaneryUser>(userStore, null, hasher, validators, passwordValidators, null,
		        null, null, logger);
		    user.SecurityStamp = Guid.NewGuid().ToString();
			var createUserResult = userManager.CreateAsync(user, password: "12qwas!@QWAS").Result;
		    if (createUserResult.Succeeded)
		    {
		        var addToRoleResult = userManager.AddToRoleAsync(user, role.ToString()).Result;
		    }
		}

		public void InitRoles()
		{
		    var roleStore = new RoleStore<DeaneryRole, DeaneryDbContext, Guid, DeaneryUserRole, DeaneryRoleClaim>(context);

            var roleManager = new RoleManager<DeaneryRole>(roleStore, null, null, null, null);
			
			var roles = Enum.GetNames(typeof(Roles));
			foreach (var currRole in roles) {
				if (!roleManager.RoleExistsAsync(currRole).Result) {
					roleManager.CreateAsync(new DeaneryRole(currRole)).Wait();
				}
			}
		}

	    public void InitAdministrator()
	    {
	        var admin = new DeaneryUser
	        {
	            UserName = "admin@eadeanery.com",
	            Email = "admin@eadeanery.com",
	            EmailConfirmed = true,
	            SecurityStamp = Guid.NewGuid().ToString()
	        };
            this.CreateAccount(admin, Roles.SuperAdministrator);
	    }
	}
}
