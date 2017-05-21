using DeanerySystem.Domain.Entities.Enums;
using DeanerySystem.UI.Properties;
using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeanerySystem.UI.Providers
{
	public static class ResourcesProvider
	{
		public static string GetWeekDayDisplay(DayOfWeek day)
		{
			switch (day)
			{
				case DayOfWeek.Sunday: return Resources.Sunday;
				case DayOfWeek.Monday: return Resources.Monday;
				case DayOfWeek.Tuesday: return Resources.Tuesday;
				case DayOfWeek.Wednesday: return Resources.Wednesday;
				case DayOfWeek.Thursday: return Resources.Thursday;
				case DayOfWeek.Friday: return Resources.Friday;
				case DayOfWeek.Saturday: return Resources.Saturday;
				default: throw new InvalidOperationException();
			}
		}

		public static string GetClassTypeDisplay(ClassTypes classType)
		{
			switch (classType)
			{
				case ClassTypes.Lecture: return Resources.Lecture;
				case ClassTypes.PracticalClass: return Resources.PracticalClass;
				case ClassTypes.LaboratoryClass: return Resources.LaboratoryClass;
				default: throw new NotImplementedException($"No display has been found for {classType} class type!");
			}
		}

		public static string GetJournalTypeDisplay(JournalTypes journalType)
		{
			switch (journalType)
			{
				case JournalTypes.Assessment: return Resources.Assessment;
				case JournalTypes.Visiting: return Resources.Visiting;
				default: throw new NotImplementedException($"No display has been found for {journalType} journal type!");
			}
		}

		public static string GetRoleDisplay(IdentityRole identityRole)
		{
			return GetRoleDisplay((Roles)Enum.Parse(typeof(Roles), identityRole.Name));
		}

		public static string GetRoleDisplay(Roles role)
		{
			switch (role)
			{
				case Roles.SuperAdministrator: return Resources.SuperAdministrator;
				case Roles.Administrator: return Resources.Administrator;
				case Roles.Professor: return Resources.Professor;
				case Roles.Student: return Resources.Student;
				default: throw new NotImplementedException($"No display has been found for {role} role!");
			}
		}
	}
}