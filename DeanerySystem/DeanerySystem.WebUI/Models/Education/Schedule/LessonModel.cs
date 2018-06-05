using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.WebUI.Models.Education.Schedule 
{
	public class LessonModel 
	{
		public Fractions Fraction { get; set; }
		public string Subject { get; set; }
		public string Lector { get; set; }
		public string Type { get; set; }
		public string JournalLink { get; set; }
	}
}
