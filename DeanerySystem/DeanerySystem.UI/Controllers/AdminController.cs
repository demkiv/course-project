using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeanerySystem.UI.Models;

namespace DeanerySystem.UI.Controllers
{
	[Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

		[Authorize(Roles = "SuperAdministrator")]
		public ActionResult ManageUniversity() {
			return PartialView("Partials/_ManageUniversityPartial");
		}


    }
}