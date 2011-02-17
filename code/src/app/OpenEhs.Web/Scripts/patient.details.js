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
    $(".allergyRemove").button({
        icons: {
            primary: "ui-icon-closethick"
        },
        text: false
    }).click(function () {
        $.post("/Patient/RemoveAllergy", {
            patientID: $("#patientId").val(),
            allergyID: $(this).attr("id")
        }, function (returnData) {
            $("#allergyPostStatus").html(returnData.status);
        }, "json");
    });



    // ------------------------------------------------- //
    //  Setup Vitals Tab                                 //
    // ------------------------------------------------- //\

    function addVitalsRow(result) {

        var table = document.getElementById("vitalsTable");
        var tr = document.createElement("tr");

        var dateTd = document.createElement("td");
        var heightTd = document.createElement("td");
        var weightTd = document.createElement("td");
        var temperatureTd = document.createElement("td");
        var heartRateTd = document.createElement("td");
        var bloodPressureTd = document.createElement("td");
        var respiratoryRateTd = document.createElement("td");

        var date = document.createTextNode(result.date);
        var height = document.createTextNode(result.height);
        var weight = document.createTextNode(result.weight);
        var temperature = document.createTextNode(result.temperature);
        var heartRate = document.createTextNode(result.heartRate);
        var bloodPressure = document.createTextNode(result.bpSystolic + "/" + result.bpDiastolic);
        var respiratoryRate = document.createTextNode(result.respiratoryRate);

        dateTd.appendChild(date);
        heightTd.appendChild(height);
        weightTd.appendChild(weight);
        temperatureTd.appendChild(temperature);
        heartRateTd.appendChild(heartRate);
        bloodPressureTd.appendChild(bloodPressure);
        respiratoryRateTd.appendChild(respiratoryRate);

        tr.appendChild(dateTd);
        tr.appendChild(heightTd);
        tr.appendChild(weightTd);
        tr.appendChild(temperatureTd);
        tr.appendChild(heartRateTd);
        tr.appendChild(bloodPressureTd);
        tr.appendChild(respiratoryRateTd);

        table.appendChild(tr);
    }

    $("#newVitalDialog").dialog({
        autoOpen: false,
        height: 400,
        width: 400,
        modal: true,
        buttons: {
            "Save Vital": function () {
                $.ajax({ type: "POST",
                    url: "/Patient/AddVital",
                    data: { patientID: $("#patientId").val(),
                        height: $("#modal_vitalHeight").val(),
                        weight: $("#modal_vitalWeight").val(),
                        temperature: $("#modal_vitalTemperature").val(),
                        heartRate: $("#modal_vitalHeartRate").val(),
                        BpSystolic: $("#modal_vitalBpSystolic").val(),
                        BpDiastolic: $("#modal_vitalBpDiastolic").val(),
                        respiratoryRate: $("#modal_vitalRespiratoryRate").val()
                    },
                    success: function (response) {
                        $("#newVitalDialog").dialog("close");
                        addVitalsRow(response);
                    },
                    dataType: "json"
                });

            },

            Cancel: function () {
                $(this).dialog("close");
            }
        },

        close: function () {
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

    $(".chronicDiseasesRemove").button().click(function () { });


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

    $("#RxStartDatePicker").datepicker({
        showOn: "button",
        buttonImage: "/Content/themes/base/images/calendar.png",
        buttonImageOnly: true,
        changeYear: true
    });

    $("#RxExpDatePicker").datepicker({
        showOn: "button",
        buttonImage: "/Content/themes/base/images/calendar.png",
        buttonImageOnly: true,
        changeYear: true
    });

    // ------------------------------------------------- //
    //  Setup Immunizations List Tab                      //
    // ------------------------------------------------- //

    $("#immunizationAddButton").button().click(function () {
        $("#newImmunizationDialog").dialog("open")
    });

    $("#immunizationInfoLink").click(function () {
        $("#immunizationMoreInfo").slideToggle("slow", function () {
        });
    });

    $("#newImmunizationDialog").dialog({
        autoOpen: false,
        height: 400,
        width: 400,
        modal: true,
        buttons: {
            "Save Immunization": function () {
                $.post("/Patient/AddImmunization",
                {
                    patientID: $("#patientId").val(),
                    vaccinetype: $("#modal_immunizationVaccineType").val(),
                    dateadministered: $("#modal_immunizationDateAdministered").val(),

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

    // ------------------------------------------------- //
    //  Setup DxHistory List Tab                         //
    // ------------------------------------------------- //

    $("#dxHistoryAddButton").button().click(function () {

    });


});