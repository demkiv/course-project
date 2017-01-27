using System.Collections.Generic;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class DayInfo {
		public DayInfo() {
			LessonNumberInfos = new SortedDictionary<int, LessonNumberInfo>();
		}
		public DayInfo(string day) : this() {
			Day = day;
		}
		public string Day { get; set; }
		public int DayRowSpan => LessonNumberInfo.LessonRowSpan * LessonNumberInfos.Count;
		public SortedDictionary<int, LessonNumberInfo> LessonNumberInfos { get; set; }
	}
}
