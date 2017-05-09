/// <reference path="../../deanerysystem.clientside.common.definitions/scripts/typings/knockout/knockout.d.ts" />

module DeanerySystem.ClientSide.ViewModels {
	export class DayVM {
		public TemplateName: string = "day-template";

		public Name: KnockoutObservable<string>;
		public LessonNumbers: KnockoutObservableArray<LessonNumberVM>;
		public RowSpanNumber: KnockoutObservable<number>;

		constructor(private day: Schedule.Models.DayModel, private groups: number[]) {
			this.Name = ko.observable(day.Name);

			var lessonNumbers = day.LessonNumbers.sort((a, b) => a.Number - b.Number).map(ln => {
				return new LessonNumberVM(ln, groups);
			});
			this.LessonNumbers = ko.observableArray(lessonNumbers);

			this.RowSpanNumber = ko.observable(2 * lessonNumbers.length);
		}
	}
}
