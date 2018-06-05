export class UniversityModel {
	public Name: string;
	public UniversityStatisticsModel: UniversityStatisticsModel;

	constructor() { }
}

export class UniversityStatisticsModel {
	public FacultiesCount: number;
	public StreamsCount: number;
	public DepartmentsCount: number;
	public GroupsCount: number;
	public ProfessorsCount: number;
	public StudentsCount: number;

	constructor() { }
}
