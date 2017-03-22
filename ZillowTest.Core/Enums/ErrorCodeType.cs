using System.ComponentModel;

namespace ZillowTest.Core.Enums
{
    /// <summary>
    /// Different types of error code with description resulted from Zillow service.
    /// </summary>
    public enum ErrorCodeType
    {
        /// <summary>
        /// Successful processing code. 
        /// </summary>
        [Description("Request successfully processed.")]
        Success = 0,

        /// <summary>
        /// Service error type when there was a server-side error while processing the request.
        /// </summary>
        [Description("Please Check to see if your url is properly formed: delimiters, character cases, etc.")]
        ServiceError = 1,

        /// <summary>
        /// The specified ZWSID parameter was invalid or not specified in the request.
        /// </summary>
        [Description("Please Check if you have provided a ZWSID in your API call. If yes, check if the ZWSID is keyed in correctly. If it still doesn't work, contact Zillow to get help on fixing your ZWSID.")]
        InvalidZwsidParamError = 2,

        /// <summary>
        /// Error code when web services are unavailable.
        /// </summary>
        [Description("The Zillow Web Service is currently not available.Please come back later and try again.")]
        ServiceUnavailableError = 3,

        /// <summary>
        /// Error code when api call is unavailable.
        /// </summary>
        [Description("The Zillow Web Service is currently not available. Please come back later and try again.")]
        ApiCallUnavailableError = 4,

        /// <summary>
        /// Invalid or missing address parameter.
        /// </summary>
        [Description("Check if the input address matches the format specified in the input parameters table. When inputting a city name, include the state too. A city name alone will not result in a valid address.")]
        MissingAddressError = 500,

        /// <summary>
        /// Invalid or missing citystatezip parameter.
        /// </summary>
        [Description("Please Check if the input address matches the format specified in the input parameters table. When inputting a city name, include the state too. A city name alone will not result in a valid address.")]
        MissingCityStateZipError = 501,

        /// <summary>
        /// No results found.
        /// </summary>
        [Description("Sorry, the address you provided is not found in Zillow's property database.")]
        NoResultFound = 502,

        /// <summary>
        /// Failed to resolve city, state or ZIP code.
        /// </summary>
        [Description("Please check to see if the city/state you entered is valid. If you provided a ZIP code, check to see if it is valid.")]
        FailedToResolveError = 503,

        /// <summary>
        /// No coverage for specified area.
        /// </summary>
        [Description("The specified area is not covered by the Zillow property database.")]
        NoCoverageError = 504,

        /// <summary>
        /// Timeout.
        /// </summary>
        [Description("Your request timed out. The server could be busy or unavailable. Try again later.")]
        TimeoutError = 505,

        /// <summary>
        /// Address string too long.
        /// </summary>
        [Description("If address is valid, try using abbreviations.")]
        LongAddressStringError = 506,

        /// <summary>
        /// No exact match found.
        /// </summary>
        [Description("Verify that the given address is correct.")]
        NoExactMatchFound = 507,

        /// <summary>
        /// No exact match found.
        /// </summary>
        [Description("Verify that the given address is correct.")]
        NoAddressFound = 508
    }
}
