namespace ZillowTest.Models.Interface
{
    /// <summary>
    /// Expose different fields of the property.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Full address details of the property.
        /// </summary>
        IAddress Address { get; set; }

        /// <summary>
        /// Boolean to get rent zestimate value.
        /// </summary>
        bool IsRentZestimate { get; set; }

        /// <summary>
        /// Id of the property.
        /// </summary>
        int PropertyId { get; set; }

        /// <summary>
        /// Rent zestimate data.
        /// </summary>
        IZestimateData RentZestimateData { get; set; }

        /// <summary>
        /// Zestimate details of the property.
        /// </summary>
        IZestimateData ZestimateData { get; set; }

        /// <summary>
        /// Error code returned from the service.
        /// </summary>
        int ErrorCode { get; set; }

        /// <summary>
        /// Error description to display on the view in case of error or failure.          
        /// </summary>
        string ErrorDescription { get; set; }
    }
}