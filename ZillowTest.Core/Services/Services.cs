using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using ZillowTest.Core.Enums;
using ZillowTest.Core.Utilities;
using ZillowTest.Models;
using ZillowTest.Models.Interface;

namespace ZillowTest.Core.Services
{
    /// <summary>
    /// Implements service methods to get property details.
    /// </summary>
    public class Services : IService
    {
        private readonly ZillowConfiguration _zillowConfiguration;
        private readonly IProperty _property;

        /// <summary>
        /// Implements <see cref="IService"/> and initialize a new instance of the <see cref="Services"/>. 
        /// </summary>
        /// <param name="zillowConfiguration">App settings to get api key value.</param>
        /// <param name="property">Property model instance to get property data.</param>
        public Services(IOptions<ZillowConfiguration> zillowConfiguration, IProperty property)
        {
            if (zillowConfiguration == null) throw new ArgumentNullException(nameof(zillowConfiguration));
            if (property == null) throw new ArgumentNullException(nameof(property));

            _zillowConfiguration = zillowConfiguration.Value;
            _property = property;
        }

        /// <summary>
        /// Call Zillow api and get property detail by passing address input parameters.
        /// </summary>
        /// <param name="address">Address input to find property details.</param>
        /// <returns>Property details.</returns>
        public async Task<IProperty> GetPropertyDetails(IAddress address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrEmpty(address.Street)) throw new ArgumentNullException(nameof(address.Street));

            // It is required to input state and city/zip code to get property details.
            if (string.IsNullOrEmpty(address.State) && (string.IsNullOrEmpty(address.City) || address.Zipcode == 0))
                throw new MissingCityStateZipException();

            var cityStateZipcode = string.Empty;
            if (!string.IsNullOrWhiteSpace(address.City))
            {
                cityStateZipcode = $"{address.City},";
            }
            if (!string.IsNullOrWhiteSpace(address.State))
            {
                cityStateZipcode = $"{cityStateZipcode}{address.State},";
            }
            if (address.Zipcode > 0)
            {
                cityStateZipcode = $"{cityStateZipcode}{address.Zipcode}";
            }
            string serviceUrl = $"{_zillowConfiguration.ZillowGetSearchResults}&address={WebUtility.UrlEncode(address.Street)}&citystatezip={WebUtility.UrlEncode(cityStateZipcode)}";
            var request = (HttpWebRequest)WebRequest.Create(serviceUrl);

            try
            {
                var response = await request.GetResponseAsync();
                using (var responseStream = response.GetResponseStream())
                {
                    var feed = XDocument.Load(responseStream);

                    // Get code.
                    var code = feed.Descendants("message").FirstOrDefault().Elements("code").ElementAt(0).Value;

                    // If no error found.
                    if (code.Equals("0"))
                    {
                        // Get address.
                        var d = feed.Descendants("address")?.Skip(1)?.Take(1)
                                         .Select(x => new Address
                                         {
                                             Street = x.Element("street").Value,
                                             State = x.Element("state").Value,
                                             City = x.Element("city").Value,
                                             Zipcode = Convert.ToInt32(x.Element("zipcode").Value.ToString()),
                                             Latitude = x.Element("latitude").Value,
                                             Longitude = x.Element("longitude").Value
                                         });                        
                        _property.Address = d.FirstOrDefault();                                               
                    }
                    // If any other response than success, return error description.
                    else
                    {
                        var errorCode = (ErrorCodeType)Enum.Parse(typeof(ErrorCodeType), code);                       
                        _property.ErrorDescription = errorCode.GetDescription();
                    }
                    _property.ErrorCode = Convert.ToInt32(code);
                }
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response;
                using (var responseStream = errorResponse.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    var errorText = reader.ReadToEnd();                
                }
                throw;
            }
            return _property;
        }
    }
}
