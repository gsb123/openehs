/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {
    // ------------------------------------------------- //
    //  Setup Basic Tab                                  //
    // ------------------------------------------------- //
    $("#DateOfBirth").datepicker({
        showOn: "button",
        buttonImage: "/Content/themes/base/images/calendar.png",
        buttonImageOnly: true,
        changeYear: true
    });

    $("#EmergencyContactMoreInfoLink").click(function () {
        $("#EmergencyContactMoreInfo").slideToggle("slow", function () { });
    });

    $("#BasicMoreInfoLink").click(function () {
        $("#BasicMoreInfo").slideToggle("slow", function () { });
    });

    $("#checkOutButton").button();
    $("#checkOutButton").hide();

    $("#modal_TimeOfDeath").timepicker({});

    $("#newCheckInButton").button().click(function () {
        $("#newCheckinModal").dialog("open");
    });

    $("#checkOutButton").button().click(function () {
        $("#checkOutModal").dialog("open");
    });

    $("#editPatientInfoButton").button().click(function () {

    });

    // ------------------------------------------------- //
    //  Configure CKEditor on Patient Note               //
    // ------------------------------------------------- //
    var ckConfig = {
        toolbar: [
            ["Bold", "Italic", "-", "NumberedList", "BulletedList", "-"],
            ["UIColor"]
        ],
        extraPlugins: "autogrow",
        autoGrow_maxHeight: 800
    };

    $("#patientNoteTextBox").ckeditor(ckConfig);

});