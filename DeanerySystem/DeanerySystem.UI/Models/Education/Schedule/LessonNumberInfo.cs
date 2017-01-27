using System;
using System.Collections.Generic;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class LessonNumberInfo {
		public LessonNumberInfo() {
			LessonGroupInfos = new Dictionary<int, LessonGroupInfo>();
		}

		public LessonNumberInfo(int number, TimeSpan start, TimeSpan end) : this() {
			Number = number;
			Start = start;
			End = end;
		}

		public static readonly int LessonRowSpan = 2;
		public int Number { get; set; }
		public TimeSpan Start { get; set; }
		public TimeSpan End { get; set; }
		public Dictionary<int, LessonGroupInfo> LessonGroupInfos { get; set; }
	}
}
