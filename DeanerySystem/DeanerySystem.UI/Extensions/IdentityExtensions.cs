using System.Security.Claims;
using System.Security.Principal;

namespace DeanerySystem.UI.Extensions
{
	public static class IdentityExtensions
	{
		public static string GetGivenName(this IIdentity identity)
		{
			var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.GivenName);
			return claim?.Value ?? identity.Name;
		}

		public static string GetPhotoPath(this IIdentity identity)
		{
			var claim = ((ClaimsIdentity)identity).FindFirst("PhotoPath");
			return claim?.Value;
		}
	}
}