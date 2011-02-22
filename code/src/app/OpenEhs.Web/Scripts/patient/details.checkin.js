/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.ui.js" />
/// <reference path="jquery-jvert-tabs-1.1.4.js" />

$(function () {
    // ------------------------------------------------- //
    //  Setup Check In Modal                             //
    // ------------------------------------------------- //
    $("#newCheckinModal").dialog({
        autoOpen: false,
        height: 225,
        width: 375,
        modal: true,
        buttons: {
            "Check In": function () {
                $.ajax({
                    type: "POST",
                    url: "/Patient/AddCheckIn",
                    data: {
                        patientID: $("#patientId").val(),
                        PatientType: $('input:radio[name="modal_checkinType"]:checked').val(),
                        staffId: $("select[name='staff'] option:selected").val(),
                        locationId: $("select[name='location'] option:selected").val()
                    },
                    success: function (response) {
                        $("#newCheckInButton").hide();
                        $("#newCheckinModal").dialog("close");
                        $("#checkOutButton").show();
                        $("#vitalAddButton").button("enable");
                    },
                    dataType: "json"
                });
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () { }
    });

    // ------------------------------------------------- //
    //  Setup Check Out Modal                             //
    // ------------------------------------------------- //
    $("#checkOutModal").dialog({
        autoOpen: false,
        height: 225,
        width: 375,
        modal: true,
        buttons: {
            "Check Out": function () {
                $.ajax({
                    type: "POST",
                    url: "/Patient/CheckOut",
                    data: {
                        patientID: $("#patientId").val(),
                        diagnosis: $("#modal_checkOutDiagnosis").val()
                    },
                    success: function (response) {
                        $("#checkOutButton").hide();
                        $("#checkOutModal").dialog("close");
                        $("#newCheckInButton").show();
                        $("#vitalAddButton").button("disable");
                    },
                    dataType: "json"
                });
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () { }
    });

    $("#checkinRadio").buttonset();
})