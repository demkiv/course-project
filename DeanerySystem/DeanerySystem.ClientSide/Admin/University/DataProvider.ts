import DTO = require("DTO");

class DataProvider {
    public static GetUniversityData(): JQueryPromise<DTO.UniversityModel> {
        var deferrer = jQuery.Deferred<DTO.UniversityModel>();

        $.get("../../api/admin/universityData", function (data) {
            deferrer.resolve(data);
        });

        return deferrer.promise();
    }
}

export = DataProvider;
