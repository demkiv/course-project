var AdministrationModule = function () {
    var getUniversityTab = function () {
        $.ajax({
            url: "/Admin/ManageUniversity/",
            dataType: "html",
            method: "GET",
            success: function (data) {
                $("#university_tab").html(data);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
    var bind = function () {
        $("#university_management").on("click", getUniversityTab);

    }
    return {
        Bind: bind
    }
}();

$(document).ready(AdministrationModule.Bind);