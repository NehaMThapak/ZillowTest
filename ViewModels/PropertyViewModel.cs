using System;
using System.ComponentModel.DataAnnotations;

namespace ZillowTest.Web.ViewModels
{
    /// <summary>
    /// View model for property search view.
    /// </summary>
    public class PropertyViewModel
    {
        /// <summary>
        /// City name filter to get property details.
        /// </summary>
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid city.")]
        public string City { get; set; }

        /// <summary>
        /// Street address filter of the property.
        /// </summary>
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// State of the property.
        /// </summary>
        [Required]
        public string State { get; set; }

        /// <summary>
        /// Zip code number of the property.
        /// </summary>
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are allowed for zip code.")]
        public string Zipcode { get; set; }

        public PropertySearchResultBucket PropertySearchResultBkt { get; set; }

        /// <summary>
        /// Validation error.
        /// </summary>       
        public string ValidationErrorMessage { get; set; }

        /// <summary>
        /// Boolean to display error on the view if any.
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Representation of the property search result set.
        /// </summary>
        public class PropertySearchResultBucket
        {
            /// <summary>
            /// City of the property.
            /// </summary>     
            public string City { get; set; }            

            /// <summary>
            /// Error description to display on the view in case of error or failure.          
            /// </summary>
            public string ErrorDescription { get; set; }

            /// <summary>
            /// Date when property details last updated.
            /// </summary>
            public DateTime LastUpdatedDate { get; set; }

            /// <summary>
            /// Boolean value for rent zestimate.
            /// </summary>
            public bool IsRentZestimate { get; set; }

            /// <summary>
            /// Latitude value of the property location.
            /// </summary>
            public string Latitude { get; set; }

            /// <summary>
            /// Longitude value of the property location.
            /// </summary>
            public string Longitude { get; set; }

            /// <summary>
            /// Percentile value.
            /// </summary>
            public decimal PercentileValue { get; set; }

            /// <summary>
            /// Price of the property.
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// Price change in 30 - day range in {$}.
            /// </summary>    
            public decimal PriceChange { get; set; }

            /// <summary>
            /// State of the property.
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// Street address of the property.
            /// </summary>
            public string Street { get; set; }

            /// <summary>
            /// High range value of the property.
            /// </summary>
            public decimal ValuationRangeHigh { get; set; }

            /// <summary>
            /// Low range value of the property.
            /// </summary>
            public decimal ValuationRangeLow { get; set; }

            /// <summary>
            /// Zip code number of the property.
            /// </summary>
            public int Zipcode { get; set; }
        }
    }
}
