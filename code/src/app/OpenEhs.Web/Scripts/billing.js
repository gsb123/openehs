/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />

$(document).ready(function () {

    $("#billing-tab").addClass("current");

    $("#InvoiceLineItems tbody tr:odd").addClass("striped");


    $("#CreateNewBillingButton").button();
    $("#SearchBillingButton").button();
    $("#PayInFullButton")
            .button()
            .click(function () {
                $("#addPaymentDialog").dialog("open");
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


                $("#addPaymentDialog").dialog({
                    autoOpen: false,
                    height: 200,
                    width: 420,
                    modal: true,
                    buttons: {
                        "Add Payment": function () {
                            $.post("/Billing/AddPayment", {
                                InvoiceId: $("#PaymentInvoiceID").val(),
                                Amount: $("#model_paymentamount").val()
                            }, function (result) {
                                $("#addPaymentDialog").dialog("close");
                                //<tr><td class="DescriptionColumn">@payment.PaymentDate</td><td class="PriceColumn">GH&#x20B5;@payment.CashAmount</td></tr>
                                                        var table = document.getElementById("PaymentsTable");
                        var tr = document.createElement("tr");

                        var elements = new Array();

                        for (var i = 0; i < 2; i++)
                            elements[i] = document.createElement("td");

                        elements[0].appendChild(document.createTextNode(result.Name));
                        elements[1].appendChild(document.createTextNode(result.));

                        for (var i = 0; i < 2; i++)
                            tr.appendChild(elements[i]);

                        table.appendChild(tr);

                            $("#allergyList").append(newAllergy);
                            $("#allergy_" + returnData.allergy.Id).fadeIn("normal", function () {
                                $(this).find(".allergyRemove").button().click(removeOnClick)

                                $("#model_paymentamount").val("");
                            }, "json");
                        },
                        Cancel: function () {
                            $("#model_paymentamount").val("");
                            $(this).dialog("close");
                        }
                    },
                    close: function () {

                    }
                });

//                $("#PayInFullButton").button().click(function () {
//                    $("#addPaymentDialog").dialog("open");
//                });
});