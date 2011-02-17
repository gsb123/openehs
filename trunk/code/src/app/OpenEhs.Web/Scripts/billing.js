/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery.validate.js" />

$(document).ready(function () {


    // ------------------------------------------------- //
    //  Billing search                                   //
    // ------------------------------------------------- //

    $(document).ready(function () {
        $("#CreateNewBillingButton").button();

    });

    $(document).ready(function () {
        $("#SearchBillingButton").button();

    });

    $(function () {
        var availableTags = [
			"Cameron",
			"Peter",
			"Asp",
			"BASIC",
			"C",
			"C++",
			"Clojure",
			"COBOL",
			"ColdFusion",
			"Erlang",
			"Fortran",
			"Groovy",
			"Haskell",
			"Java",
			"JavaScript",
			"Lisp",
			"Perl",
			"PHP",
			"Python",
			"Ruby",
			"Scala",
			"Scheme"
		];
        $("#tags").autocomplete({
            source: availableTags
        });
    });

});