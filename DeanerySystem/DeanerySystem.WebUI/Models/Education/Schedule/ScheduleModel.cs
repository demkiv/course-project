using System.Collections.Generic;

namespace DeanerySystem.WebUI.Models.Education.Schedule 
{
	public class ScheduleModel 
	{
		public ScheduleModel() 
		{
			Groups = new List<GroupModel>();
			Days = new List<DayModel>();
        }

		public List<GroupModel> Groups { get; set; }
		public List<DayModel> Days { get; set; }
	}
}
