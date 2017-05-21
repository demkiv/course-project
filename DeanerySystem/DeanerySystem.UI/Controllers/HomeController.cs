using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeanerySystem.Domain;

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
            var q = unitOfWork.FacultyRepository.Get();
            var w = unitOfWork.SemesterRepository.Get();
            var e = unitOfWork.StreamRepository.Get();
            var r = unitOfWork.DepartmentRepository.Get();
            //var t = unitOfWork.StudentRepository.Get();
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
            return View();
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