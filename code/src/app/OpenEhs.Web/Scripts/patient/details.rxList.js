/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.ui.js" />
/// <reference path="jquery-jvert-tabs-1.1.4.js" />

$(function () {

    // ------------------------------------------------- //
    //  Setup Rx List Tab                                //
    // ------------------------------------------------- //
    $(".medicationAddButton").button().click(function () {
        $("#newMedicationDialog").dialog("open");
    });

    $(".medicationPrintButton").button().click(function () { });

    $("#rxInfoLink").click(function () {
        $("#rxMoreInfo").slideToggle("slow", function () { });
    });

    $("#addRxForm").validate({
        errorLabelContainer: $("#newMedicationDialog .modalErrorContainer"),
        wrapper: "li",
        messages: {
            name: "A medication name is required",
            instructions: "Instructions are required",
            startdate: "A start date is required",
            expdate: "An expiration date is required"
        }
    });

    $("#newMedicationDialog").dialog({
        autoOpen: false,
        height: 300,
        width: 350,
        modal: true,
        buttons: {
            "Save Medication": function () {
                if ($("#addRxForm").valid()) {
                    $.post("/Patient/AddMedication", {
                        patientID: $("#patientId").val(),
                        name: $("#modal_medicationName").val(),
                        instructions: $("#modal_medicationInstructions").val(),
                        startDate: $("#RxStartDatePicker").val(),
                        expDate: $("#RxExpDatePicker").val()
                    }, function (response) {
                        if (response.error == "false") {
                            $("#MedicationListOne").hide();
                            $("#addRxForm").dialog("close");
                            var newMedication = '<li id="medication_' + response.medication.id + '" class="group" style="display:none"><div><b>Name: </b>' + response.medication.name + '</div><div><b>Instructions: </b>' + response.medication.instructions + '</div><div><b>Start Date: </b>' + response.medication.startDate + '</div><div><b>Exp Date: </b>' + response.medication.expDate + '</div></li>';
                            console.log(newMedication);
                            $("#MedicationListTwo").append(newMedication);
                            $("#medication_" + response.medication.id).fadeIn("normal", function () { });
                        } else {
                            alert("Error adding medication");
                        }
                    });
                    $(this).dialog("close");
                }
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            $("#newMedicationDialog .modalErrorContainer").hide();
            $('#addRxForm').each(function () {
                this.reset();
            });
        }
    });

    $("#addRxForm .datepicker").datepicker({
        showOn: "button",
        buttonImage: "/Content/themes/base/images/calendar.png",
        buttonImageOnly: true,
        changeYear: true
    }).focus(function () {
        $(this).datepicker("show");
    });

});