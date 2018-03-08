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
