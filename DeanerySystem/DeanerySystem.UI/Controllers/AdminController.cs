using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeanerySystem.UI.Models;
using DeanerySystem.UI.Models.Admin;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.Domain.Concrete;

namespace DeanerySystem.UI.Controllers
{
    //[Authorize(Roles = "SuperAdministrator")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult ManageUniversity()
        {
            using (var ctx = new DeaneryDbContext()) {
                var university = ctx.Universities.First();
                university = university ?? new Domain.Entities.University { Name = "" };
                return PartialView("Partials/_ManageUniversity", university);
            }
		}

        [HttpPost]
        public ActionResult PostUniversityInfo(Models.Admin.UniversityModel universityModel) {
            using (var ctx = new DeaneryDbContext()) {
                var domainUniversity = ctx.Universities.FirstOrDefault();
                if (domainUniversity != null)
                {
                    domainUniversity.Name = universityModel.Name;
                    //domainUniversity.Rector = ctx.Professors.Find(universityModel.RectorId);
                }
                else
                {
                    ctx.Universities.Add(new Domain.Entities.University() { Name = universityModel.Name });
                }
                ctx.SaveChanges();
            }

            return Json(GetUniversityInfo());
        }

        [HttpGet]
        public ActionResult GetAllProfessors() {
            using (var ctx = new DeaneryDbContext()) {
                if (ctx.Professors.Any())
                {
                    return Json(ctx.Professors.Select(x => new { x.FirstName, x.LastName, x.Id }).ToList(), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new List<object> { new { FirstName = "Святослав", LastName = "Тарасюк", Id = 1 }, new { FirstName = "Ярослав", LastName = "Холявка", Id = 2 }, new { FirstName = "Юрій", LastName = "Щербина", Id = 3 } }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpGet]
        public ActionResult OverviewFaculties() {
            using (var ctx = new DeaneryDbContext()) {
                var faculties = ctx.Faculties.Any() ? ctx.Faculties.Select(x => new Models.Admin.Faculty() { Name = x.Name, Id = x.Id }).ToList() : new List<Models.Admin.Faculty>();
                return View(faculties);
            }
                
        }

        public Models.Admin.UniversityModel GetUniversityInfo() {
            using (var ctx = new DeaneryDbContext())
            {
                var domainUniversity = ctx.Universities.FirstOrDefault();
                var university = new Models.Admin.UniversityModel() { Name = domainUniversity != null ? domainUniversity.Name : "" };
                return university;
            }
        }
    }
}