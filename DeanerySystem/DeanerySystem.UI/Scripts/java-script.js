$(document).ready(function () {

	$("#loader").click(function () {
		console.log("xxx");
		$.ajax({
			url: "http://localhost:4401/Admin/ManageUniversity/",
			dataType: "html",
			method: "GET",
			success: function (data) {
				console.log(data);
			},
			error: function (jqXhr, textStatus, errorThrown) {
				console.log(textStatus, errorThrown);
			}
		});
	});

    $(document).on("click", "#back-button", function () {
        window.location.href = $(this).data("url");
    });

    $("select#JournalTypeSelection").change(function () {
    	var educationalPlanId = $("#save-marks-button").data("educationalplanid");
        var classId = $("#save-marks-button").data("classid");
        window.location.href = "/Education/Journal?educationalPlanId=" + educationalPlanId + "&classId=" + classId + "&journalId=" + $(this).val();
    });

    $(document).on("submit", "#submit-mark-form", function (e) {
    	debugger;
    	e.preventDefault();
    	e.stopImmediatePropagation();

        var educationalPlanId = $("#save-marks-button").data("educationalplanid");
        var classId = $("#save-marks-button").data("classid");
        var journalId = $("#save-marks-button").data("journalid");
       
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: {
                marks : $(this).serialize(),
                educationalPlanId: educationalPlanId,
                classId : classId,
                journalId: journalId
            },
            success: function (data) {
                alert("Зміни збережено!");
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });

    });

});

