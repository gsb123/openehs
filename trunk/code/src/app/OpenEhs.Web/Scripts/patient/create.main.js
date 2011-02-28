/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {


    $(".CreateNewPatientButton").button().click(function () {
        $("#createPatientDialog").dialog("open");
    });


    $("#createPatientDialog").dialog({
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




    function postCreatePatient() {
        /// <summary>
        /// Posts all the data necessary for creating a new patient from the new patient wizard
        /// </summary>
        $.post("/Patient/CreatePatient", {
            p_firstName: $("#p_firstName").val(),
            p_middleName: $("#p_middleName").val(),
            p_lastName: $("#p_lastName").val(),
            p_dob: $("#p_dob").val(),
            p_gender: $("#p_gender").val(),
            p_phoneNumber: $("#p_phoneNumber").val(),
            p_bloodType: $("#p_bloodType").val(),
            p_tribeRace: $("#p_tribeRace").val(),
            p_religion: $("#p_religion").val(),
            p_address_street1: $("#p_address_street1").val(),
            p_address_street2: $("#p_address_street2").val(),
            p_address_City: $("#p_address_City").val(),
            p_address_Region: $("#p_address_Region").val(),
            p_address_Country: $("#p_address_Country").val(),
            emergency_firstName: $("#emergency_firstName").val(),
            emergency_lastname: $("#emergency_lastname").val(),
            emergency_relationship: $("#emergency_relationship").val(),
            emergency_phonenumber: $("#emergency_phonenumber").val(),
            ec_address_street1: $("#ec_address_street1").val(),
            ec_address_street2: $("#ec_address_street2").val(),
            ec_address_City: $("#ec_address_City").val(),
            ec_address_Region: $("#ec_address_Region").val(),
            ec_address_Country: $("#ec_address_Country").val(),


        }, function (response) {
            if (response.error == "false") {
                // Patient added successfuly, should probably show a confirmation div
            } else {
                alert("Error while adding patient\n\nError: " + response.errorMessage);
            }
        });
    }

});