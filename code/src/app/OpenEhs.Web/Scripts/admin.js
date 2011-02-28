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
        $("#addServiceDialog").dialog("open");
    });

    $("#editService").button().click(function () {
        $("#editServiceDialog").dialog("open");
    });

    $("#deleteService").button().click(function () {
        $("#deleteServiceDialog").dialog("open");
    });

    $("#addLocation").button().click(function () {
        $("#addLocationDialog").dialog("open");
    });

    $("#deleteLocation").button().click(function () {
        $("#deleteLocationDialog").dialog("open");
    });

    $("#addCategory").button().click(function () {
        $("#addCategoryDialog").dialog("open");
    });

    $("#deleteCategory").button().click(function () {
        $("#deleteCategoryDialog").dialog("open");
    });

    $("#AddInventory").button().click(function () {
        $("#AddInventoryDialog").dialog("open");
    });

    $("#EditInventory").button().click(function () {
        $("#EditInventoryDialog").dialog("open");
    });


    $(".backupDatabase").button().click(function () {
        alert("Backup database");
    });

    $(".restoreDatabase").button().click(function () {
        alert("Restore database");
    });

    //Live listener for the select change
    $("#model_selectededitinventoryprod").live('change', function () {
        $.post("/Admin/ProductList", {
                ID: $("#model_selectededitinventoryprod").val()
            }, function (result) {
                    var productQuan = result[0];

                    $("#model_inventoryeditquantity").val(productQuan.Quantity);

            }, "json");
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
                    $("#addProductDialog").dialog("close");


                    $("#model_name").val("");
                    $("#model_unit").val("");
                    $("#model_categoryid").val("");
                    $("#model_price").val("");
                    $("#model_quantityonhand").val("");

            }, "json");
        },
        Cancel: function () {
                    $("#model_name").val("");
                    $("#model_unit").val("");
                    $("#model_categoryid").val("");
                    $("#model_price").val("");
                    $("#model_quantityonhand").val("");
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
                
                    $("#removeProductDialog").dialog("close");

                    ProductId: $("#model_prodname").val("");

                
            }, "json");
        },
        Cancel: function () {
            $("#model_prodname").val("");
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
                ProductId: $("#model_productSelect").val(),
                Name: $("#model_editprodname").val(),
                Unit: $("#model_editprodunit").val(),
                CategoryId: $("#model_cataProdSelect").val(),
                Price: $("#model_editprodprice").val(),
            }, function (result) {
                    $("#editProductDialog").dialog("close");

                    $("#model_editprodname").val("");
                    $("#model_editprodunit").val("");
                    $("#model_editprodcategory").val("");
                    $("#model_editprodprice").val("");
            }, "json");
        },
        Cancel: function () {
                    $("#model_editprodname").val("");
                    $("#model_editprodunit").val("");
                    $("#model_editprodcategory").val("");
                    $("#model_editprodprice").val("");
                    $("#model_productSelect").val("");
                    $("#model_cataProdSelect").val("");
            $(this).dialog("close");
        }
    },
    close: function () {

    }
});

//Live listener for the select change for prod
    $("#model_productSelect").live('change', function () {
        $.post("/Admin/ProductList", {
                ID: $("#model_productSelect").val()
            }, function (result) {
                    var product = result[0];

                    $("#model_editprodname").val(product.Name);
                    $("#model_editprodunit").val(product.Unit);
                    $("#model_cataProdSelect").val(product.Category);
                    $("#model_editprodprice").val(product.Price);

            }, "json");
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
                    $("#addLocationDialog").dialog("close");

                    $("#model_departmentname").val("");
                    $("#model_addroomnumber").val("");
            }, "json");
        },
        Cancel: function () {
                    $("#model_departmentname").val("");
                    $("#model_addroomnumber").val("");
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
                Name: $("#model_categoryname").val(),
                Description: $("#model_categorydescription").val()
            }, function (result) {

                    $("#addCategoryDialog").dialog("close");

                    $("#model_categoryname").val("");
                    $("#model_model_categoryname").val("");
                    $("#model_categorydescription").val("");
            }, "json");
        },
        Cancel: function () {
                    $("#model_model_categoryname").val("");
                    $("#model_categoryname").val("");
                    $("#model_categorydescription").val("");
            $(this).dialog("close");
        }
    },
    close: function () {

    }
});

$("#deleteLocationDialog").dialog({
    autoOpen: false,
    height: 150,
    width: 420,
    modal: true,
    buttons: {
        "Delete Location": function () {
            $.post("/Admin/DeleteLocation", {
                Department: $("#model_departmentRoom").val()
            }, function (result) {
                    $("#deleteLocationDialog").dialog("close");

                    $("#model_departmentRoom").val("");
            }, "json");
        },
        Cancel: function () {
            $("#model_departmentRoom").val("");
            $(this).dialog("close");
        }
    },
    close: function () {
        
    }
});

$("#addServiceDialog").dialog({
    autoOpen: false,
    height: 160,
    width: 420,
    modal: true,
    buttons: {
        "Add Service": function () {
            $.post("/Admin/AddService", {
                Name: $("#model_servicename").val(),
                Cost: $("#model_servicecost").val()
            }, function (result) {
                    $("#addServiceDialog").dialog("close");

                    $("#model_servicename").val("");
                    $("#model_servicecost").val("");
            }, "json");
        },
        Cancel: function () {
                $("#model_servicename").val("");
                $("#model_servicecost").val("");
            $(this).dialog("close");
        }
    },
    close: function () {
        
    }
});

$("#editServiceDialog").dialog({
    autoOpen: false,
    height: 170,
    width: 420,
    modal: true,
    buttons: {
        "Edit Service": function () {
            $.post("/Admin/EditService", {
                Service: $("#model_editService").val(),
                Cost: $("#model_editservicecost").val()
            }, function (result) {
                    $("#editServiceDialog").dialog("close");

                    $("#model_editService").val("");
                    $("#model_editservicecost").val("");
            }, "json");
        },
        Cancel: function () {
                    $("#model_editService").val("");
                    $("#model_editservicecost").val("");
            $(this).dialog("close");
        }
    },
    close: function () {
        
    }
});

//Live listener for the select change for service
$("#model_editService").live('change', function () {
        $.post("/Admin/ServiceList", {
                ID: $("#model_editService").val()
            }, function (result) {
                    var serviceQuan = result[0];

                    $("#model_editservicecost").val(serviceQuan.Price);

            }, "json");
    });


$("#deleteServiceDialog").dialog({
    autoOpen: false,
    height: 150,
    width: 420,
    modal: true,
    buttons: {
        "Delete Service": function () {
            $.post("/Admin/DeleteService", {
                Service: $("#model_deleteService").val()
            }, function (result) {
                    $("#deleteServiceDialog").dialog("close");

                    $("#model_deleteService").val("");
            }, "json");
        },
        Cancel: function () {
            $("#model_deleteService").val("");
            $(this).dialog("close");
        }
    },
    close: function () {
        
    }
});

$("#deleteCategoryDialog").dialog({
    autoOpen: false,
    height: 150,
    width: 420,
    modal: true,
    buttons: {
        "Delete Category": function () {
            $.post("/Admin/DeleteCategory", {
                Category: $("#model_deleteCategory").val()
            }, function (result) {
                    $("#deleteCategoryDialog").dialog("close");

                    $("#model_deleteCategory").val("");
            }, "json");
        },
        Cancel: function () {
            $("#model_deleteCategory").val("");
            $(this).dialog("close");
        }
    },
    close: function () {
        
    }
});


$("#AddInventoryDialog").dialog({
    autoOpen: false,
    height: 200,
    width: 420,
    modal: true,
    buttons: {
        "Add Inventory": function () {
            $.post("/Admin/AddInventory", {
                Product: $("#model_selectedinventoryprod").val(),
                Quantity: $("#model_inventoryquantity").val()
            }, function (result) {
                    $("#AddInventoryDialog").dialog("close");

                    $("#model_selectedinventoryprod").val("");
                    $("#model_inventoryquantity").val("");
            }, "json");
        },
        Cancel: function () {
            $("#model_selectedinventoryprod").val("");
            $("#model_inventoryquantity").val("");
            $(this).dialog("close");
        }
    },
    close: function () {
        
    }
});

$("#EditInventoryDialog").dialog({
    autoOpen: false,
    height: 200,
    width: 420,
    modal: true,
    buttons: {
        "Edit Inventory": function () {
            $.post("/Admin/EditInventory", {
                Product: $("#model_selectededitinventoryprod").val(),
                Quantity: $("#model_inventoryeditquantity").val()
            }, function (result) {
                    $("#AddInventoryDialog").dialog("close");

                    $("#model_selectededitinventoryprod").val("");
                    $("#model_inventoryeditquantity").val("");
            }, "json");
        },
        Cancel: function () {
            $("#model_selectededitinventoryprod").val("");
            $("#model_inventoryeditquantity").val("");
            $(this).dialog("close");
        }
    },
    close: function () {
        
    }
});

});