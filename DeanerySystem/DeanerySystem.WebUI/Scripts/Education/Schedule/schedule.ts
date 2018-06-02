import * as $ from 'jquery';
import * as ko from 'knockout';
import ScheduleVM from './ViewModels/ScheduleVM';

$(document).ready(() => {
	var data = (window as any).data;
	var scheduleVM = new ScheduleVM(data);
	ko.applyBindings(scheduleVM);
});
