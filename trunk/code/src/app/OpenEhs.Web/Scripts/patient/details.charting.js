/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.ui.js" />
/// <reference path="jquery-jvert-tabs-1.1.4.js" />

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

    $("#outakeAddButton").button().click(function () {
        alert("Blah");
    });

    $("#intakeSliderInfoLink").click(function () {
        $("#intakeSliderMoreInfo").slideToggle("slow", function () { });
    });

    $("#outputSliderInfoLink").click(function () {
        $("#outputSliderMoreInfo").slideToggle("slow", function () { });
    });

});