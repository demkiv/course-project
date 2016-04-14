using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.UI.Models.Education {
	public class ScheduleInfo {
		public List<Group> Groups { get; set; }
		public Dictionary<DayOfWeek, List<ClassNumberTime>> Times { get; set; }
		public Dictionary<DayOfWeek, int> NumberOfTimes { get; set; }
		public List<EducationalPlan> EducationalPlans { get; set; } 

	}
}
