import DataProvider = require("DataProvider");
import UniversityVM = require("ViewModels/UniversityVM");

export class Initializer {
    public Start() {
        DataProvider.GetUniversityData().done(schedule => {
            var scheduleVM = new UniversityVM(schedule);
            ko.applyBindings(scheduleVM);
        });
    }
}
