/// <reference path="../deanerysystem.clientside.common.definitions/scripts/typings/jquery/jquery.d.ts" />
module DeanerySystem.ClientSide.Administration {
    export class Initializer {
        public Initialize(): void {
            
        }

        public InitializeFacultiesOverview(): void {
            var data = <FacultyOverviewModel[]>window["dsFaculties"];
            var facultiesOverviewVM = new FacultiesOverviewVM(data);
            var element = jQuery("#faculties-overview-area");
            ko.applyBindings(facultiesOverviewVM, element.get(0));
        }
    }
}

