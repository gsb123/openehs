/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />



$(document).ready(function () {
    // ------------------------------------------------- //
    //  Initialize jVerticalTabs Plugin                  //
    // ------------------------------------------------- //
    $("#patientView").jVertTabs();


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
        $("#EmergencyContactMoreInfo").slideToggle("slow", function () {
        });
    });

    $("#BasicMoreInfoLink").click(function () {
        $("#BasicMoreInfo").slideToggle("slow", function () {
        });
    });


    // ------------------------------------------------- //
    //  Configure CKEditor on Patient Note               //
    // ------------------------------------------------- //
    var ckConfig = {
        toolbar:
        [
            ["Bold", "Italic", "-", "NumberedList", "BulletedList", "-"],
            ["UIColor"]
        ],
        extraPlugins: "autogrow",
        autoGrow_maxHeight: 800
    };

    $("#patientNoteTextBox").ckeditor(ckConfig);


    // ------------------------------------------------- //
    //  Setup Allergy Tab                                //
    // ------------------------------------------------- //
    $("#addAllergyDialog").dialog({
        autoOpen: false,
        height: 225,
        width: 375,
        modal: true,
        buttons: {
            "Add Allergy": function () {
                if ($("#addAllergyForm").valid()) {
                    $.post("/Patient/AddAllergy", {
                        patientID: $("#patientId").val(),
                        allergyName: $("#addAllergyName").val()
                    }, function (returnData) {
                        if (returnData.error == "false") {
                            $("#allergyPostStatus").html(returnData.status);
                            $(this).dialog("close");
                        } else {
                            $("#addAllergyDialog .error").html(returnData.status).animate;
                        }
                    }, "json");
                }
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {

        }
    });

    $("#addAllergyForm").validate();

    $("#allergyAddButton").button().click(function () {
        $("#addAllergyDialog").dialog("open")
    });

    // Add remove function to every allergy remove icon
    $(".allergyRemove").click(function () {
        $.post("/Patient/RemoveAllergy", {
            patientID: $("#patientId").val(),
            allergyID: $(this).attr("id")
        }, function (returnData) {
            $("#allergyPostStatus").html(returnData.status);
        }, "json");
    });


    // ------------------------------------------------- //
    //  Setup Vitals Tab                                 //
    // ------------------------------------------------- //
    $("#newVitalDialog").dialog({
        autoOpen: false,
        height: 400,
        width: 400,
        modal: true,
        buttons: {
            "Save Vital": function () {
                $.post("/Patient/AddVital",
                {
                    patientID: $("#patientId").val(),
                    height: $("#modal_vitalHeight").val(),
                    weight: $("#modal_vitalWeight").val(),
                    temperature: $("#modal_vitalTemperature").val(),
                    heartRate: $("#modal_vitalHeartRate").val(),
                    BpSystolic: $("#modal_vitalBpSystolic").val(),
                    BpDiastolic: $("#modal_vitalBpDiastolic").val(),
                    respiratoryRate: $("#modal_vitalRespiratoryRate").val()
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

    $(".vitalAddButton").button().click(function () {
        $("#newVitalDialog").dialog("open");
    });


    // ------------------------------------------------- //
    //  Setup Chronic Diseases Tab                       //
    // ------------------------------------------------- //
    $("#diseaseDialog").dialog({
        autoOpen: false,
        height: 300,
        width: 350,
        modal: true,
        buttons: {
            "Save Disease": function () {
                var bValid = true;
                allFields.removeClass("ui-state-error");

                if (bValid) {
                    $(this).dialog("close");
                }
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            allFields.removeClass("ui-state-error");
        }
    });

    $(".diseaseEditButton").button().click(function () {
        $("#diseaseDialog").dialog("open");
    });

    $(".chronicDiseasesAddButton").button().click(function () { });


    // ------------------------------------------------- //
    //  Setup Prescription List Tab                      //
    // ------------------------------------------------- //
    $(".medicationAddButton").button().click(function () {
        $("#newMedicationDialog").dialog("open");
    });

    $(".medicationPrintButton").button().click(function () { });

    $("#newMedicationDialog").dialog({
        autoOpen: false,
        height: 400,
        width: 400,
        modal: true,
        buttons: {
            "Save Medication": function () {
                $.post("/Patient/AddMedication",
                {
                    patientID: $("#patientId").val(),
                    name: $("#modal_medicationName").val(),
                    instructions: $("#modal_medicationInstructions").val(),
                    startdate: $("#startDatePicker").val(),
                    expdate: $("#expDatePicker").val()

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

    $(function () {
        $("#startDatePicker").datepicker();
    });

    $(function () {
        $("#expDatePicker").datepicker();
    });

    // ------------------------------------------------- //
    //  Setup Immunization List Tab                      //
    // ------------------------------------------------- //

    $(".immunizationAddButton").button().click(function () {
        
    });

});