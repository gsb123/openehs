/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.ui.js" />
/// <reference path="jquery-jvert-tabs-1.1.4.js" />

$(function () {
    // ------------------------------------------------- //
    //  Setup Visit History List Tab                     //
    // ------------------------------------------------- //
    $("#visitNoteLink").click(function () {
        $("#visitNoteMoreInfo").slideToggle("slow", function () { });
    });

    $("#visitVitalsLink").click(function () {
        $("#visitVitalsMoreInfo").slideToggle("slow", function () { });
    });

    $("#visitPastLink").click(function () {
        $("#visitPastMoreInfo").slideToggle("slow", function () { });
    });

    $("#visitVitalsLinkSearch").click(function () {
        $("#visitVitalsMoreInfoSearch").slideToggle("slow", function () { });
    });

    $("#searchThisVisit").click(function () {
        alert("test");
    });

    $("#visitNoteLinkSearch").click(function () {
        $("#visitNoteMoreInfoSearch").slideToggle("slow", function () { });
    });

    $("#visitHistorySearchButton").button().click(function () {
        $.ajax({
            type: "POST",
            url: "/Patient/SearchVisit",
            data: {
                patientID: $("#patientId").val(),
                from: $("#from").val(),
                to: $("#to").val()
            },
            success: function (response) {
                //addSearchRow(response);

                alert(response.length);

                //Outputs the dates between the selected dates
                for (var i = 0; i < response.length; i++) {
                    var select = '<tr><td><input class="visitDateButton" type="button" value="' + response[i].date + '" /></td></tr>';
                    $("#selectSearchTable").append(select);
                }

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

    $(".visitDateButton").live("click", function () {
        alert("Patient Id: " + $("#patientId").val() + ", Visit Date: " + $(this).val());
    });


    function addSearchRow(result) {
        /*
        alert(result.length);
        for (var i = 0; i < result.length; i++)
        {
        alert("Diagnosis: " + result[i].Diagnosis);
        alert("Check-in Time: " + result[i].CheckInTime);

        for(var x = 0; x < result[i].Vitals.length; x++)
        {
        var vital = result[i].Vitals[x];

        alert("Blood Pressure: " + vital.BpSystolic + "/" + vital.BpDiastolic);
        }
        }
        */
    }

    var dates = $("#from, #to").datepicker({
        defaultDate: "+1w",
        changeMonth: true,
        numberOfMonths: 1,
        onSelect: function (selectedDate) {
            var option = this.id == "from" ? "minDate" : "maxDate",
                    instance = $(this).data("datepicker");
            date = $.datepicker.parseDate(
                instance.settings.dateFormat || $.datepicker._defaults.dateFormat, selectedDate, instance.settings);
            dates.not(this).datepicker("option", option, date);
        }
    });
});