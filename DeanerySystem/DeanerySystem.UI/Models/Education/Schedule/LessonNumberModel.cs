using System;
using System.Collections.Generic;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class LessonNumberModel {
		public LessonNumberModel() {
			LessonGroupModels = new List<LessonGroupModel>();
		}

		public LessonNumberModel(int number, TimeSpan start, TimeSpan end) : this() {
			Number = number;
			Start = start;
			End = end;
		}

		public static readonly int LessonRowSpan = 2;
		public int Number { get; set; }
		public TimeSpan Start { get; set; }
		public TimeSpan End { get; set; }
		public List<LessonGroupModel> LessonGroupModels { get; set; }
	}
}
