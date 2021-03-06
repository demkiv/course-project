﻿import * as ko from 'knockout';
import * as DTO from '../DTO';
import LessonGroupVM from './LessonGroupVM';

class LessonNumberVM {
	public TemplateName: string = "lesson-number-template";

	public Number: KnockoutObservable<number>;
	public Time: KnockoutComputed<string>;
	public LessonGroups: KnockoutObservableArray<LessonGroupVM>;

	constructor(private lessonNumber: DTO.LessonNumberModel, private groups: number[]) {
		this.Number = ko.observable(lessonNumber.Number);

		this.Time = ko.computed(function () {
			return lessonNumber.Start + " - " + lessonNumber.End;
		});

		var lessonGroups = new Array<LessonGroupVM>();
		this.groups.forEach(group => {
			var lessonGroup = ko.utils.arrayFirst(this.lessonNumber.LessonGroups, lg => lg.GroupId == group);
			lessonGroups.push(new LessonGroupVM(lessonGroup));
		});

		this.LessonGroups = ko.observableArray(lessonGroups);
	}
}

export default LessonNumberVM;
