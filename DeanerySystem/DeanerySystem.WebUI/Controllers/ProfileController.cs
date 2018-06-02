﻿using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.WebUI.Models.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
				Email = currentMember.Email
				//PhotoPath = currentMember.PhotoPath ?? "/Content/Images/DefaultMemberPhoto.png",
				//MainRole = Providers.ResourcesProvider.GetRoleDisplay(roles.Min())
			};

			return View(memberModer);
		}
	}
}