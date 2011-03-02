/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {
    $("input[type=button]").button();
    // Turns off autocomplete for all text inputs
    $("input[type=text]").attr("autocomplete", "off");
    $("#DateOfBirth").datepicker({
        showOn: "button",
        buttonImage: "/Content/themes/base/images/calendar.png",
        buttonImageOnly: true,
        changeYear: true,
        yearRange: "1900:@DateTime.Now.Year"

    }).focus(function () {
        $("#DateOfBirth").datepicker("show");
    });

    $("#newPatientContainer form").formwizard({
        formPluginEnabled: false,
        historyEnabled: true,
        validationEnabled: true,
        focusFirstInput: true,
        disableUIStyles: true
    });
});