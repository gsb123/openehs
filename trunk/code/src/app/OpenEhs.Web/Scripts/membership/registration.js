/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.form.wizard-3.0.4.js" />
/// <reference path="../jquery-ui.js" />
/// <reference path="../jquery.form.js" />


$(function () {
    $("#registrationForm").formwizard({
        formPluginEnabled: true,
        validationEnabled: true,
        focusFirstInput: true,
        formOptions: {
            success: function (data) { $(location).attr("href", "/dashboard"); },
            beforeSubmit: function (data) { $("#data").html("data sent to the server: " + $.param(data)); },
            dataType: 'json',
            resetForm: true
        }
    });

    $("#lastNameTextbox").blur(function () {
        if ($("#firstNameTextbox").val() != "") {
            CheckForUsernameAvailability($("#firstNameTextbox").val() + "." + $("#lastNameTextbox").val());
        }
    });

    function CheckForUsernameAvailability(username) {
        var paramData = { "username": username };

        $.post("/Account/CheckForUsernameAvailability",
                paramData,
                function (data) {
                    $("#Username").val(data.requestedUsername);
                    $("#generatedUsername").html(data.requestedUsername);
                },
                "json"
        );
    }
});
