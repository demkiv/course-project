using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeanerySystem.Domain.Abstract;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Controllers
{
    public class FacultyController : Controller
    {
        private IFacultyRepository repository;
        public FacultyController(IFacultyRepository facultyRepository)
        {
            this.repository = facultyRepository;
        }

        public ViewResult List()
        {
            return View(repository.Faculties);
        }
    }
}