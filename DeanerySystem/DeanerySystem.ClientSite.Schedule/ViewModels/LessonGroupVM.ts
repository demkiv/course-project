/// <reference path="../../deanerysystem.clientside.common.definitions/scripts/typings/knockout/knockout.d.ts" />

module DeanerySystem.ClientSide.ViewModels {
	export class LessonGroupVM {
		private readonly TemplateNameEmpty = "lesson-group-template-empty";
		private readonly TemplateNameWithContent = "lesson-group-template";

		public TemplateName: KnockoutObservable<string>;

		public FirstRowLesson: KnockoutObservable<LessonVM>;
		public SecondRowLesson: KnockoutObservable<LessonVM>;
		public RowSpanNumber: KnockoutObservable<number>;

		constructor(private lessonGroup?: Schedule.Models.LessonGroupModel) {
			if (this.lessonGroup == null) {
				this.TemplateName = ko.observable(this.TemplateNameEmpty);
				this.RowSpanNumber = ko.observable(2);
			} else {
				this.TemplateName = ko.observable(this.TemplateNameWithContent);
				this.FirstRowLesson = ko.observable(new LessonVM(this.lessonGroup.FirstRowLesson));
				this.SecondRowLesson = ko.observable(new LessonVM(this.lessonGroup.SecondRowLesson));
				this.RowSpanNumber = ko.observable(this.lessonGroup.IsSolid ? 2 : 1);
			}
		}
	}
}
