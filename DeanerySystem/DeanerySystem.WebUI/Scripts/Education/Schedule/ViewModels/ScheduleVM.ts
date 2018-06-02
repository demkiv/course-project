import * as ko from 'knockout';
import * as DTO from '../DTO';
import DayVM from './DayVM';

class ScheduleVM {
	public Groups: KnockoutObservableArray<string>;
	public Days: KnockoutObservableArray<DayVM>;

	constructor(private schedule: DTO.ScheduleModel) {
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

export default ScheduleVM;
