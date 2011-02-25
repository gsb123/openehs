/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {

    $("#showOpenChecins").button().click(function () {
			$.ajax({
            type: "POST",
            url: "/Dashboard/ActiveCheckIns",
            button: {
                patientID: $("#patientId").val(),
				loc: $("select[name='loactionBox'] option:selected").val()
            },
            success: function (response) {
                alert("Submitted");
            },
            dataType: "json"
        });
    });

});