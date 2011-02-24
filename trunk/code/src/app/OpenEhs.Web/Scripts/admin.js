/// <reference path="../jquery-1.4.4.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.ui.js" />
/// <reference path="../jquery-jvert-tabs-1.1.4.js" />

$(function () {

    $("#addUser").button().click(function () {
        alert("Add user button");
    });

    $("#editUser").button().click(function () {
        alert("Edit user button");
    });

    $("#deleteUser").button().click(function () {
        alert("Delete user button");
    });

    $("#addProduct").button().click(function () {
        alert("Add product button");
    });

    $("#editProduct").button().click(function () {
        alert("Edit product button");
    });

    $("#deleteProduct").button().click(function () {
        alert("Delete product button");
    });

    $("#editTemplate").button().click(function () {
        alert("Edit template button");
    });

    $("#deleteTemplate").button().click(function () {
        alert("Delete template button");
    });

    $(".backupDatabase").button().click(function () {
        alert("Backup database");
    });

    $(".restoreDatabase").button().click(function () {
        alert("Restore database");
    });

});