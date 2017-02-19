using System.Collections.Generic;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class ScheduleModel {
		public ScheduleModel() {
			GroupModels = new List<GroupModel>();
			DayModels = new List<DayModel>();
        }

		public List<GroupModel> GroupModels { get; set; }
		public List<DayModel> DayModels { get; set; }
	}
}
