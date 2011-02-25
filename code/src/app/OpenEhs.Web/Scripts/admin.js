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
        $("#addProductDialog").dialog("open");
    });

    $("#editProduct").button().click(function () {
         $("#editProductDialog").dialog("open");
    });

    $("#deleteProduct").button().click(function () {
        $("#removeProductDialog").dialog("open");
    });

    $("#editTemplate").button().click(function () {
        alert("Edit template button");
    });

    $("#deleteTemplate").button().click(function () {
        alert("Delete template button");
    });

    $("#addService").button().click(function () {
        alert("Add service button");
    });

    $("#editService").button().click(function () {
        alert("Edit service button");
    });

    $("#deleteService").button().click(function () {
        alert("Delete service button");
    });

    $("#addLocation").button().click(function () {
        $("#addLocationDialog").dialog("open");
    });

    $("#deleteLocation").button().click(function () {
        alert("Delete location button");
    });

    $("#addCategory").button().click(function () {
        $("#addCategoryDialog").dialog("open");
    });

    $("#deleteCategory").button().click(function () {
        alert("Delete category button");
    });


    $(".backupDatabase").button().click(function () {
        alert("Backup database");
    });

    $(".restoreDatabase").button().click(function () {
        alert("Restore database");
    });

    $("#addProductDialog").dialog({
    autoOpen: false,
    height: 260,
    width: 420,
    modal: true,
    buttons: {
        "Add Product": function () {
            $.post("/Admin/AddProduct", {
                Name: $("#model_name").val(),
                Unit: $("#model_unit").val(),
                CategoryId: $("#model_categoryid").val(),
                Price: $("#model_price").val(),
                QuantityOnHand: $("#model_quantityonhand").val()
            }, function (result) {
                if (result.error == "false") {
                    $("#addProductDialog").dialog("close");


                    $("#model_name").val("");
                    $("#model_unit").val("");
                    $("#model_categoryid").val("");
                    $("#model_price").val("");
                    $("#model_quantityonhand").val("");

                alert("good result");

                }
            }, "json");
        },
        Cancel: function () {
            $(this).dialog("close");
        }
    },
    close: function () {

    }
});

$("#removeProductDialog").dialog({
    autoOpen: false,
    height: 150,
    width: 420,
    modal: true,
    buttons: {
        "Remove Product": function () {
            $.post("/Admin/RemoveProduct", {
                ProductId: $("#model_prodname").val()
            }, function (result) {
                if (result.error == "false") {
                    $("#removeProductDialog").dialog("close");


                    alert("good result");

                    ProductId: $("#model_prodname").val("");

                }
            }, "json");
        },
        Cancel: function () {
            $(this).dialog("close");
        }
    },
    close: function () {

    }
});

$("#editProductDialog").dialog({
    autoOpen: false,
    height: 250,
    width: 420,
    modal: true,
    buttons: {
        "Edit Product": function () {
            $.post("/Admin/EditProduct", {
                ProductId: $("#model_selectprod").val(),
                Name: $("#model_editprodname").val(),
                Unit: $("#model_editprodunit").val(),
                CategoryId: $("#model_editprodcategory").val(),
                Price: $("#model_editprodprice").val(),
            }, function (result) {
                if (result.error == "false") {
                    $("#editProductDialog").dialog("close");


                    alert("good result");

                    $("#model_editprodname").val("");
                    $("#model_editprodunit").val("");
                    $("#model_editprodcategory").val("");
                    $("#model_editprodprice").val("");
                }
            }, "json");
        },
        Cancel: function () {
            $(this).dialog("close");
        }
    },
    close: function () {

    }
});

$("#addLocationDialog").dialog({
    autoOpen: false,
    height: 200,
    width: 420,
    modal: true,
    buttons: {
        "Add Location": function () {
            $.post("/Admin/AddLocation", {
                Department: $("#model_departmentname").val(),
                RoomNumber: $("#model_addroomnumber").val()
            }, function (result) {
                if (result.error == "false") {
                    $("#addLocationDialog").dialog("close");

                    alert("good result");

                    $("#model_departmentname").val("");
                    $("#model_addroomnumber").val("");
                }
            }, "json");
        },
        Cancel: function () {
            $(this).dialog("close");
        }
    },
    close: function () {

    }
});

$("#addCategoryDialog").dialog({
    autoOpen: false,
    height: 200,
    width: 420,
    modal: true,
    buttons: {
        "Add Category": function () {
            $.post("/Admin/AddCategory", {
                Name: $("#model_model_categoryname").val(),
                Description: $("#model_categorydescription").val()
            }, function (result) {
                if (result.error == "false") {
                    $("#addCategoryDialog").dialog("close");

                    alert("good result");

                    $("#model_model_categoryname").val("");
                    $("#model_categorydescription").val("");
                }
            }, "json");
        },
        Cancel: function () {
            $(this).dialog("close");
        }
    },
    close: function () {

    }
});


});