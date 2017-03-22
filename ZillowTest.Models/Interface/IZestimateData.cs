using System;

namespace ZillowTest.Models.Interface
{
    /// <summary>
    /// Expose different fields for the zestimate data of the property.
    /// </summary>
    public interface IZestimateData
    {
        /// <summary>
        /// Date when property details last updated.
        /// </summary>
        DateTime LastUpdatedDate { get; set; }

        /// <summary>
        /// Percentile value of the property.
        /// </summary>
        decimal PercentileValue { get; set; }

        /// <summary>
        /// Price of the property.
        /// </summary>   
        decimal Price { get; set; }

        /// <summary>
        /// Price change in 30 - day range in {$}.
        /// </summary>  
        decimal PriceChange { get; set; }

        /// <summary>
        /// High range value of the property.
        /// </summary>
        decimal ValuationRangeHigh { get; set; }

        /// <summary>
        /// Low range value of the property.
        /// </summary>
        decimal ValuationRangeLow { get; set; }
    }
}