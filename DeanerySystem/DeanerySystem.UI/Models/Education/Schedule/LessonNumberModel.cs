using System;
using System.Collections.Generic;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class LessonNumberModel {
		public LessonNumberModel() {
			LessonGroups = new List<LessonGroupModel>();
		}

		public LessonNumberModel(int number, TimeSpan start, TimeSpan end) : this() {
			Number = number;
			Start = start.ToString(@"hh\:mm");
			End = end.ToString(@"hh\:mm");
		}

		public static readonly int LessonRowSpan = 2;
		public int Number { get; set; }
		public string Start { get; set; }
		public string End { get; set; }
		public List<LessonGroupModel> LessonGroups { get; set; }
	}
}
