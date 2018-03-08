interface IDashboardStatisticParameters {
    name: string,
    count: number,
    link: string,
    colorClass: string,
    iconClass: string
}

class DashboardStatisticVM {
    public Name: KnockoutObservable<string>;
    public Count: KnockoutObservable<number>;
    public Link: KnockoutObservable<string>;
    public ColorClass: KnockoutObservable<string>;
    public IconClass: KnockoutObservable<string>;

    constructor(statistic: IDashboardStatisticParameters) {
        this.Name = ko.observable(statistic.name);
        this.Count = ko.observable(statistic.count);
        this.Link = ko.observable(statistic.link);
        this.ColorClass = ko.observable(statistic.colorClass);
        this.IconClass = ko.observable(statistic.iconClass);
    }
}

export = DashboardStatisticVM;
