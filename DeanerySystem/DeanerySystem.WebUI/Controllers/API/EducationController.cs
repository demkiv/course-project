using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.WebUI.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeanerySystem.WebUI.Controllers.API
{
    [Produces("application/json")]
    [Route("api/education")]
    public class EducationController : Controller
    {
		private IUnitOfWork unitOfWork;
		public EducationController(IUnitOfWork unitOfWork) {
			this.unitOfWork = unitOfWork;
		}

		public class MarkingsDTO {
			public string[] marks { get; set; }
			public int educationalPlanId { get; set; }
			public int classId { get; set; }
			public int journalId { get; set; }
		}

		[HttpPost]
		[Route("markings")]
		public IActionResult Markings([FromBody] MarkingsDTO markingsDTO) {
			var educationalPlan = unitOfWork.EducationalPlanRepository.Get(includeProperties: "Group,Group.Students,Semester,Subject")
				.First(plan => plan.Id == markingsDTO.educationalPlanId);
			var _class = this.unitOfWork.ClassRepository.Get(includeProperties: "Journals,Journals.Cellules,TimeTables,TimeTables.ClassNumberTimes")
				.First(c => c.Id == markingsDTO.classId);
			var journal = this.unitOfWork.JournalRepository.Get(includeProperties: "Cellules").First(j => j.Id == markingsDTO.journalId);
			List<DateTime> dates = JournalProvider.GetDates(educationalPlan, _class);

			int rowId = 1;
			int columnId = 1;

			foreach (var mark in markingsDTO.marks)
			{
				if (dates.Count == columnId - 1)
				{
					columnId = 1;
					rowId++;
				}

				if (mark != String.Empty)
				{
					Cellule cellule = this.unitOfWork.CelluleRepository.Get(includeProperties: "Journal,Student")
						.FirstOrDefault(c => c.Journal == journal
							&& c.Date == dates.ElementAt(columnId - 1)
							&& c.Student == educationalPlan.Group.Students.ElementAt(rowId - 1));

					if (cellule == null)
					{
						var newCellule = new Cellule()
						{
							Date = dates.ElementAt(columnId - 1),
							Student = educationalPlan.Group.Students.ElementAt(rowId - 1),
							Mark = mark,
							Journal = journal
						};
						unitOfWork.CelluleRepository.Insert(newCellule);
					}
					else
					{
						cellule.Mark = mark;
					}
				}

				columnId++;
			}
			unitOfWork.Save();

			return Ok();
		}
	}
}
