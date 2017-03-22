using System;

namespace ZillowTest.Core.Utilities
{
    /// <summary>
    /// An exception representing a missing/invalid city, state or zip code error.
    /// </summary>
    public class MissingCityStateZipException : Exception
    {
        /// <summary>
        /// Instantiates a new MissingCityStateZipException.
        /// </summary>           
        public MissingCityStateZipException() : base("Missing or invalid input address (City, State or ZipCode).")
        {
        }
    }
}
