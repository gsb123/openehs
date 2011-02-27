/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {
    var ckConfig = {
        toolbar: [
            ["Bold", "Italic", "-", "NumberedList", "BulletedList", "-"],
            ["UIColor"]
        ],
        extraPlugins: "autogrow",
        autoGrow_maxHeight: 800
    };
    $("#NotesTextBox").ckeditor(ckConfig);

    $("#submitNoteButton").button().click(function () {
        $("#newNoteDialog").dialog("open");
    });

    $("#newNoteDialog").dialog({
        autoOpen: false,
        height: 600,
        width: 710,
        modal: true,
        buttons: {
            "Submit Note": function () {
                $.post("/Patient/AddNote", {
                    patientID: $("#patientId").val(),
                    NoteBody: escape($("#NotesTextBox").val()),
                    TemplateTitle: $("#templateTitle").val()
                }, function (result) {
                    $("#submitNoteDialog").dialog("close");

                    $("#NotesTextBox").val("");

                }, "json");
            },
            Cancel: function () {
                $("#NotesTextBox").val("");

                $(this).dialog("close");
            }
        },
        close: function () {

        }
    });


    $("#templateNoteCheckBox").live('click', function () {
        var htmlOutput = '<div><br />Template Title:<br /><input id="templateTitle"></div>';

        $("#addTempTitleDIV").replaceWith(htmlOutput);
    });

});