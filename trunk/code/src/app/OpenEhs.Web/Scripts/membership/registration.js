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
            success: function (data) { $("#status").fadeTo(500, 1, function () { $(this).html("You are now registered!").fadeTo(5000, 0); }) },
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
        //        $.ajax({
        //            type: "POST",
        //            url: "/Account/CheckForUsernameAvailability",
        //            data: "username=" + username,
        //            success: function (msg) {
        //                alert(msg + " is available!");
        //            }
        //        });

        alert("I got here.");

        $.post("/Account/CheckForUsernameAvailability",
                username,
                function (data) {
                    alert("Is available!");
                    $("#Username").val(data.username);
                    $("#generatedUsername").html(data.username);
                },
                "json"
        );
    }
});
