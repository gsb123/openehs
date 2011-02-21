/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />

$(document).ready(function () {
    $("#CreateNewBillingButton").button();
    $("#SearchBillingButton").button();
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