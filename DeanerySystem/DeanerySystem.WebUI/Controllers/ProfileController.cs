using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.WebUI.Models.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DeanerySystem.WebUI.Extensions;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.WebUI.Controllers
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

			var memberModel = new MemberModel()
			{
				FirstName = currentMember.FirstName,
				LastName = currentMember.LastName,
				MiddleName = currentMember.MiddleName,
				Email = currentMember.Email,
				PhotoPath = User.Identity.GetPhotoPath(),
				MainRole = Providers.ResourcesProvider.GetRoleDisplay(Roles.Student)
			};

			return View(memberModel);
		}
	}
}
