/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {
    // ------------------------------------------------- //
    //  Setup Allergy Tab                                //
    // ------------------------------------------------- //

    var removeOnClick = function () {
        $.post("/Patient/RemoveAllergy", {
            patientID: $("#patientId").val(),
            allergyID: $(this).attr("id")
        }, function (returnData) {
            if (returnData.error == "false") {
                $("#allergy_" + returnData.Id).fadeOut("normal", function () {
                    $(this).remove();
                });
            } else {
                alert("Error while adding allergy");
            }
        }, "json");
    };

    $("#addAllergyDialog").dialog({
        autoOpen: false,
        height: 170,
        width: 375,
        modal: true,
        buttons: {
            "Create New Allergy": function () {
                $("#createAllergyDialog").dialog("open");
            },
            "Add Allergy": function () {
                    $.post("/Patient/AddAllergyToPatient", {
                        patientId: $("#patientId").val(),
                        allergyId: $("#addAllergyName").val()
                    }, function (returnData) {
                        if (returnData.error == "false") {
                            $("#addAllergyDialog").dialog("close");

                            var newAllergy = '<li><div style="float: left;">' + returnData.Name + '</div><div style="float: right;"><input class="allergyRemove" id="' + returnData.Id + '" type="button" value="Remove" /></div></li>';
                            $("#allergyList").append(newAllergy);
                            //$("#allergy_" + returnData.Id).fadeIn("normal", function () {
                                //$(this).find(".allergyRemove").button().click(removeOnClick)
                            //});
                        } else {
                            $("#addAllergyDialog .error").html(returnData.status);
                        }
                    }, "json");
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            
        }
    });

    $("#createAllergyDialog").dialog({
        autoOpen: false,
        height: 170,
        width: 420,
        modal: true,
        buttons: {
            "Add Allergy": function () {
                $.post("/Patient/CreateNewAllergy", {
                    AllergyName: $("#modal_allergyName").val()
                }, function (result) {

                    //Need this code for later!!!
                    $("#addAllergyName").append('<option value="' + result.Id + '">' + result.Name + '</option>');

                    $("#modal_allergyName").val("");
                    $("#createAllergyDialog").dialog("close");

                }, "json");
            },
            Cancel: function () {
                $("#modal_allergyName").val("");


                $(this).dialog("close");
            }
        },
        close: function () {

        }
    });

    $("#addAllergyForm").validate();

    $("#addAllergyForm").submit(function () {
        return false;
    });
    $("#allergyAddButton").button().click(function () {
        $("#addAllergyDialog").dialog("open")
    });

    // Add remove function to every allergy remove button
    $(".allergyRemove").button({
        icons: {
            primary: "ui-icon-closethick"
        },
        text: false
    }).click(removeOnClick);
});