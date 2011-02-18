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

$(document).ready(function () {
    $("#NewServiceButton").button();
    $("#NewProductButton").button();
    $("#NewLineItemButton")
        autoOpen: false,
        height: 225,
        width: 375,
        modal: true,
        buttons: {
            "Add Line Item": function () {
                if ($("#addLineItemForm").valid()) {
                    $.post("/Billing/AddLineItem", {
                        invoiceID: $("#invoiceId").val(),
                        allergyName: $("#LineItemName").val()
                    }, function (returnData) {
                        if (returnData.error == "false") {
                            $("#LineItemPostStatus").html(returnData.status);
                            $(this).dialog("close");
                        } else {
                            $("#addLineItemDialog .error").html(returnData.status).animate;
                        }
                    }, "json");
                }
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {

        }
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
