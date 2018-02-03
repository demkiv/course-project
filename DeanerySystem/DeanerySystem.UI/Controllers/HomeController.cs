using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeanerySystem.Domain;
using DeanerySystem.Domain.DataFeeders;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.Domain.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DeanerySystem.Domain.Concrete;

namespace DeanerySystem.UI.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            //for testing mock of UnitOfWork
            //this.FeedDataBase();
            //this.MockSmokeTest();
            return View();
        }

        private void MockSmokeTest()
        {
            //for testing mock of UnitOfWork

            try
            {
                var q = unitOfWork.FacultyRepository.Get();
                var q1 = unitOfWork.FacultyRepository.Get(x => x.Name.Contains("ppl"));
                var q3 = unitOfWork.FacultyRepository.GetById(5);
                unitOfWork.FacultyRepository.Insert(new Faculty() { Id = 20 });
                var q4 = unitOfWork.FacultyRepository.Get();
                var q5 = unitOfWork.FacultyRepository.GetById(1);
                q5.Name += "123";
                unitOfWork.FacultyRepository.Update(q5);
                var q6 = unitOfWork.FacultyRepository.GetById(1);
                var w = unitOfWork.SemesterRepository.Get();
                var e = unitOfWork.StreamRepository.Get();
                var r = unitOfWork.DepartmentRepository.Get();
                var t = unitOfWork.StudentRepository.Get();
                var y = unitOfWork.ProfessorRepository.Get();
                var u = unitOfWork.GroupRepository.Get();
                var i = unitOfWork.ClassNumberTimeRepository.Get();
                var o = unitOfWork.TimeTableRepository.Get();
                var p = unitOfWork.CelluleRepository.Get();
                var a = unitOfWork.JournalRepository.Get();
                var s = unitOfWork.ClassRepository.Get();
                var d = unitOfWork.SubjectRepository.Get();
                var f = unitOfWork.EducationalPlanRepository.Get();
                unitOfWork.Save();
                unitOfWork.Dispose();
            }
            catch (Exception exception)
            {
                throw;
            }           
        }

        private void FeedDataBase()
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var university = new University() { Name = "ЛНУ імені Івана Франка" };
                    uow.UniversityRepository.Insert(university);
                    uow.Save();

                    var fDataFeeder = new FacultyDataFeeder(uow);
                    fDataFeeder.Data.ForEach(f =>
                    {
                        f.University = university;
                        uow.FacultyRepository.Insert(f);
                    });
                    uow.Save();

                    var sDataFeeder = new StreamDataFeeder(uow);
                    sDataFeeder.Data.ForEach(s =>
                    {
                        uow.StreamRepository.Insert(s);
                    });
                    uow.Save();

                    var dDataFeeder = new DepartmentDataFeeder(uow);
                    dDataFeeder.Data.ForEach(d =>
                    {
                        uow.DepartmentRepository.Insert(d);
                    });
                    var semDataFeeder = new SemesterDataFeeder(uow);
                    semDataFeeder.Data.ForEach(s =>
                    {
                        uow.SemesterRepository.Insert(s);
                    });
                    uow.Save();

                    var pDataFeeder = new ProfessorDataFeeder(uow);
                    pDataFeeder.Data.ForEach(p =>
                    {
                        var user = this.CreateAccount(p, uow.context, Roles.Professor);
                        p.Identity = user;
                    });
                    uow.Save();

                    var gDataFeeder = new GroupDataFeeder(uow);
                    gDataFeeder.Data.ForEach(g =>
                    {
                        uow.GroupRepository.Insert(g);
                    });
                    uow.Save();

                    var stDataFeeder = new StudentDataFeeder(uow);
                    stDataFeeder.Data.ForEach(s =>
                    {
                        var user = this.CreateAccount(s, uow.context, Roles.Student);
                        s.Identity = user;
                    });
                    uow.Save();

                    var subjDataFeeder = new SubjectDataFeeder(uow);
                    subjDataFeeder.Data.ForEach(s =>
                    {
                        uow.SubjectRepository.Insert(s);

                    });
                    uow.Save();

                    var classDataFeeder = new ClassDataFeeder(uow);
                    classDataFeeder.Data.ForEach(c =>
                    {
                        uow.ClassRepository.Insert(c);

                    });
                    uow.Save();

                    var timeTableDataFeeder = new TimeTableDataFeeder(uow);
                    timeTableDataFeeder.Data.ForEach(t =>
                    {
                        uow.TimeTableRepository.Insert(t);

                    });
                    uow.Save();

                    var classNumberTimes = new ClassNumberTimeDataFeeder(uow);
                    classNumberTimes.Data.ForEach(c =>
                    {
                        uow.ClassNumberTimeRepository.Insert(c);

                    });
                    uow.Save();

                    var jDataFeeder = new JournalDataFeeder(uow);
                    jDataFeeder.Data.ForEach(j =>
                    {
                        uow.JournalRepository.Insert(j);

                    });
                    uow.Save();

                    var cDataFeeder = new CellulesDataFeeder(uow);
                    cDataFeeder.Data.ForEach(c =>
                    {
                        uow.CelluleRepository.Insert(c);
                    });
                    uow.Save();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private ApplicationUser CreateAccount(DeaneryUser professor, IdentityDbContext<ApplicationUser> ctx, Roles currRole) {


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
            var roles = Enum.GetNames(typeof(Roles));
            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole(role));
                }
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
            var newApplicationUser = new ApplicationUser()
            {
                UserName = $"{professor.LatinFirstName.ToLower()}.{professor.LatinLastName.ToLower()}@edeanery.com",
                Email = $"{professor.LatinFirstName.ToLower()}.{professor.LatinLastName.ToLower()}@edeanery.com",
                EmailConfirmed = true,
                DeaneryUser = professor
            };
            ctx.Entry(professor).State = EntityState.Added;
            
            userManager.Create(newApplicationUser, password: "1234567890");
            userManager.AddToRole(newApplicationUser.Id, currRole.ToString());
            return newApplicationUser;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}