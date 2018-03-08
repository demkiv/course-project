module DeanerySystem.ClientSide.Schedule {
    export class DataProvider {
        public static GetSchelude(): JQueryPromise<Models.ScheduleModel> {
			var deferrer = jQuery.Deferred<Models.ScheduleModel>();

			$.get("../api/schedule/getSchedule", function (data) {
				deferrer.resolve(data);
			});

			return deferrer.promise();
		}
	}
}
