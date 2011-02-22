/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {

    // ------------------------------------------------- //
    //  Setup Surgery Tab                                //
    // ------------------------------------------------- //

    var ckConfig = {
        toolbar: [
            ["Bold", "Italic", "-", "NumberedList", "BulletedList", "-"],
            ["UIColor"]
        ],
        extraPlugins: "autogrow",
        autoGrow_maxHeight: 800
    };
    $("#surgeryNoteTextBox").ckeditor(ckConfig);

    $("#submitSurgery").button().click(function () {
        $.ajax({
            type: "POST",
            url: "/Patient/AddSurgery",
            data: {
                patientID: $("#patientId").val(),
                surgeon: $("select[name='surgeonSelect'] option:selected").val(),
                surgeonAssistant: $("select[name='surgeonAssistantSelect'] option:selected").val(),
                anaesthetist: $("select[name='anaesthetistSelect'] option:selected").val(),
                anaesthetistAssistant: $("select[name='anaesthetistAssistantSelect'] option:selected").val(),
                nurse: $("select[name='nurseSelect'] option:selected").val(),
                consultant: $("select[name='consultantSelect'] option:selected").val(),
                surgeryNote: $("#surgeryNoteTextBox").val(),
                startTime: $("#surgeryStartTime").val(),
                endTime: $("#surgeryEndTime").val(),
                theatreNumber: $("select[name='theatreNumber'] option:selected").val(),
                caseType: $("input:radio[name='modal_caseType']:checked").val()
            },
            success: function (response) {
                alert("Submitted");
            },
            dataType: "json"
        });
    });

    var ckConfig = {
        toolbar: [
            ["Bold", "Italic", "-", "NumberedList", "BulletedList", "-"],
            ["UIColor"]
        ],
        extraPlugins: "autogrow",
        autoGrow_maxHeight: 800
    };

    $("#surgeryNoteTextBox").ckeditor(ckConfig);

    $("#surgeryEndTime").timepicker({});

    $("#surgeryStartTime").timepicker({});

    $("#surgeryRadio").buttonset();

});