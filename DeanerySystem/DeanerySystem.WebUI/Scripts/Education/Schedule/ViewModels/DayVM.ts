import * as ko from 'knockout';
import * as DTO from '../DTO';
import LessonNumberVM from './LessonNumberVM';

class DayVM {
	public TemplateName: string = "day-template";

	public Name: KnockoutObservable<string>;
	public LessonNumbers: KnockoutObservableArray<LessonNumberVM>;
	public RowSpanNumber: KnockoutObservable<number>;

	constructor(private day: DTO.DayModel, private groups: number[]) {
		this.Name = ko.observable(day.Name);

		var lessonNumbers = day.LessonNumbers.sort((a, b) => a.Number - b.Number).map(ln => {
			return new LessonNumberVM(ln, groups);
		});
		this.LessonNumbers = ko.observableArray(lessonNumbers);

		this.RowSpanNumber = ko.observable(2 * lessonNumbers.length);
	}
}

export default DayVM;
