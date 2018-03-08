using System;
using DeanerySystem.Domain.Concrete;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.Domain.Entities.Identity;
using Microsoft.AspNet.Identity;

namespace DeanerySystem.Domain.Identity {
	public class IdentityUtilityManager {
		private readonly DeaneryDbContext context;
		public IdentityUtilityManager(IUnitOfWork unitOfWork) {
			this.context = unitOfWork.Context;
		}
		public void CreateAccount(DeaneryUser user, Roles role) {
			var userManager = new UserManager<DeaneryUser, Guid>(new DeaneryUserStore(this.context));
			userManager.Create(user, password: "1234567890");
			userManager.AddToRole(user.Id, Roles.Professor.ToString());
		}

		public void InitRoles() {
			var roleManager = new DeaneryRoleManager(new DeaneryRoleStore(this.context));
			var roles = Enum.GetNames(typeof(Roles));
			foreach (var currRole in roles) {
				if (!roleManager.RoleExists(currRole)) {
					roleManager.Create(new DeaneryRole(currRole));
				}
			}
		}
	}
}
