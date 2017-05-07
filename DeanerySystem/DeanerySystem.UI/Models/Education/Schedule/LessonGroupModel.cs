using System.Collections.Generic;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class LessonGroupModel {
		public LessonGroupModel() {
			Lessons = new List<LessonModel>();
		}

		public int GroupId { get; set; }
		public List<LessonModel> Lessons { get; set; }
	}
}
