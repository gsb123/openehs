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

                
                for (var i = 0; i < 1; i++)
                {
                for(var x = 0; x < response[i].Vitals.length; x++)
                {

                var vital = response[i].Vitals[x];

                var searchResult = '<div id="replaceDIV"><b>' + "Visit Date: " + '</b>' + response[0].date + '</div>';
                //console.log(searchResult);
                $("#replaceDIV").replaceWith(searchResult);
                }
                }
              

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