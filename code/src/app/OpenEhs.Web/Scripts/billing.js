/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />

$(document).ready(function () {


    // ------------------------------------------------- //
    //  Billing search                                   //
    // ------------------------------------------------- //

    $(document).ready(function () {
        $("#CreateNewBillingButton").button();

    });

    $(document).ready(function () {
        $("#SearchBillingButton").button();

    });

});

    $("#PayInFullButton")
                .button()
                .click(function () {
                })
                .next()
                    .button({
                        text: false,
                        icons: {
                            primary: "ui-icon-triangle-1-s"
                        }
                    })
                    .click(function () {
                        alert("Menu!");
                    })
                    .parent()
                        .buttonset();
});
