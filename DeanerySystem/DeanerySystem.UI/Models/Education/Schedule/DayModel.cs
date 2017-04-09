using System;
using System.Collections.Generic;
using System.Linq;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class DayModel {
		public DayModel() {
			LessonNumbers = new List<LessonNumberModel>();
		}
		public DayModel(DayOfWeek dayOfWeek, string dayOfWeekName) : this() {
			Id = dayOfWeek;
			Name = dayOfWeekName;
		}

		public DayOfWeek Id { get; set; }
		public string Name { get; set; }
		public List<LessonNumberModel> LessonNumbers { get; set; }

		//public int FirstLessonNumber => LessonNumberModels.Min(ln => ln.Number);
		//public int LastLessonNumber => LessonNumberModels.Max(ln => ln.Number);
		public int DayRowSpan => LessonNumberModel.LessonRowSpan * LessonNumbers.Count;
	}
}
