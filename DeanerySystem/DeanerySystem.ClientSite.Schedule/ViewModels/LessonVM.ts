/// <reference path="../../deanerysystem.clientside.common.definitions/scripts/typings/knockout/knockout.d.ts" />

module DeanerySystem.ClientSide.ViewModels {
	export class LessonVM {
		private readonly TEMPLATE_NAME = "lesson-template";
		private readonly EMPTY_TEMPLATE_NAME = "empty-lesson-template";

		public TemplateName: KnockoutObservable<string>;

		//public Fraction: Fractions;
		public Subject: KnockoutObservable<string>;
		public Lector: KnockoutObservable<string>;
		public Type: KnockoutObservable<string>;
		public PlanId: KnockoutObservable<number>;
		public ClassId: KnockoutObservable<number>;

		constructor(private lessonGroup?: Schedule.Models.LessonModel) {
			if (lessonGroup == null) {
				this.TemplateName = ko.observable(this.EMPTY_TEMPLATE_NAME);
			} else {
				this.TemplateName = ko.observable(this.TEMPLATE_NAME);
				this.Subject = ko.observable(lessonGroup.Subject);
				this.Lector = ko.observable(lessonGroup.Lector);
				this.Type = ko.observable(lessonGroup.Type);
			}
		}
	}
}
