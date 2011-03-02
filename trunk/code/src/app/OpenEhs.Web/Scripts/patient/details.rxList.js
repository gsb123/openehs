/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

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
    //instructions: "Instructions are required",
    expdate: "An expiration date is required"
    }
    });

    $("#newMedicationDialog").dialog({
        autoOpen: false,
        height: 250,
        width: 350,
        modal: true,
        buttons: {
            "Create New Medication": function () {
                $("#createMedicationDialog").dialog("open");
            },
            "Save Medication": function () {
                if ($("#addRxForm").valid()) {
                $.post("/Patient/AddMedicationToPatient", {
                    patientID: $("#patientId").val(),
                    name: $("#medicationDropDownList").val(),
                    instructions: $("#modal_medicationInstructions").val(),
                    expDate: $("#RxExpDatePicker").val()
                }, function (response) {
                    if (response.error == "false") {

                        //$("#MedicationListOne").hide();
                        $("#addRxForm").dialog("close");

                        var newMedication = '<li><div><b>Name: </b>' + response.name + '</div><div><b>Instructions: </b>' + response.instructions + '</div><div><b>Start Date: </b>' + response.startDate + '</div><div><b>Exp Date: </b>' + response.expDate + '</div></li>';
                        //console.log(newMedication);
                        $("#MedicationListTwo").append(newMedication);

                        //$("#medication_" + response.medication.id).fadeIn("normal", function () { });

                        $("#patientId").val("");
                        $("#medicationDropDownList").val("");
                        $("#modal_medicationInstructions").val("");
                        $("#RxExpDatePicker").val("");

                    } else {
                        alert("Error adding medication");
                    }
                });
                $(this).dialog("close");
                }
            },
            Cancel: function () {
                $("#patientId").val("");
                $("#medicationDropDownList").val("");
                $("#modal_medicationInstructions").val("");
                $("#RxExpDatePicker").val("");

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

    $("#createMedicationDialog").dialog({
        autoOpen: false,
        height: 200,
        width: 420,
        modal: true,
        buttons: {
            "Add Medication": function () {
                $.post("/Patient/CreateNewMedication", {
                    MedicationName: $("#modal_medicationName").val(),
                    MedicationDescription: $("#modal_medicationDescription").val()
                }, function (result) {

                    $("#medicationDropDownList").append('<option value="' + result.Id + '">' + result.Name + '</option>');

                    $("#modal_medicationName").val("");
                    $("#modal_medicationDescription").val("");

                    $("#createMedicationDialog").dialog("close");

                }, "json");
            },
            Cancel: function () {
                $("#modal_medicationName").val("");
                $("#modal_medicationDescription").val("");


                $(this).dialog("close");
            }
        },
        close: function () {

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