using System;
using System.Data.Entity;
using System.Web.Mvc;
using DeanerySystem.Domain;
using DeanerySystem.Domain.DataFeeders;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.Domain.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DeanerySystem.Domain.Concrete;
using DeanerySystem.Domain.Utilities;

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
            return View();
        }

        private DeaneryUser CreateAccount(DeaneryUser professor, DeaneryDbContext ctx, Roles currRole) {


            var roleManager = new DeaneryRoleManager(new DeaneryRoleStore(ctx));
            var roles = Enum.GetNames(typeof(Roles));
            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new DeaneryRole(role));
                }
            }
            var userManager = new UserManager<DeaneryUser, Guid>(new DeaneryUserStore(ctx));
            //professor.UserName =
            //    $"{professor.LatinFirstName.ToLower()}.{professor.LatinLastName.ToLower()}@edeanery.com";
            //professor.Email = $"{professor.LatinFirstName.ToLower()}.{professor.LatinLastName.ToLower()}@edeanery.com";
            //professor.EmailConfirmed = true;
  
            //ctx.Entry(professor).State = EntityState.Added;
            
            userManager.Create(professor, password: "1234567890");
            userManager.AddToRole(professor.Id, currRole.ToString());
            return professor;
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

        #region SmokeTest
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


        #endregion
    }
}