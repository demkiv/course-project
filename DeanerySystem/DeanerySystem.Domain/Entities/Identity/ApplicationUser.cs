using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeanerySystem.Domain.Entities.Identity {
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			this.DeaneryUser = new DeaneryUser();
		}

		public virtual DeaneryUser DeaneryUser { get; set; }
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

			DeaneryUser deaneryUser;
			using (var unitOfWork = new UnitOfWork()) {
				deaneryUser = unitOfWork.DeaneryUserRepository.Get().Single(u => u.Identity.Id == Id);
			}

			userIdentity.AddClaim(new Claim(ClaimTypes.GivenName, deaneryUser.FirstName ?? ""));
			userIdentity.AddClaim(new Claim("PhotoPath", deaneryUser.PhotoPath ?? ""));

			// Add custom user claims here
			return userIdentity;
		}
	}
}
