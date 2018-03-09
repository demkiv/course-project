using System;
using System.Collections.Generic;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.Entities.Enums;
using DeanerySystem.DataAccess.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DeanerySystem.DataAccess.Identity {
	public class IdentityUtilityManager {
		private readonly DeaneryDbContext context;
		public IdentityUtilityManager(IUnitOfWork unitOfWork) {
			this.context = unitOfWork.Context;
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
		    var userManager = new UserManager<DeaneryUser>(userStore, null, hasher, validators, passwordValidators, null,
		        null, null, null);
			userManager.CreateAsync(user, password: "1234567890");
			userManager.AddToRoleAsync(user, Roles.Professor.ToString());
		}

		public void InitRoles()
		{
		    var roleStore = new RoleStore<DeaneryRole, DeaneryDbContext, Guid, DeaneryUserRole, DeaneryRoleClaim>(context);

            var roleManager = new RoleManager<DeaneryRole>(roleStore, null, null, null, null);
			
			var roles = Enum.GetNames(typeof(Roles));
			foreach (var currRole in roles) {
				if (!roleManager.RoleExistsAsync(currRole).Result) {
					roleManager.CreateAsync(new DeaneryRole(currRole));
				}
			}
		}
	}
}
