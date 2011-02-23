/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {


    function postCreatePatient() {
        /// <summary>
        /// Posts all the data necessary for creating a new patient from the new patient wizard
        /// </summary>
        $.post("/Patient/CreatePatient", {
            p_firstName: $("#p_firstName").val(),
            p_middleName: $("#p_middleName").val(),
            p_lastName: $("#p_lastName").val(),
            p_dob: $("#p_dob").val(),
            p_gender: $("#p_gender").val(),
            p_phoneNumber: $("#p_phoneNumber").val(),
            p_bloodType: $("#p_bloodType").val(),
            p_tribeRace: $("#p_tribeRace").val(),
            p_religion: $("#p_religion").val()

        }, function (response) {
            if (response.error == "false") {
                // Patient added successfuly, should probably show a confirmation div
            } else {
                alert("Error while adding patient\n\nError: " + response.errorMessage);
            }
        });
    }

});