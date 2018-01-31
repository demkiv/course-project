var AdministrationModule = function () {
    
    //toastr.options = {
    //    "closeButton": true,
    //    "debug": false,
    //    "newestOnTop": false,
    //    "progressBar": false,
    //    "positionClass": "toast-top-center",
    //    "preventDuplicates": false,
    //    "onclick": null,
    //    "showDuration": "300",
    //    "hideDuration": "1000",
    //    "timeOut": "5000",
    //    "extendedTimeOut": "1000",
    //    "showEasing": "swing",
    //    "hideEasing": "linear",
    //    "showMethod": "fadeIn",
    //    "hideMethod": "fadeOut"
    //}
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
    var loadUniversityManagement = function () {
        $.ajax({
            url: "/Admin/ManageUniversity/",
            dataType: "html",
            method: "GET",
            success: function (data) {
                $("#university_management_content").html(data);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
    var saveUniversityInfo = function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: {
                universityModel: {
                    Name: $("#university_name").val(),
                    RectorId: $("#rector_name").val()
                },
            },
            success: function (data) {
                $("#university_name_label").text(data.Name);
                switchToDisplayMode();
               // toastr["success"]("Зміни збережено!")
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
    var switchToEditMode = function () {
        getAllProfessors();
        $("#manage_university_display_mode").hide();
        $("#manage_university_edit_mode").show();
    }

    var getAllProfessors = function () {
        $.ajax({
            url: "/Admin/GetAllProfessors/",
            dataType: "JSON",
            method: "GET",
            success: function (data) {
                $.each(data, function (i, professor) {
                    $("#rector_name").append($("<option/>").val(professor.Id).text(professor.FirstName + " " + professor.LastName));
                });
                $("#rector_name").select2();
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
    var switchToDisplayMode = function () {
        $("#manage_university_edit_mode").hide();
        $("#manage_university_display_mode").show();
    }
    var bind = function () {
        $("#university_management").on("click", getUniversityTab);
        $("#switch_to_edit_mode").on("click", switchToEditMode);
        $("#university_info_form").on("submit", saveUniversityInfo);
    }

    var init = function () {

        bind();

    }
    return {
        Bind: bind
    }
}();

$(document).ready(AdministrationModule.Bind);