/// <reference path="../deanerysystem.clientside.common.definitions/scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../deanerysystem.clientside.common.definitions/scripts/typings/knockout/knockout.d.ts" />
/// <reference path="../deanerysystem.clientside.common.utilities/querystring.ts" />

module DeanerySystem.ClientSide.Schedule {
	export class Initializer {
		public Initialize() {
			DataProvider.GetSchelude().done(schedule => {
				var scheduleVM = new ViewModels.ScheduleVM(schedule);
				ko.applyBindings(scheduleVM);
			});
		}
	}
}

$(document).ready(() => {
	var initializer = new DeanerySystem.ClientSide.Schedule.Initializer();
	initializer.Initialize();
});
