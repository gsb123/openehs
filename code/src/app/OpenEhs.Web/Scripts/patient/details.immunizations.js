/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.ui.js" />
/// <reference path="jquery-jvert-tabs-1.1.4.js" />

$(function () {
    // ------------------------------------------------- //
    //  Setup Immunizations List Tab                     //
    // ------------------------------------------------- //
    $("#immunizationAddButton").button().click(function () {
        $("#newImmunizationDialog").dialog("open")
    });

    $("#immunizationInfoLink").click(function () {
        $("#immunizationMoreInfo").slideToggle("slow", function () { });
    });

    $("#newImmunizationDialog").dialog({
        autoOpen: false,
        height: 400,
        width: 400,
        modal: true,
        buttons: {
            "Save Immunization": function () {
                $.post("/Patient/AddImmunization", {
                    patientID: $("#patientId").val(),
                    vaccinetype: $("#modal_immunizationVaccineType").val(),
                    dateadministered: $("#modal_immunizationDateAdministered").val()
                });
                $(this).dialog("close");

            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            allFields.removeClass("ui-state-error");
        }
    });
});