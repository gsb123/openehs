$(document).ready(function () {
    $("#SearchTerm").val("Search").addClass("blurSearchTextbox");

    $("#SearchTerm").focus(function () {
        $("#SearchTerm").removeClass("blurSearchTextbox");
        $("#SearchTerm").addClass("focusSearchTextbox");
        $("#SearchTerm").val("");
    });

    $("#SearchTerm").blur(function () {
        $("#SearchTerm").removeClass("focusSearchTextbox");
        $("#SearchTerm").addClass("blurSearchTextbox");
        $("#SearchTerm").val("Search");
    });

    $("#SelectedRole").change(function (data) {
        alert($("#SelectedRole option:selected").val() + " selected!");
    });

    $("#UserList tbody tr:odd").addClass("striped");

    $("#UserList tbody tr").click(function () {
        var href = $(this).find("a").attr("href");

        if (href) {
            window.location = href;
        }
    });
});