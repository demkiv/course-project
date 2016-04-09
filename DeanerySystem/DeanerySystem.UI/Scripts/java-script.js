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
        //alert($("#save-marks-button").data("subjectid") + " " + $("#save-marks-button").data("journalid") + " " + $(this).val());
        var subjectId = $("#save-marks-button").data("subjectid");
        var journalId = $("#save-marks-button").data("journalid");
        window.location.href = "/Journal/Journal?subjectId=" + subjectId + "&journalId=" + journalId + "&actualJournalTypeId=" + $(this).val();
    });

    $(document).on("submit", "#submit-mark-form", function(e) {
        //alert("submit");
        alert($(this).serialize());
        alert($("#save-marks-button").data("subjectid"));
        alert($("#save-marks-button").data("journalid"));
        alert($("#save-marks-button").data("journaltypeid"));

        var subjectId = $("#save-marks-button").data("subjectid");
        var journalId = $("#save-marks-button").data("journalid");
        var journalTypeId = $("#save-marks-button").data("journaltypeid");

        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: {
                marks : $(this).serialize(),
                subjectId : subjectId,
                journalId : journalId,
                journalTypeId: journalTypeId
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

