/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {


    $(".surgeryLink").click(function () {
        $(".surgeryInfo").slideToggle("slow", function () { });
    });

    $(".noteLink").click(function () {
        $(".noteInfo").slideToggle("slow", function () { });
    });

    $(".submitSelectButton").click(function () {
        //$(".staffInfo").slideToggle("slow", function () { });
        $.ajax({
            type: "POST",
            url: "/Patient/SearchVisitList",
            data: {
                patientID: $("#patientId").val(),
                checkInID: $("select[name='visitPick'] option:selected").val()
            },
            success: function (response) {

                var checkin = response[0];
                var htmlOutput = "<div id=\"replaceDIV\"><b>Visit Date: </b>" + checkin.date +
                    "<br /><b>Testing: </b>" + checkin.Diagnosis +
                    "<br /><b>Vitals: </b><br />" +
                    "<table class=\"detailsTables\"><thead><tr><th>Time</th><th>Type</th></tr></thead><tbody>";

                for (var x = 0; x < checkin.Vitals.length; x++) {

                    var vital = checkin.Vitals[x];

                    htmlOutput += "<tr><td>" + vital.Time + "</td><td>" + vital.type + "</td></tr>";

                    //console.log(searchResult);
                }

                htmlOutput += "</tbody></table></div>";

                $("#replaceDIV").replaceWith(htmlOutput);
            },
            dataType: "json"
        });

    });

    $(".visitVitalsLink").click(function () {
        $(".visitVitalsMoreInfo").slideToggle("slow", function () { });
    });

    $(".visitNoteLink").click(function () {
        $(".visitNoteMoreInfo").slideToggle("slow", function () { });
    });

});