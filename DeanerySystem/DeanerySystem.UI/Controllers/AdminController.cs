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
	[Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (var ctx = new DeaneryDbContext()) {
                var university = ctx.Universities.FirstOrDefault() ?? new Domain.Entities.University { Name = "", Rector = new Professor() };
                university.Rector = university.Rector ?? new Professor();
                var universityModel = new Models.Admin.University
                {
                    Name = university.Name,
                    RectorFirstName = university.Rector.FirstName,
                    RectorLastName = university.Rector.LastName,
                    RectorId = university.Rector.Id
                };
    
                var stats = new GeneralInfo()
                {
                    FacultiesCount = ctx.Faculties.Count(),
                    StreamsCount = ctx.Faculties.Count(),
                    DepartmentsCount = ctx.Departments.Count(),
                    GroupsCount = ctx.Groups.Count(),
                    ProfessorsCount = ctx.Professors.Count(),
                    StudentsCount = ctx.Streams.Count(),
                    University = universityModel
                };
                return View(stats);
            }
        }

		[Authorize(Roles = "SuperAdministrator")]
		public ActionResult ManageUniversity()
        {
            using (var ctx = new DeaneryDbContext()) {
                var university = ctx.Universities.First();
                university = university ?? new Domain.Entities.University { Name = "" };
                return PartialView("Partials/_ManageUniversity", university);
            }
		}

        [Authorize(Roles = "SuperAdministrator")]
        [HttpPost]
        public ActionResult PostUniversityInfo(Models.Admin.University universityModel) {
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

        [Authorize(Roles = "SuperAdministrator")]
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

        [Authorize(Roles = "SuperAdministrator")]
        [HttpGet]
        public OverviewFaculties() {
        }

        public Models.Admin.University GetUniversityInfo() {
            using (var ctx = new DeaneryDbContext())
            {
                var domainUniversity = ctx.Universities.FirstOrDefault();
                var university = new Models.Admin.University() { Name = domainUniversity != null ? domainUniversity.Name : "" };
                return university;
            }
        }
    }
}