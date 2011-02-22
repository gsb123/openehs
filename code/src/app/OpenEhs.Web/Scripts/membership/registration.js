$(function () {
    $("").formwizard({
        formPluginEnabled: true,
        validationEnabled: false,
        focusFirstInput: true,
        formOptions: {
            success: alert("success"),
            beforeSubmit: alert("beforeSubmit"),
            dataType: "json",
            resetForm: true
        }
    }
});