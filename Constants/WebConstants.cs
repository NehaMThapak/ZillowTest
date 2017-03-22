using ZillowTest.Web.Controllers;

namespace ZillowTest.Constants
{
    /// <summary>
    /// Magic strings resides under web project files.
    /// </summary>
    public static class WebConstants
    {
        /// <summary>
        /// Route of the error view.
        /// </summary>
        public static string ErrorViewRoute = "/Home/Error";

        /// <summary>
        /// Partial view name of the search result.
        /// </summary>
        public static string SearchResultPartialView = "_SearchResult";

        /// <summary>
        /// Search result action name.
        /// </summary>
        public static string SearchResultAction = nameof(HomeController.SearchResult);

        /// <summary>
        /// View name of the index view.
        /// </summary>
        public static string IndexView = nameof(HomeController.Index);
    }
}
