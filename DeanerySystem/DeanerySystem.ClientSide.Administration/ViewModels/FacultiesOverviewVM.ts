module DeanerySystem.ClientSide.Administration {
    export class FacultiesOverviewVM {
        public Faculties: KnockoutObservableArray<FacultyOverviewVM>;
        public TemplateName: KnockoutObservable<string>;

        constructor(faculties: FacultyOverviewModel[]) {
            var facultiesVMs = faculties.map((f) => { return new FacultyOverviewVM(f); });
            this.Faculties = ko.observableArray(facultiesVMs);
            var templateName = faculties && faculties.length > 0 ? "faculties-overview" : "faculties-overview-empty";
            this.TemplateName = ko.observable(templateName);
            this.Faculties.subscribe(() => {
                var templateName = this.Faculties && this.Faculties.length > 0
                    ? "faculties-overview"
                    : "faculties-overview-empty";
                this.TemplateName = ko.observable(templateName);
            });
        }
    }
}