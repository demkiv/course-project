using System;
using System.Collections.Generic;
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
            using (var uow = new UnitOfWork())
            {
                var university = new University() {Name = "ЛНУ імені Івана Франка"};
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
                var faculty = uow.FacultyRepository.GetById(13);
                sDataFeeder.Data.ForEach(s =>
                {
                    s.Faculty = faculty;
                    uow.StreamRepository.Insert(s);
                });
                uow.Save();

                var dDataFeeder = new DepartmentDataFeeder(uow);
                var stream = uow.StreamRepository.GetById(1);
                dDataFeeder.Data.ForEach(d =>
                {
                    d.Stream = stream;
                    uow.DepartmentRepository.Insert(d);
                });
                var semDataFeeder = new SemesterDataFeeder(uow);
                semDataFeeder.Data.ForEach(s =>
                {
                    uow.SemesterRepository.Insert(s);
                });
                uow.Save();
       
                var pDataFeeder = new ProfessorDataFeeder(uow);
                try
                {
                    pDataFeeder.Data.ForEach(p =>
                    {
                        uow.ProfessorRepository.Insert(p);
                    });
                }
                catch (Exception ex)
                {

                }


                //var professor = new Professor() {FirstName = "AAA", Department = department, DeanOfFaculty = faculty, HeadOfDepartment = department};
                //uow.context.Users.FirstOrDefault().DeaneryUser = professor;
                //uow.ProfessorRepository.Insert(professor);
                uow.Save();
            }

            return View();
        }
        //public ActionResult Index()
        //{
        //    //for testing mock of UnitOfWork
        //    var q = unitOfWork.FacultyRepository.Get();
        //    var q1 = unitOfWork.FacultyRepository.Get(x => x.Name.Contains("ppl"));
        //    var q3 = unitOfWork.FacultyRepository.GetById(5);
        //    unitOfWork.FacultyRepository.Insert(new Faculty() {Id = 20});
        //    var q4 = unitOfWork.FacultyRepository.Get();
        //    var q5 = unitOfWork.FacultyRepository.GetById(1);
        //    q5.Name += "123";
        //    unitOfWork.FacultyRepository.Update(q5);
        //    var q6 = unitOfWork.FacultyRepository.GetById(1);
        //    var w = unitOfWork.SemesterRepository.Get();
        //    var e = unitOfWork.StreamRepository.Get();
        //    var r = unitOfWork.DepartmentRepository.Get();
        //    var t = unitOfWork.StudentRepository.Get();
        //    var y = unitOfWork.ProfessorRepository.Get();
        //    var u = unitOfWork.GroupRepository.Get();
        //    var i = unitOfWork.ClassNumberTimeRepository.Get();
        //    var o = unitOfWork.TimeTableRepository.Get();
        //    var p = unitOfWork.CelluleRepository.Get();
        //    var a = unitOfWork.JournalRepository.Get();
        //    var s = unitOfWork.ClassRepository.Get();
        //    var d = unitOfWork.SubjectRepository.Get();
        //    var f = unitOfWork.EducationalPlanRepository.Get();
        //    unitOfWork.Save();
        //    unitOfWork.Dispose();
        //    return View();
        //}

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