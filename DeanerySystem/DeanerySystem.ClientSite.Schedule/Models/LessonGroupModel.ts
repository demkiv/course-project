module DeanerySystem.ClientSide.Schedule.Models {
	export class LessonGroupModel {
		public GroupId: number;
		public FirstRowLesson: LessonModel;
		public SecondRowLesson: LessonModel;
		public IsSolid: boolean;

		constructor() { }
	}
}
