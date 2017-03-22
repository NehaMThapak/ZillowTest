/// <reference path="typings/jquery.d.ts" />
/// <reference path="typings/jquery.validation.d.ts" />
/// <reference path="typings/jquery-validation-unobtrusive.d.ts" />
var ZillowTest = (function () {
    /**
     * Builds an instance of ZillowTest search page with given endpoints.
     * @param searchResultPartialViewUrl: The URL for action that search properties and get results.
     */
    function ZillowTest(searchResultPartialViewUrl) {
        this.searchResultPartialViewUrl = searchResultPartialViewUrl;
        this.$searchButtonElement = $("#ButtonSearch");
        this.$errorSummaryElement = $(".errorSummary");
        this.bindButtonClicks();
    }
    /**
    * Bind click events.
    */
    ZillowTest.prototype.bindButtonClicks = function () {
        var self = this;
        this.$searchButtonElement.click(function (e) {
            e.preventDefault();
            var $form = $("form");
            if ($form.valid()) {
                self.$errorSummaryElement.addClass("hidden");
                var href = self.searchResultPartialViewUrl + "?Street=" + encodeURIComponent($("#Street").val()) + "&City=" + encodeURIComponent($("#City").val()) + "&State=" + $("select#States option:checked").val() + "&Zipcode=" + encodeURIComponent($("#Zipcode").val());
                $("a").attr("href", href);
                $("#" + $(this).data("target")).load($(this).attr("href"));
            }
            else {
                self.$errorSummaryElement.removeClass("hidden");
            }
        });
    };
    return ZillowTest;
}());

//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIlppbGxvd1Rlc3QudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUEsNENBQTRDO0FBQzVDLHVEQUF1RDtBQUN2RCxtRUFBbUU7QUFFbkU7SUFZSTs7O09BR0c7SUFDSCxvQkFBb0IsMEJBQWtDO1FBQWxDLCtCQUEwQixHQUExQiwwQkFBMEIsQ0FBUTtRQUNsRCxJQUFJLENBQUMsb0JBQW9CLEdBQUcsQ0FBQyxDQUFDLGVBQWUsQ0FBQyxDQUFDO1FBQy9DLElBQUksQ0FBQyxvQkFBb0IsR0FBRyxDQUFDLENBQUMsZUFBZSxDQUFDLENBQUM7UUFDL0MsSUFBSSxDQUFDLGdCQUFnQixFQUFFLENBQUM7SUFDNUIsQ0FBQztJQUVEOztNQUVFO0lBQ00scUNBQWdCLEdBQXhCO1FBQ0ksSUFBSSxJQUFJLEdBQUcsSUFBSSxDQUFDO1FBQ2hCLElBQUksQ0FBQyxvQkFBb0IsQ0FBQyxLQUFLLENBQUMsVUFBVSxDQUFDO1lBQ3ZDLENBQUMsQ0FBQyxjQUFjLEVBQUUsQ0FBQztZQUNuQixJQUFNLEtBQUssR0FBRyxDQUFDLENBQUMsTUFBTSxDQUFDLENBQUM7WUFDeEIsRUFBRSxDQUFDLENBQUMsS0FBSyxDQUFDLEtBQUssRUFBRSxDQUFDLENBQUMsQ0FBQztnQkFDaEIsSUFBSSxDQUFDLG9CQUFvQixDQUFDLFFBQVEsQ0FBQyxRQUFRLENBQUMsQ0FBQztnQkFDN0MsSUFBTSxJQUFJLEdBQUcsSUFBSSxDQUFDLDBCQUEwQixHQUFHLFVBQVUsR0FBRyxrQkFBa0IsQ0FBQyxDQUFDLENBQUMsU0FBUyxDQUFDLENBQUMsR0FBRyxFQUFFLENBQUMsR0FBRyxRQUFRLEdBQUcsa0JBQWtCLENBQUMsQ0FBQyxDQUFDLE9BQU8sQ0FBQyxDQUFDLEdBQUcsRUFBRSxDQUFDLEdBQUcsU0FBUyxHQUFHLENBQUMsQ0FBQyw4QkFBOEIsQ0FBQyxDQUFDLEdBQUcsRUFBRSxHQUFHLFdBQVcsR0FBRyxrQkFBa0IsQ0FBQyxDQUFDLENBQUMsVUFBVSxDQUFDLENBQUMsR0FBRyxFQUFFLENBQUMsQ0FBQztnQkFDblEsQ0FBQyxDQUFDLEdBQUcsQ0FBQyxDQUFDLElBQUksQ0FBQyxNQUFNLEVBQUUsSUFBSSxDQUFDLENBQUM7Z0JBQzFCLENBQUMsQ0FBQyxNQUFJLENBQUMsQ0FBQyxJQUFJLENBQUMsQ0FBQyxJQUFJLENBQUMsUUFBUSxDQUFHLENBQUMsQ0FBQyxJQUFJLENBQUMsQ0FBQyxDQUFDLElBQUksQ0FBQyxDQUFDLElBQUksQ0FBQyxNQUFNLENBQUMsQ0FBQyxDQUFDO1lBQy9ELENBQUM7WUFBQyxJQUFJLENBQUMsQ0FBQztnQkFDSixJQUFJLENBQUMsb0JBQW9CLENBQUMsV0FBVyxDQUFDLFFBQVEsQ0FBQyxDQUFDO1lBQ3BELENBQUM7UUFDTCxDQUFDLENBQUMsQ0FBQztJQUNQLENBQUM7SUFDTCxpQkFBQztBQUFELENBeENBLEFBd0NDLElBQUEiLCJmaWxlIjoiWmlsbG93VGVzdC5qcyIsInNvdXJjZXNDb250ZW50IjpbIi8vLyA8cmVmZXJlbmNlIHBhdGg9XCJ0eXBpbmdzL2pxdWVyeS5kLnRzXCIgLz5cclxuLy8vIDxyZWZlcmVuY2UgcGF0aD1cInR5cGluZ3MvanF1ZXJ5LnZhbGlkYXRpb24uZC50c1wiIC8+XHJcbi8vLyA8cmVmZXJlbmNlIHBhdGg9XCJ0eXBpbmdzL2pxdWVyeS12YWxpZGF0aW9uLXVub2J0cnVzaXZlLmQudHNcIiAvPlxyXG5cclxuY2xhc3MgWmlsbG93VGVzdCB7XHJcblxyXG4gICAgLyoqXHJcbiAgICAqIFRoZSBzZWFyY2ggYnV0dG9uIGVsZW1lbnQuXHJcbiAgICAqL1xyXG4gICAgJHNlYXJjaEJ1dHRvbkVsZW1lbnQ6IEpRdWVyeTsgXHJcblxyXG4gICAgLyoqXHJcbiAgICAqIFRoZSBlcnJvciBzdW1tYXJ5IGRpdiBlbGVtZW50LlxyXG4gICAgKi9cclxuICAgICRlcnJvclN1bW1hcnlFbGVtZW50OiBKUXVlcnk7IFxyXG5cclxuICAgIC8qKlxyXG4gICAgICogQnVpbGRzIGFuIGluc3RhbmNlIG9mIFppbGxvd1Rlc3Qgc2VhcmNoIHBhZ2Ugd2l0aCBnaXZlbiBlbmRwb2ludHMuXHJcbiAgICAgKiBAcGFyYW0gc2VhcmNoUmVzdWx0UGFydGlhbFZpZXdVcmw6IFRoZSBVUkwgZm9yIGFjdGlvbiB0aGF0IHNlYXJjaCBwcm9wZXJ0aWVzIGFuZCBnZXQgcmVzdWx0cy4gICAgIFxyXG4gICAgICovXHJcbiAgICBjb25zdHJ1Y3Rvcihwcml2YXRlIHNlYXJjaFJlc3VsdFBhcnRpYWxWaWV3VXJsOiBzdHJpbmcpIHtcclxuICAgICAgICB0aGlzLiRzZWFyY2hCdXR0b25FbGVtZW50ID0gJChcIiNCdXR0b25TZWFyY2hcIik7XHJcbiAgICAgICAgdGhpcy4kZXJyb3JTdW1tYXJ5RWxlbWVudCA9ICQoXCIuZXJyb3JTdW1tYXJ5XCIpO1xyXG4gICAgICAgIHRoaXMuYmluZEJ1dHRvbkNsaWNrcygpO1xyXG4gICAgfVxyXG5cclxuICAgIC8qKlxyXG4gICAgKiBCaW5kIGNsaWNrIGV2ZW50cy5cclxuICAgICovXHJcbiAgICBwcml2YXRlIGJpbmRCdXR0b25DbGlja3MoKTogdm9pZCB7XHJcbiAgICAgICAgdmFyIHNlbGYgPSB0aGlzO1xyXG4gICAgICAgIHRoaXMuJHNlYXJjaEJ1dHRvbkVsZW1lbnQuY2xpY2soZnVuY3Rpb24gKGUpIHtcclxuICAgICAgICAgICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xyXG4gICAgICAgICAgICBjb25zdCAkZm9ybSA9ICQoXCJmb3JtXCIpO1xyXG4gICAgICAgICAgICBpZiAoJGZvcm0udmFsaWQoKSkge1xyXG4gICAgICAgICAgICAgICAgc2VsZi4kZXJyb3JTdW1tYXJ5RWxlbWVudC5hZGRDbGFzcyhcImhpZGRlblwiKTtcclxuICAgICAgICAgICAgICAgIGNvbnN0IGhyZWYgPSBzZWxmLnNlYXJjaFJlc3VsdFBhcnRpYWxWaWV3VXJsICsgXCI/U3RyZWV0PVwiICsgZW5jb2RlVVJJQ29tcG9uZW50KCQoXCIjU3RyZWV0XCIpLnZhbCgpKSArIFwiJkNpdHk9XCIgKyBlbmNvZGVVUklDb21wb25lbnQoJChcIiNDaXR5XCIpLnZhbCgpKSArIFwiJlN0YXRlPVwiICsgJChcInNlbGVjdCNTdGF0ZXMgb3B0aW9uOmNoZWNrZWRcIikudmFsKCkgKyBcIiZaaXBjb2RlPVwiICsgZW5jb2RlVVJJQ29tcG9uZW50KCQoXCIjWmlwY29kZVwiKS52YWwoKSk7XHJcbiAgICAgICAgICAgICAgICAkKFwiYVwiKS5hdHRyKFwiaHJlZlwiLCBocmVmKTtcclxuICAgICAgICAgICAgICAgICQoYCMkeyQodGhpcykuZGF0YShcInRhcmdldFwiKX1gKS5sb2FkKCQodGhpcykuYXR0cihcImhyZWZcIikpO1xyXG4gICAgICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgc2VsZi4kZXJyb3JTdW1tYXJ5RWxlbWVudC5yZW1vdmVDbGFzcyhcImhpZGRlblwiKTtcclxuICAgICAgICAgICAgfSAgICAgICAgIFxyXG4gICAgICAgIH0pO1xyXG4gICAgfVxyXG59Il0sInNvdXJjZVJvb3QiOiIvc291cmNlLyJ9
