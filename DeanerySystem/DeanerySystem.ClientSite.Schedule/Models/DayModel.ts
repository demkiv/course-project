module DeanerySystem.ClientSide.Schedule.Models {
	export class DayModel {
		public Day: string;
		public DayRowSpan: number;
		public LessonNumberModels: LessonNumberModel[];

		constructor() {	}
	}
}
