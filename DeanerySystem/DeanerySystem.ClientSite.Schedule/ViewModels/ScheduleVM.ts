/// <reference path="../../deanerysystem.clientside.common.definitions/scripts/typings/knockout/knockout.d.ts" />

module DeanerySystem.ClientSide.ViewModels {
	export class ScheduleVM {
		public Groups: KnockoutObservableArray<string>;
		public Days: KnockoutObservableArray<DayVM>;

		constructor(private schedule: Schedule.Models.ScheduleModel) {
			var groupNames = this.schedule.Groups.map(g => {
				return g.Name;
			});
			this.Groups = ko.observableArray(groupNames);

			var days = this.schedule.Days.map(day => {
				var groupIds = this.schedule.Groups.map(group => group.Id);
				return new DayVM(day, groupIds);
			});
			this.Days = ko.observableArray(days);
		}
	}
}
