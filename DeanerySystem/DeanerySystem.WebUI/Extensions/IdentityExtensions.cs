using System.Security.Claims;
using System.Security.Principal;

namespace DeanerySystem.WebUI.Extensions
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
			// TODO add photo path to the DeaneryUser.
			//var claim = ((ClaimsIdentity)identity).FindFirst("PhotoPath");
			//return claim?.Value;
			if (identity.Name == "solomiia.demkiv@edeanery.com") {
				return "/images/Mia.jpg";
			}
			if (identity.Name == "markiyan.fostyak@edeanery.com")
			{
				return "/images/Markiyan.png";
			}
			return "";
		}
	}
}