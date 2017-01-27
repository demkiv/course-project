using System;
using System.Collections.Generic;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class ScheduleInfo {
		public ScheduleInfo() {
			GroupNames = new Dictionary<int, string>();
			DayInfos = new Dictionary<DayOfWeek, DayInfo>();
        }
		public Dictionary<int, string> GroupNames { get; set; }
		public Dictionary<DayOfWeek, DayInfo> DayInfos { get; set; }
	}
}
