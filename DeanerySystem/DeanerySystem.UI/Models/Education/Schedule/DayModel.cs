using System;
using System.Collections.Generic;
using System.Linq;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class DayModel {
		public DayModel() {
			LessonNumberModels = new List<LessonNumberModel>();
		}
		public DayModel(DayOfWeek dayOfWeek, string dayOfWeekName) : this() {
			DayOfWeek = dayOfWeek;
			DayOfWeekName = DayOfWeekName;
		}

		public DayOfWeek DayOfWeek { get; set; }
		public string DayOfWeekName { get; set; }
		public List<LessonNumberModel> LessonNumberModels { get; set; }

		public int FirstLessonNumber => LessonNumberModels.Min(ln => ln.Number);
		public int LastLessonNumber => LessonNumberModels.Max(ln => ln.Number);
		public int DayRowSpan => LessonNumberModel.LessonRowSpan * LessonNumberModels.Count;
	}
}
