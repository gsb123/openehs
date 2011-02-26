/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {

    //----------------------------------------------//
    // Add new Line Item                            //
    //----------------------------------------------//

    $("#submitInvoiceItem").button().click(function () {
        $.ajax({
            type: "POST",
            url: "/Patient/AddInvoiceItem",
            data: {
                patientID: $("#patientId").val(),
                product: $("select[name='productSelect'] option:selected").val(),
                service: $("select[name='serviceSelect'] option:selected").val(),
                quantity: $("select[name='quantitySelect'] option:selected").val()
            },
            success: function (response) {
                alert("Submitted");
            },
            dataType: "json"
        });
    });


});