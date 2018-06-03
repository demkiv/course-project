using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Identity;
using DeanerySystem.WebUI.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DeanerySystem.WebUI.Controllers.API
{
    [Produces("application/json")]
    [Route("api/admin")]
    public class AdminController : Controller
    {
		private IUnitOfWork unitOfWork;
		public AdminController(IUnitOfWork unitOfWork) 
		{
			this.unitOfWork = unitOfWork;
		}

        [HttpPost]
        [Route("student")]
        public IActionResult SaveStudent([FromBody] StudentModel student)
        {
            var studentEntity = new Student()
            {
                StudentCode = student.StudentCardId,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                LatinFirstName = student.FirstNameEng,
                LatinLastName = student.LastNameEng,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email,
                UserName = student.Email,
                Group = this.unitOfWork.GroupRepository.GetById(1)
            };
            var identityUtility = new IdentityUtilityManager(this.unitOfWork);
            identityUtility.CreateAccount(studentEntity, DataAccess.Entities.Enums.Roles.Student);
            return Ok();
        }

        [HttpPut]
        [Route("student")]
        public IActionResult UpdateStudent([FromBody] StudentModel student)
        {
            var studentEntity = unitOfWork.StudentRepository.GetById(student.Id);

            studentEntity.StudentCode = student.StudentCardId;
            studentEntity.FirstName = student.FirstName;
            studentEntity.MiddleName = student.MiddleName;
            studentEntity.LastName = student.LastName;
            studentEntity.LatinFirstName = student.FirstNameEng;
            studentEntity.LatinLastName = student.LastNameEng;
            studentEntity.PhoneNumber = student.PhoneNumber;
            studentEntity.Email = student.Email;

            unitOfWork.StudentRepository.Update(studentEntity);
            unitOfWork.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("student/{id}")]
        public IActionResult RemoveStudent(Guid id)
        {
            var student = unitOfWork.StudentRepository.GetById(id);
            if (student != null)
            {
                unitOfWork.StudentRepository.Delete(student);
                unitOfWork.Save();
            }
            return Ok();
        }
    } 
}
