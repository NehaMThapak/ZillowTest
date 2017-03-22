/// <reference path="typings/jquery.d.ts" />
/// <reference path="typings/jquery.validation.d.ts" />
/// <reference path="typings/jquery-validation-unobtrusive.d.ts" />

class ZillowTest {

    /**
    * The search button element.
    */
    $searchButtonElement: JQuery; 

    /**
    * The error summary div element.
    */
    $errorSummaryElement: JQuery; 

    /**
     * Builds an instance of ZillowTest search page with given endpoints.
     * @param searchResultPartialViewUrl: The URL for action that search properties and get results.     
     */
    constructor(private searchResultPartialViewUrl: string) {
        this.$searchButtonElement = $("#ButtonSearch");
        this.$errorSummaryElement = $(".errorSummary");
        this.bindButtonClicks();
    }

    /**
    * Bind click events.
    */
    private bindButtonClicks(): void {
        var self = this;
        this.$searchButtonElement.click(function (e) {
            e.preventDefault();
            const $form = $("form");
            if ($form.valid()) {
                self.$errorSummaryElement.addClass("hidden");
                const href = self.searchResultPartialViewUrl + "?Street=" + encodeURIComponent($("#Street").val()) + "&City=" + encodeURIComponent($("#City").val()) + "&State=" + $("select#States option:checked").val() + "&Zipcode=" + encodeURIComponent($("#Zipcode").val());
                $("a").attr("href", href);
                $(`#${$(this).data("target")}`).load($(this).attr("href"));
            } else {
                self.$errorSummaryElement.removeClass("hidden");
            }         
        });
    }
}