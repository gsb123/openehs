/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {

    // ------------------------------------------------- //
    //  Setup Charting Tab                                //
    // ------------------------------------------------- //

    //$("#feedAddButton").button().click(function () {
        //alert("Blah");
    //});

    $("#intakeAddButton").button().click(function () {
        alert("Blah");
    });

    $("#suctionAddButton").button().click(function () {
        alert("Blah");
    });

    $("#urineAddButton").button().click(function () {
        alert("Blah");
    });

    $("#stoolAddButton").button().click(function () {
        alert("Blah");
    });

    




    $("#suctionSliderInfoLink").click(function () {
        $("#suctionSliderMoreInfo").slideToggle("slow", function () { });
    });

    $("#urineSliderInfoLink").click(function () {
        $("#urineSliderMoreInfo").slideToggle("slow", function () { });
    });

    $("#stoolSliderInfoLink").click(function () {
        $("#stoolSliderMoreInfo").slideToggle("slow", function () { });
    });

    $("#feedSliderInfoLink").click(function () {
        $("#feedSliderMoreInfo").slideToggle("slow", function () { });
    });

    $("#intakeSliderInfoLink").click(function () {
        $("#intakeSliderMoreInfo").slideToggle("slow", function () { });
    });






    $("#outputSliderInfoLink").click(function () {
        $("#outputSliderMoreInfo").slideToggle("slow", function () { });
    });


    $("#addFeedDialog").dialog({
        autoOpen: false,
        height: 225,
        width: 375,
        modal: true,
        buttons: {
            "Add Allergy": function () {
                    $.post("/Patient/AddFeed", {
                        patientID: $("#patientId").val(),
                        feedType: $("#model_feedtype").val(),
                        amountOffered: $("#model_ammountoffered").val(),
                        amountTaken: $("#model_amounttaken").val(),
                        vomit: $("#model_vomit").val(),
                        urine: $("#model_urine").val(),
                        stool: $("#model_stool").val(),
                        comments: $("#model_comments").val()
                    }, function (returnData) {
                        if (returnData.error == "false") {
                            $("#addFeedDialog").dialog("close");
                            //var newAllergy = '<li class="group" style="display:none" id="allergy_' + returnData.allergy.Id + '"><div style="float: left;">' + returnData.allergy.Name + '</div><div style="float: right;"><input class="allergyRemove" id="' + returnData.allergy.Id + '" type="button" value="Remove" /></div></li>';
                            //$("#allergyList").append(newAllergy);
                            //$("#allergy_" + returnData.allergy.Id).fadeIn("normal", function () {
                            //    $(this).find(".allergyRemove").button().click(removeOnClick)
                            //};
                            alert("you are here");
                        } else {
                            $("#addFeedDialog .error").html(returnData.status);
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

    $("#addFeedForm").submit(function () {
        return false;
    });

    $("#feedAddButton").button().click(function () {
        $("#addFeedDialog").dialog("open");
    });

    $("#addChartingForm .datepicker").datepicker({
        showOn: "button",
        buttonImage: "/Content/themes/base/images/calendar.png",
        buttonImageOnly: true,
        changeYear: true
    }).focus(function () {
        $(this).datepicker("show");
    });

});