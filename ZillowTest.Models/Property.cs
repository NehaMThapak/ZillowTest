using System;
using ZillowTest.Models.Interface;

namespace ZillowTest.Models
{
    /// <summary>
    /// Representation of the property model.
    /// </summary>
    public class Property : IProperty
    {
        /// <summary>
        /// Id of the property.
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Full address details of the property.
        /// </summary>
        public IAddress Address { get; set; }

        /// <summary>
        /// Boolean to get rent zestimate value.
        /// </summary>
        public bool IsRentZestimate { get; set; }

        /// <summary>
        /// Zestimate details of the property.
        /// </summary>
        public IZestimateData ZestimateData { get; set; }

        /// <summary>
        /// Rent zestimate data.
        /// </summary>
        public IZestimateData RentZestimateData { get; set; }

        /// <summary>
        /// Error description to display on the view in case of error or failure.          
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Error code returned from the service.
        /// </summary>
        public int ErrorCode { get; set; }
    }

    /// <summary>
    /// Representation of the Address model of the property.
    /// </summary>
    public class Address : IAddress
    {
        /// <summary>
        /// City of the property.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Latitude value of the property location.
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// Longitude value of the property location.
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// State of the property.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Street address of the property.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Zip code number of the property.
        /// </summary>
        public int Zipcode { get; set; }
    }

    /// <summary>
    /// Representation of the ZestimageData model of the property.
    /// </summary>
    public class ZestimageData : IZestimateData
    {
        /// <summary>
        /// Date when property details last updated.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }

        /// <summary>
        /// Percentile value of the property.
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
        /// High range value of the property.
        /// </summary>
        public decimal ValuationRangeHigh { get; set; }

        /// <summary>
        /// Low range value of the property.
        /// </summary>
        public decimal ValuationRangeLow { get; set; }
    }
}


