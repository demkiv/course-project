import DashboardStatisticVM = require("DashboardStatisticVM");
import DTO = require("../DTO");
import PageBar = require("../../../Common/Utilities/PageBar");

class UniversityVM {
    public Name: KnockoutObservable<string>;
    public UniversityStatistics: KnockoutObservableArray<DashboardStatisticVM>;
    public PageBar: KnockoutObservable<PageBar.PageBarVM>;

    constructor(private university: DTO.UniversityModel) {
        this.Name = ko.observable(university.Name);

        var homeLink = new PageBar.PageBarLinkVM("Головна", "/home");
        this.PageBar = ko.observable(new PageBar.PageBarVM([homeLink], "Адміністрування"));

        var universityStatistics = university.UniversityStatisticsModel;
        var statistics = [
            new DashboardStatisticVM({
                name: "Факультети",
                count: universityStatistics.FacultiesCount,
                link: "#",
                colorClass: "blue",
                iconClass: "fa-university"
            }),
            new DashboardStatisticVM({
                name: "Потоки",
                count: universityStatistics.StreamsCount,
                link: "#",
                colorClass: "red",
                iconClass: "fa-graduation-cap"
            }),
            new DashboardStatisticVM({
                name: "Кафедри",
                count: universityStatistics.DepartmentsCount,
                link: "#",
                colorClass: "green",
                iconClass: "fa-cubes"
            }),
            new DashboardStatisticVM({
                name: "Групи",
                count: universityStatistics.GroupsCount,
                link: "#",
                colorClass: "purple",
                iconClass: "fa-users"
            }),
            new DashboardStatisticVM({
                name: "Викладачі",
                count: universityStatistics.ProfessorsCount,
                link: "#",
                colorClass: "green-meadow",
                iconClass: "fa-briefcase"
            }),
            new DashboardStatisticVM({
                name: "Студенти",
                count: universityStatistics.StudentsCount,
                link: "#",
                colorClass: "yellow-crusta",
                iconClass: "fa-child"
            })
        ];
        this.UniversityStatistics = ko.observableArray(statistics);
    }

    public AfterRender(element: Element) {
        (<any>jQuery(element).find('.counter')).counterUp();
    }
}

export = UniversityVM;
