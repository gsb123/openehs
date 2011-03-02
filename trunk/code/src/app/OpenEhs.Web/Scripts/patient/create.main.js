/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {
    $("input[type=button]").button();

    // Turns off autocomplete for all text inputs
    $("input[type=text]").attr("autocomplete", "off");

    $("#ageDialog").dialog({
        autoOpen: false,
        height: 170,
        width: 200,
        modal: true,
        buttons: {
            "Calculate DoB": function () {
                var date = new Date();
                date.setFullYear(date.getFullYear - $("#modal_age").val());
                $('#DateOfBirth').datepicker("setDate", date);
                $(this).dialog("close");
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {

        }
    });

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

    $("#btnAge").click(function () {
        $("#ageDialog").dialog("open");
    });
});