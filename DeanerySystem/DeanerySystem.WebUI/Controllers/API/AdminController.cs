using DeanerySystem.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DeanerySystem.WebUI.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
		private IUnitOfWork unitOfWork;
		public AdminController(IUnitOfWork unitOfWork) 
		{
			this.unitOfWork = unitOfWork;
		}
    }
}
