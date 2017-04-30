/// <reference path="../../deanerysystem.clientside.common.definitions/scripts/typings/knockout/knockout.d.ts" />
/// <reference path="../models/contactinfo.ts" />
/// <reference path="../models/adress.ts" />

module DeanerySystem.ClientSide.Cabinet {
    export class ContactInfoVM {
        public FirstName: KnockoutObservable<string>;
        public LastName: KnockoutObservable<string>;
        public Age: KnockoutObservable<number> = ko.observable(null);
        public AdressVMs: KnockoutObservableArray<AdressVM>;
        public TextColor: KnockoutObservable<string>;

        constructor(contactInfo: ContactInfo) {
            this.FirstName = ko.observable(contactInfo.FirstName);
            this.LastName = ko.observable(contactInfo.LastName);
            
            var adressVMs: AdressVM[] = [];
            contactInfo.Adresses.forEach((x) => {
                adressVMs.push(new AdressVM(x));
            });
            this.AdressVMs = ko.observableArray(adressVMs);
            this.TextColor = ko.observable("black");
            this.Initialize();
            this.Age(contactInfo.Age);
        }

        private Initialize(): void {
            this.Age.subscribe((val) => {
                if (val > 21) {
                    this.TextColor("green");
                } else if (val > 18) {
                    this.TextColor("yellow");
                } else {
                    this.TextColor("red");
                }
            });
        }
    }
}