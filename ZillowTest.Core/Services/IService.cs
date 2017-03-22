using System.Threading.Tasks;
using ZillowTest.Models;
using ZillowTest.Models.Interface;

namespace ZillowTest.Core.Services
{
    /// <summary>
    /// Expose service methods to get property details.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Call Zillow api and get property detail by passing address input parameters.
        /// </summary>
        /// <param name="address">Address input to find property details.</param>
        /// <returns>Property details.</returns>
        Task<IProperty> GetPropertyDetails(IAddress address);
    }
}
