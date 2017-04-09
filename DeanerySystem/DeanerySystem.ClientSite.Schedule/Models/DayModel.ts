module DeanerySystem.ClientSide.Schedule.Models {
	export class DayModel {
		public Id: number;
		public Name: string;
		public DayRowSpan: number;
		public LessonNumbers: LessonNumberModel[];

		constructor() {	}
	}
}
