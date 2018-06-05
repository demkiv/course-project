using DeanerySystem.DataAccess.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeanerySystem.WebUI.Identity {
	public class ApplicationClaimsIdentityFactory : UserClaimsPrincipalFactory<DeaneryUser> {
		public ApplicationClaimsIdentityFactory(UserManager<DeaneryUser> userManager,
			IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor) { }

		public async override Task<ClaimsPrincipal> CreateAsync(DeaneryUser user) {
			var principal = await base.CreateAsync(user);

			if (!string.IsNullOrWhiteSpace(user.LastName) || !string.IsNullOrWhiteSpace(user.FirstName))
				((ClaimsIdentity)principal.Identity).AddClaims(new[] {
				new Claim(ClaimTypes.GivenName, $"{user.LastName} {user.FirstName}")
			});

			return principal;
		}
	}
}
