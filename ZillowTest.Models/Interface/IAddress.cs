namespace ZillowTest.Models.Interface
{
    /// <summary>
    /// Expose different properties for a Address entity.
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// City name of the property.
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Latitude value of the property location.
        /// </summary>
        string Latitude { get; set; }

        /// <summary>
        /// Longitude value of the property location.
        /// </summary>
        string Longitude { get; set; }

        /// <summary>
        /// State of the property.
        /// </summary>
        string State { get; set; }

        /// <summary>
        /// Street address of the property.
        /// </summary>
        string Street { get; set; }

        /// <summary>
        /// Zip code number of the property.
        /// </summary>
        int Zipcode { get; set; }
    }
}