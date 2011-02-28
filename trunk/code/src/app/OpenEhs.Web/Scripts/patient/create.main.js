/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {
    $("#createPatientForm").formwizard({
        formPluginEnabled: true,
        validationEnabled: true,
        focusFirstInput: true,
        formOptions: {
            success: function (data) {
                $("#status").fadeTo(500, 1, function () {
                    $(this).html("You are now registered!").fadeTo(5000, 0);
                })
            },
            beforeSubmit: function (data) {
                $("#data").html("data sent to the server: " + $.param(data));
            },
            dataType: 'json',
            resetForm: true
        }
    });

    $(".navigation_button").button();
});