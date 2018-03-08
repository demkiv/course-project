using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeanerySystem.UI.Models.Profile;
using DeanerySystem.Domain;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.UI.Controllers
{
	[Authorize]
    public class ProfileController : Controller
    {
		private IUnitOfWork unitOfWork;
		public ProfileController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		// GET: Profile
		public ActionResult Index()
        {
			var currentMember = unitOfWork.DeaneryUserRepository.Get().Single(user => 
				user.Email == User.Identity.Name);

			//var identityRoles = unitOfWork.DeaneryUserRepository.Get().Where(role => 
			//	currentMember.Roles.Select(r => r.RoleId).Contains(role.Id));
			//var roles = identityRoles.Select(identityRole => (Roles)Enum.Parse(typeof(Roles), identityRole.Name));
			//if (!roles.Any()) {
			//	throw new InvalidOperationException("Each member should have a role!");
			//}

			var memberModer = new MemberModel()
			{
				FirstName = currentMember.FirstName,
				LastName = currentMember.LastName,
				MiddleName = currentMember.MiddleName,
				//PhotoPath = currentMember.PhotoPath ?? "/Content/Images/DefaultMemberPhoto.png",
				//MainRole = Providers.ResourcesProvider.GetRoleDisplay(roles.Min())
			};

			return View(memberModer);
        }
    }
}