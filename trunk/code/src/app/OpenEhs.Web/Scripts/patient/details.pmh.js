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
                var htmlOutput = "<div id=\"replaceDIV\"><ul class=\"visitSummaryList\"><li><p class=\"visitSummaryHeader\"><u>Encounter</u></p><b>Visit Date: </b>" + checkin.date +
                    "<br /><b>Diagnosis: </b>" + checkin.Diagnosis +
                    "<br /><b>Attending Staff: </b>" + checkin.firstName + ", " + checkin.lastName +
                    "<br /><b>Recorded Vitals: </b><br />" +
                    "<table class=\"detailsTables\"><thead><tr><th>Time</th><th>Type</th><th>Height(cm)</th><th>Weight(kg)</th><th>Temp(&deg;C)</th><th>HR(bpm)</th><th>BP(mmHg)</th><th>RR(Hz)</th></tr></thead><tbody>";

                for (var x = 0; x < checkin.Vitals.length; x++) {

                    var vital = checkin.Vitals[x];

                    htmlOutput += "<tr><td>" + vital.Time + "</td><td>" + vital.type + "</td><td>" + vital.Height + "</td><td>" + vital.Weight + "</td><td>" + vital.Temperature + "</td><td>" + vital.HeartRate + "</td><td>" + vital.BpDiastolic + "/" + vital.BpSystolic + "</td><td>" + vital.RespiratoryRate + "</td></tr>";
                }

                htmlOutput += "</tbody></table>";

                htmlOutput += "<b>Notes: </b><br />This is where all the notes will go when mappings work...";

                htmlOutput += "<div><b>Charting</b></div>";

                htmlOutput += "</li></ul></div>";

                $("#replaceDIV").replaceWith(htmlOutput);
                //Need to add surgery right under encounter stuff... Also ask matt if I can call another POST right here!
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