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
                var table = document.getElementById("detailsTable");
                var tr = document.createElement("tr");

                var elements = new Array();

                for (var i = 0; i < 2; i++)
                    elements[i] = document.createElement("td");

                elements[0].appendChild(document.createTextNode(response.Name));
                elements[1].appendChild(document.createTextNode(response.Quantity));

                for (var i = 0; i < 2; i++)
                    tr.appendChild(elements[i]);

                table.appendChild(tr);

                $("select[name='productSelect'] option:selected").val("");
                $("select[name='serviceSelect'] option:selected").val("");
                $("select[name='quantitySelect'] option:selected").val("");
            },
            dataType: "json"
        });
    });


});