/// <reference path="../../deanerysystem.clientside.common.definitions/scripts/typings/knockout/knockout.d.ts" />

module DeanerySystem.ClientSide.ViewModels {
	export class LessonGroupVM {
		private readonly TEMPLATE_NAME = "lesson-group-template";
		private readonly EMPTY_TEMPLATE_NAME = "empty-lesson-group-template";

		public TemplateName: KnockoutObservable<string>;

		public FirstRowLesson: KnockoutObservable<LessonVM>;
		public SecondRowLesson: KnockoutObservable<LessonVM>;
		public RowSpanNumber: KnockoutObservable<number>;

		constructor(private lessonGroup?: Schedule.Models.LessonGroupModel) {
			if (this.lessonGroup == null) {
				this.TemplateName = ko.observable(this.EMPTY_TEMPLATE_NAME);
				this.RowSpanNumber = ko.observable(2);
			} else {
				this.TemplateName = ko.observable(this.TEMPLATE_NAME);
				this.FirstRowLesson = ko.observable(new LessonVM(this.lessonGroup.FirstRowLesson));
				this.SecondRowLesson = ko.observable(new LessonVM(this.lessonGroup.SecondRowLesson));
				this.RowSpanNumber = ko.observable(this.lessonGroup.IsSolid ? 2 : 1);
			}
		}
	}
}
