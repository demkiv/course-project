using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.UI.Models.Education {
	public class NumeratorDenomerator {
		public TimeTable NumeratorTimeTable { get; set; }
		public TimeTable DenumeratorTimeTable { get; set; }

		public EducationalPlan NumeratorPlan { get; set; }
		public EducationalPlan DenumeratorPlan { get; set; }

		public bool MergeSell { get; set; }

		public NumeratorDenomerator() : this(null, null, true) { }

        public NumeratorDenomerator(TimeTable numerator, TimeTable denomerator, bool mergeCell) {
            NumeratorTimeTable = numerator;
			DenumeratorTimeTable = denomerator;
			MergeSell = mergeCell;
		}
	}

	public class ScheduleInfo {
		public List<Group> Groups { get; set; }
		public Dictionary<DayOfWeek, List<ClassNumberTime>> Times { get; set; }
		public Dictionary<ClassNumberTime, List<TimeTable>> TimeTables { get; set; }
		public Dictionary<Tuple<ClassNumberTime, Group>, NumeratorDenomerator> NumeratorDenomerators { get; set; }
		public Dictionary<DayOfWeek, int> NumberOfTimes { get; set; }
		public Dictionary<DayOfWeek, string> DayNames { get; set; }
		public List<EducationalPlan> EducationalPlans { get; set; } 

	}
}
