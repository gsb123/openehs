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

                //Code fore table (DO NOT DELETE)
                /*
                for (var i = 0; i < 1; i++)
                {
                for(var x = 0; x < response[i].Vitals.length; x++)
                {

                var vital = response[i].Vitals[x];

                var searchResult = '<ul id="visitHistorySearchList"><li class="group"><div style="float: left;"><b>Visit Date: </b>' + response[0].date + '</div><br /><div style="float: left;"><b>Diagnosis: </b>' + response[0].Diagnosis + '</div><br />     <div><div><b>' + "Vitals:" + '</b></div></div><div><table id="vitalHistory1" class="vitalsHist1"><thead><tr><th>' + "Time" + '</th><th>' + "Type" + '</th><th>' + "Height(cm)" + '</th><th>' + "Weight(kg)" + '</th><th>' + "Temp(&deg;C)" + '</th><th>' + "HR(bpm)" + '</th><th>' + "BP(mmHg)" + '</th><th>' + "RR(Hz)" + '</th></tr></thead><tbody><tr><td>' + vital.Time + '</td><td>' + vital.type + '</td><td>' + vital.Height + '</td><td>' + vital.Weight + '</td><td>' + vital.Temperature + '</td><td>' + vital.HeartRate + '</td><td>' + vital.BpSystolic + "/" + vital.BpDiastolic + '</td><td>' + vital.RespiratoryRate + '</td></tr></tbody></table><div><b>' + "Notes: " + '</b>' + "This is where notes go!" + '</div></li></ul>';
                //console.log(searchResult);
                $("#visitHistorySearchList").replaceWith(searchResult);
                }
                }
                */

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