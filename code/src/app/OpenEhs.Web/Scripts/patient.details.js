$(document).ready(function () {
    var allergyEditId;
    var allergyEditName;
    var name = $( "#modal_allergyName" ),
        allFields = $( [] ).add( name ),
        tips = $( ".validateTips" );
                
    $("#patientView").jVertTabs();


    $("#DateOfBirth").datepicker({
        showOn: "button",
        buttonImage: "/Content/themes/base/images/calendar.png",
        buttonImageOnly: true,
        changeYear: true
    });


    $("#EmergencyContactMoreInfoLink").click(function() {
        $("#EmergencyContactMoreInfo").slideToggle("slow", function() {
        });
    });

    $("#BasicMoreInfoLink").click(function() {
        $("#BasicMoreInfo").slideToggle("slow", function() {
        });
    });

    $( "#allergyDialog" ).dialog({
        autoOpen: false,
        height: 250,
        width: 350,
        modal: true,
        buttons: {
            "Save Allergy": function() {
                $.post("Patient/EditAllergy", {
                    patientID: "@Model.Id",
                    allergyID: allergyEditId,
                    allergyName: allergyEditName 
                    }, function(data) {
                        var returnData = jQuery.parseJSON(data);
                        console.log(returnData);
                        $("#allergyPostStatus").html(returnData.status);
                        $( this ).dialog( "close" );
                });
            },
            Cancel: function() {
                $( this ).dialog( "close" );
            }
        },
        close: function() {
            allFields.removeClass( "ui-state-error" );
        }
    });

        $("#newVitalDialog").dialog({
        autoOpen: false,
        height: 400,
        width: 400,
        modal: true,
        buttons: {
            "Save Vital": function() 
            {
                $.post("/Patient/AddVital", 
                {
                    patientID: "@Model.Id",
                    height: document.getElementById("modal_vitalHeight").value,
                    weight: document.getElementById("modal_vitalWeight").value,
                    temperature: document.getElementById("modal_vitalTemperature").value,
                    heartRate: document.getElementById("modal_vitalHeartRate").value,
                    BpSystolic: document.getElementById("modal_vitalBpSystolic").value,
                    BpDiastolic: document.getElementById("modal_vitalBpDiastolic").value,
                    respiratoryRate: document.getElementById("modal_vitalRespiratoryRate").value
                });
                $( this ).dialog("close");

            },
            Cancel: function() {
                $( this ).dialog( "close" );
            }
        },
        close: function() {
            allFields.removeClass("ui-state-error");
        }
    });

    $(".allergyEditButton").button().click(function() {
        allergyEditId = $(this).attr("id");
        allergyEditName = $(this).attr("name");
        $("#modal_allergyName").val(allergyEditName);
        $("#allergyDialog").dialog("open");
    });  

    $(".vitalAddButton").button().click(function() {
        $("#newVitalDialog").dialog("open");
    });  


    $( "#diseaseDialog" ).dialog({
        autoOpen: false,
        height: 300,
        width: 350,
        modal: true,
        buttons: {
            "Save Disease": function() {
                var bValid = true;
                allFields.removeClass( "ui-state-error" );

                if ( bValid ) {
                    $( this ).dialog( "close" );
                }
            },
            Cancel: function() {
                $( this ).dialog( "close" );
            }
        },
        close: function() {
            allFields.removeClass( "ui-state-error" );
        }
    });

    $(".diseaseEditButton").button().click(function() {
        $("#diseaseDialog").dialog("open");
    });    
            
    $(".allergyAddButton").button().click(function() 
    {
                
    });  

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

    $(".chronicDiseasesAddButton").button().click(function() 
    {
                
    });  
            
    $(".medicationAddButton").button().click(function() 
    {
        $("#newMedicationDialog").dialog("open");
    });    
            
    $(".medicationPrintButton").button().click(function() 
    {
                
    });


    // **** New Medication Modal Dialog **** //
    $("#newMedicationDialog").dialog({
        autoOpen: false,
        height: 400,
        width: 400,
        modal: true,
        buttons: {
            "Save Medication": function() 
            {
                $.post("/Patient/AddMedication", 
                {
                    patientID: "@Model.Id",
                    name: document.getElementById("modal_medicationName").value,
                    instructions: document.getElementById("modal_medicationInstructions").value,
                    startdate: document.getElementById("startDatePicker").value,
                    expdate: document.getElementById("expDatePicker").value
                            
                });
                $( this ).dialog("close");

            },
            Cancel: function() {
                $( this ).dialog( "close" );
            }
        },
        close: function() {
            allFields.removeClass("ui-state-error");
        }
    });

    $(function() {
        $("#startDatePicker").datepicker();
    });

    $(function() {
        $("#expDatePicker").datepicker();
    });                   
});