/// <reference path="../../deanerysystem.clientside.common.definitions/scripts/typings/knockout/knockout.d.ts" />
/// <reference path="../models/adress.ts" />

module DeanerySystem.ClientSide.Cabinet {
    export class AdressVM {
        public City: KnockoutObservable<string>;
        public Country: KnockoutObservable<string>;
        public ZIP: KnockoutComputed<string>;

        constructor(adressModel: Adress) {
            this.City = ko.observable(adressModel.City);
            this.Country = ko.observable(adressModel.Country);
            this.ZIP = ko.computed(() => {
                var zip = (this.City.length + this.Country.length) * new Date().getMilliseconds();
                return zip.toString();
            });
        }

        public SayHi(): void {
            alert("Hello Mia!");
        }
    }
}