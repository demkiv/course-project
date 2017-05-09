﻿module DeanerySystem.ClientSide.Schedule.Models {
	export class LessonNumberModel {
		public Number: number;
		public Start: Date;
		public End: Date;
		public LessonGroups: LessonGroupModel[];

		constructor() { }
	}
}
