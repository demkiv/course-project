/// <reference path="../deanerysystem.clientside.common.definitions/scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../deanerysystem.clientside.common.utilities/querystring.ts" />

module DeanerySystem.ClientSide.Schedule {
	export class DataProvider {
		public static GetSchelude(): JQueryPromise<Models.ScheduleModel> {
			var deferrer = jQuery.Deferred();

			$.get("../api/schedule/getSchedule", function (data) {
				deferrer.resolve(data);
			});

			return deferrer.promise();
		}
	}
}
