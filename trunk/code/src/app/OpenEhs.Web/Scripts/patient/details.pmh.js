/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {


    $("#surgeryLink").click(function () {
        $("#surgeryInfo").slideToggle("slow", function () { });
    });

    $("#noteLink").click(function () {
        $("#noteInfo").slideToggle("slow", function () { });
    });

    $("#staffLink").click(function () {
        $("#staffInfo").slideToggle("slow", function () { });
    });

});