/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />



$(document).ready(function () {
    // ------------------------------------------------- //
    //  Initialize jVerticalTabs Plugin                  //
    // ------------------------------------------------- //
    $("#patientView").jVertTabs({
        equalHeights: true
    });

    $("#radio").buttonset();

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

    $("#newCheckInButton").button().click(function () {
        
    });

    $("#editPatientInfoButton").button().click(function () {
        
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



    function processVitalsReturn(result) {
        if(result.error=="false")
        {
            var table = document.getElementById("vitalsTable");
            var tr = document.createElement("tr");

            var elements = new Array();

            for(var i=0;i<7;i++)
                elements[i] = document.createElement("td");
            
            elements[0].appendChild(document.createTextNode(result.date));

            if(result.height!="0")
                elements[1].appendChild(document.createTextNode(result.height));
            else
                elements[1].appendChild(document.createTextNode("N/A"));
                
            if(result.weight!="0")
                elements[2].appendChild(document.createTextNode(result.weight));
            else
                elements[2].appendChild(document.createTextNode("N/A"));
            
            if(result.temperater!="0")
                elements[3].appendChild(document.createTextNode(result.temperature));
            else
                elements[3].appendChild(document.createTextNode("N/A"));

            if(result.heartRate!="0")
                elements[4].appendChild(document.createTextNode(result.heartRate));
            else
                elements[4].appendChild(document.createTextNode("N/A"));

            if(result.bpSystolic!="0")
                elements[5].appendChild(document.createTextNode(result.bpSystolic + "/" + result.bpDiastolic));
            else
                elements[5].appendChild(document.createTextNode("N/A"));

            if(result.respiratoryRate!="0")
                elements[6].appendChild(document.createTextNode(result.respiratoryRate));
            else
                elements[6].appendChild(document.createTextNode("N/A"));

            for(var i=0;i<7;i++)
                tr.appendChild(elements[i]);

            table.appendChild(tr);

            //Reset form
            $("#patientId").val("");
            $("#modal_vitalHeight").val("");
            $("#modal_vitalWeight").val("");
            $("#modal_vitalTemperature").val("");
            $("#modal_vitalHeartRate").val("");
            $("#modal_vitalBpSystolic").val("");
            $("#modal_vitalBpDiastolic").val("");
            $("#modal_vitalRespiratoryRate").val("");

        }
        else
            alert ("Error");
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
                        processVitalsReturn(response);
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

    $("#rxInfoLink").click(function () {
        $("#rxMoreInfo").slideToggle("slow", function () {
        });
    });

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
    //  Setup Visit History List Tab                     //
    // ------------------------------------------------- //

     $("#visitNoteLink").click(function () {
        $("#visitNoteMoreInfo").slideToggle("slow", function () {
        });
    });

    $("#visitVitalsLink").click(function () {
        $("#visitVitalsMoreInfo").slideToggle("slow", function () {
        });
    });

    $("#visitPastLink").click(function () {
        $("#visitPastMoreInfo").slideToggle("slow", function () {
        });
    });

    $("#visitVitalsLinkSearch").click(function () {
        $("#visitVitalsMoreInfoSearch").slideToggle("slow", function () {
        });
    });

    $("#visitNoteLinkSearch").click(function () {
        $("#visitNoteMoreInfoSearch").slideToggle("slow", function () {
        });
    });

    $("#visitHistorySearchButton").button().click(function () {
        $.ajax({ type: "POST",
                    url: "/Patient/SearchVisit",
                    data: { patientID: $("#patientId").val(),
                        from: $("#from").val(),
                        to: $("#to").val()
                    },
                    success: function (response) {
                        addSearchRow(response);
                    },
                    dataType: "json"
                });

    });

    function addSearchRow(result) {

        for(var list in result)
            document.write(list.CheckInTime);

    }

    $(function() {
		var dates = $( "#from, #to" ).datepicker({
			defaultDate: "+1w",
			changeMonth: true,
			numberOfMonths: 3,
			onSelect: function( selectedDate ) {
				var option = this.id == "from" ? "minDate" : "maxDate",
					instance = $( this ).data( "datepicker" );
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings );
				dates.not( this ).datepicker( "option", option, date );
			}
		});
	});

});