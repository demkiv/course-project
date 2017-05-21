/// <reference path="../../deanerysystem.clientside.common.definitions/scripts/typings/knockout/knockout.d.ts" />
module DeanerySystem.ClientSide.Administration {
    export class UniversityInfoVM {
        public Title: KnockoutObservable<string>;
        public RectorId: KnockoutObservable<string>;
        public RectorDisplayName: string; 
         
        constructor(universityModel: UniversityModel) {
            this.Title = ko.observable(universityModel.Name);
            this.RectorId = ko.observable(universityModel.RectorId);
            this.RectorDisplayName = `${universityModel.RectorFirstName} ${universityModel.RectorLastName}`;
        }
    }
}