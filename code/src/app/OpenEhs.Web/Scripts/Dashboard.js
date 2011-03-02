/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {

    $("#showOpenCheckins").button().click(function () {
        $.ajax({
            type: "POST",
            url: "/Dashboard/ActiveCheckIns",
            data: {
                loc: $("select[name='loactionBox'] option:selected").val()
            },
            success: function (response) {
                var table = document.getElementById("searchCheckinResult");
                var rows = table.getElementsByTagName("tr");
                for (var i = rows.length - 1; i >= 0; i--) {
                    table.deleteRow(i);
                }
                $.each(response.bob, function (index, Data) {
                    var tr = document.createElement("tr");

                    var elements = new Array();

                    for (var i = 0; i < 2; i++)
                        elements[i] = document.createElement("td");

                    elements[0].appendChild(document.createTextNode(Data.ID));
                    elements[1].appendChild(document.createTextNode(Data.Name));


                    for (var i = 0; i < 2; i++)
                        tr.appendChild(elements[i]);

                    table.appendChild(tr);
                });

            },
            dataType: "json"
        });

    });

});

//patientID: $("#patientId").val(),
//loc: $("select[name='loactionBox'] option:selected").val()