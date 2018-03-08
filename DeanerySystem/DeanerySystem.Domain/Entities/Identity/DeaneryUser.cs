using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities.Abstract;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeanerySystem.Domain.Entities.Identity {
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class DeaneryUser : IdentityUser<Guid, DeaneryUserLogin, DeaneryUserRole, DeaneryUserClaim>, IIdentifiableEntity<Guid> {

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string LatinFirstName { get; set; }
		public string LatinLastName { get; set; }

		public DeaneryUser() {
			this.Id = Guid.NewGuid();
		}
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<DeaneryUser, Guid> manager) {
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}
}
