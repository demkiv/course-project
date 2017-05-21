module DeanerySystem.ClientSide.Administration {
    export class FacultyOverviewVM {
        public Id: KnockoutObservable<string>;
        public Name: KnockoutObservable<string>;
        public PictureUrl: KnockoutObservable<string>;

        constructor(model: FacultyOverviewModel) {
            this.Id = ko.observable(model.Id);
            this.Name = ko.observable(model.Name);
            this.PictureUrl = ko.observable(model.PictureUrl);
        }
    }
}