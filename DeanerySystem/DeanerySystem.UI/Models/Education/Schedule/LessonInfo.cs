using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.UI.Models.Education.Schedule {
	public class LessonInfo {
		public Fractions Fraction { get; set; }
		public string Subject { get; set; }
		public string Lector { get; set; }
		public string Type { get; set; }
		public string JornalLink { get; set; }
	}
}
