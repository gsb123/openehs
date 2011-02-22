/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {

    // ------------------------------------------------- //
    //  Setup Charting Tab                                //
    // ------------------------------------------------- //

    $("#feedAddButton").button().click(function () {
        alert("Blah");
    });

    $("#intakeAddButton").button().click(function () {
        alert("Blah");
    });

    $("#suctionAddButton").button().click(function () {
        alert("Blah");
    });

    $("#urineAddButton").button().click(function () {
        alert("Blah");
    });

    $("#stoolAddButton").button().click(function () {
        alert("Blah");
    });




    $("#suctionSliderInfoLink").click(function () {
        $("#suctionSliderMoreInfo").slideToggle("slow", function () { });
    });




    $("#outputSliderInfoLink").click(function () {
        $("#outputSliderMoreInfo").slideToggle("slow", function () { });
    });

});