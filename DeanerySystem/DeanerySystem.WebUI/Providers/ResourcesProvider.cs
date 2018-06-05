using DeanerySystem.DataAccess.Entities.Enums;
using System;

namespace DeanerySystem.WebUI.Providers
{
	public static class ResourcesProvider
	{
		public static string GetWeekDayDisplay(DayOfWeek day)
		{
			switch (day)
			{
				case DayOfWeek.Sunday: return Resources.DayOfWeek.Sunday;
				case DayOfWeek.Monday: return Resources.DayOfWeek.Monday;
				case DayOfWeek.Tuesday: return Resources.DayOfWeek.Tuesday;
				case DayOfWeek.Wednesday: return Resources.DayOfWeek.Wednesday;
				case DayOfWeek.Thursday: return Resources.DayOfWeek.Thursday;
				case DayOfWeek.Friday: return Resources.DayOfWeek.Friday;
				case DayOfWeek.Saturday: return Resources.DayOfWeek.Saturday;
				default: throw new InvalidOperationException();
			}
		}

		public static string GetClassTypeDisplay(ClassTypes classType)
		{
			switch (classType)
			{
				case ClassTypes.Lecture: return Resources.ClassTypes.Lecture;
				case ClassTypes.PracticalClass: return Resources.ClassTypes.PracticalClass;
				case ClassTypes.LaboratoryClass: return Resources.ClassTypes.LaboratoryClass;
				default: throw new NotImplementedException($"No display has been found for {classType} class type!");
			}
		}

		public static string GetJournalTypeDisplay(JournalTypes journalType)
		{
			switch (journalType)
			{
				case JournalTypes.Assessment: return Resources.JournalTypes.Assessment;
				case JournalTypes.Visiting: return Resources.JournalTypes.Visiting;
				default: throw new NotImplementedException($"No display has been found for {journalType} journal type!");
			}
		}

		//public static string GetRoleDisplay(IdentityRole identityRole)
		//{
		//	return GetRoleDisplay((Roles)Enum.Parse(typeof(Roles), identityRole.Name));
		//}

		public static string GetRoleDisplay(Roles role)
		{
			switch (role)
			{
				case Roles.SuperAdministrator: return Resources.Roles.SuperAdministrator;
				case Roles.Administrator: return Resources.Roles.Administrator;
				case Roles.Professor: return Resources.Roles.Professor;
				case Roles.Student: return Resources.Roles.Student;
				default: throw new NotImplementedException($"No display has been found for {role} role!");
			}
		}
	}
}
