import * as ko from 'knockout';

export class PageBarLinkVM {
    public Text: KnockoutObservable<string>;
    public Link: KnockoutObservable<string>;
    public TemplateName: KnockoutObservable<string>;

    constructor(text: string, link: string) {
        this.Text = ko.observable(text);
        this.Link = ko.observable(link);
        this.TemplateName = ko.observable("page-bar-link");
    }
}

export class PageBarVM {
    public Links: KnockoutObservableArray<PageBarLinkVM>;
    public CurrentPageText: KnockoutObservable<string>;

    constructor(links: PageBarLinkVM[], currentPageText: string) {
        this.Links = ko.observableArray(links);
        this.CurrentPageText = ko.observable(currentPageText);
    }
}
