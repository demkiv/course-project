import * as ko from 'knockout';
import * as DTO from '../DTO';
import LessonVM from './LessonVM';

class LessonGroupVM {
	private readonly TemplateNameEmpty = "lesson-group-template-empty";
	private readonly TemplateNameWithContent = "lesson-group-template";

	public TemplateName: KnockoutObservable<string>;

	public FirstRowLesson: KnockoutObservable<LessonVM>;
	public SecondRowLesson: KnockoutObservable<LessonVM>;
	public RowSpanNumber: KnockoutObservable<number>;

	constructor(private lessonGroup?: DTO.LessonGroupModel) {
		if (this.lessonGroup == null) {
			this.TemplateName = ko.observable(this.TemplateNameEmpty);
			this.RowSpanNumber = ko.observable(2);
		} else {
			this.TemplateName = ko.observable(this.TemplateNameWithContent);

			var lessons = this.lessonGroup.Lessons;
			var integerLesson = ko.utils.arrayFirst(lessons, lg => lg.Fraction == DTO.Fractions.Integer);

			if (integerLesson == null) {
				var numeratorLesson = ko.utils.arrayFirst(lessons, lg => lg.Fraction == DTO.Fractions.Numerator);
				this.FirstRowLesson = ko.observable(new LessonVM(numeratorLesson));

				var denominatorLesson = ko.utils.arrayFirst(lessons, lg => lg.Fraction == DTO.Fractions.Denominator);
				this.SecondRowLesson = ko.observable(new LessonVM(denominatorLesson));

				this.RowSpanNumber = ko.observable(1);
			} else {
				this.FirstRowLesson = ko.observable(new LessonVM(integerLesson));
				this.SecondRowLesson = ko.observable(new LessonVM(null));
				this.RowSpanNumber = ko.observable(2);
			}
		}
	}
}

export default LessonGroupVM;
