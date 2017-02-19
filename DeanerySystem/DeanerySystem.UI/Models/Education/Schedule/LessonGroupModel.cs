namespace DeanerySystem.UI.Models.Education.Schedule {
	public class LessonGroupModel {
		public int GroupId { get; set; }
		public LessonModel FirstRowLesson { get; set; }
		public LessonModel SecondRowLesson { get; set; }
		public bool IsSolid { get; set; }
	}
}
