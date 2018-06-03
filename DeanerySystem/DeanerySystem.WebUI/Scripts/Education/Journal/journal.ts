import * as $ from 'jquery';
import QueryStringUtilities from '../../Utils/QueryStringUtilities';

$(document).ready(() => {
	$("select#JournalTypeSelection").change((e) => {
		var journalId = $(e.target).val() as string;
		window.location.href = QueryStringUtilities.updateQueryStringParameter('journalId', journalId);
	});

	$('#submit-mark-form').submit((e) => {
		e.preventDefault();
		e.stopImmediatePropagation();

		var form = $(e.target);
		var submitButton = $("#save-marks-button");

		var marks = [];
		var formData = form.serializeArray();
		formData.forEach((data: JQuery.NameValuePair) => {
			if (data.name === 'mark') {
				marks.push(data.value);
			}
		});
		
		var marksData = {
			marks: marks,
			educationalPlanId: submitButton.data("educationalplanid"),
			classId: submitButton.data("classid"),
			journalId: submitButton.data("journalid")
		};

		$.ajax({
			url: form.attr('action'),
			type: form.attr('method'),
			data: JSON.stringify(marksData),
			contentType: "application/json; charset=utf-8",
			success: (data: any) => {
				alert("Зміни збережено!");
			},
			error: function (jqXhr, textStatus, errorThrown) {
				console.log(textStatus, errorThrown);
			}
		});
	});
});
