export class ScheduleModel {
	public Groups: GroupModel[];
	public Days: DayModel[];

	constructor() { }
}

export class GroupModel {
	public Id: number;
	public Name: string;

	constructor() { }
}

export class DayModel {
	public Id: number;
	public Name: string;
	public DayRowSpan: number;
	public LessonNumbers: LessonNumberModel[];

	constructor() { }
}

export class LessonNumberModel {
	public Number: number;
	public Start: Date;
	public End: Date;
	public LessonGroups: LessonGroupModel[];

	constructor() { }
}

export class LessonGroupModel {
	public GroupId: number;
	public Lessons: LessonModel[];

	constructor() { }
}

export class LessonModel {
	public Fraction: Fractions;
	public Subject: string;
	public Lector: string;
	public Type: string;
	public JournalLink: string;

	constructor() { }
}

export enum Fractions {
	Numerator,
	Denominator,
	Integer
}
