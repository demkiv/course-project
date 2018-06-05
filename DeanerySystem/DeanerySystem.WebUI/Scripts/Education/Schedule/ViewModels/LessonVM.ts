import * as ko from 'knockout';
import * as DTO from '../DTO';

class LessonVM {
	private readonly TemplateNameEmpty = "lesson-template-empty";
	private readonly TemplateNameWithContent = "lesson-template";

	public TemplateName: KnockoutObservable<string>;

	public Subject: KnockoutObservable<string>;
	public Lector: KnockoutObservable<string>;
	public Type: KnockoutObservable<string>;
	public JournalLink: KnockoutObservable<string>;

	constructor(private lessonGroup?: DTO.LessonModel) {
		if (lessonGroup == null) {
			this.TemplateName = ko.observable(this.TemplateNameEmpty);
		} else {
			this.TemplateName = ko.observable(this.TemplateNameWithContent);
			this.Subject = ko.observable(lessonGroup.Subject);
			this.Lector = ko.observable(lessonGroup.Lector);
			this.Type = ko.observable(lessonGroup.Type);
			this.JournalLink = ko.observable(lessonGroup.JournalLink);
		}
	}
}

export default LessonVM;
