using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeanerySystem.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DeanerySystem.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IUnitOfWork unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View("Dashboard");
        }

        public IActionResult StudentAccounts()
        {
            return View();
        }

        public IActionResult ProfessorAccounts()
        {
            var accounts = unitOfWork.ProfessorRepository.Get();    
            ViewData["Data"] = JsonConvert.SerializeObject(accounts);
            return View();
        }
    }
}