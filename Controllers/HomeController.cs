using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZillowTest.Constants;
using ZillowTest.Core;
using ZillowTest.Models;
using ZillowTest.Web.ViewModels;
using ZillowTest.Core.Services;
using ZillowTest.Models.Interface;

namespace ZillowTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IService _service;
        public  IProperty _property;
        public readonly IAddress _address;
        public readonly PropertyViewModel _viewModel;
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/>. 
        /// </summary>
        /// <param name="service">Service instance to get property details.</param>
        /// <param name="property">Property model instance to get property data.</param>
        /// <param name="address">Address model instance to get address data.</param>
        public HomeController(IService service, IProperty property, IAddress address)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (address == null) throw new ArgumentNullException(nameof(address));

            _service = service;
            _property = property;
            _address = address;
        }

        /// <summary>
        /// Default view.
        /// </summary>
        /// <returns>Index view.</returns>
        [HttpGet]
        public IActionResult Index()
        {                      
            return View(new PropertyViewModel());
        }

        /// <summary>
        /// Action method to get search result.
        /// </summary>
        /// <param name="street">Street filter.</param>
        /// <param name="city">City filter value.</param>
        /// <param name="state">State filter value.</param>
        /// <param name="zipcode">Zipcode value.</param>
        /// <returns>Asynchronous partial view.</returns>
        [HttpGet]
        public async Task<PartialViewResult> SearchResult(string street, string city, string state, string zipcode)
        {
            PropertyViewModel viewModel;
            if (string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(state))
            {
                viewModel = new PropertyViewModel
                {
                    PropertySearchResultBkt = new PropertyViewModel.PropertySearchResultBucket(),
                    HasError = true,
                    ValidationErrorMessage = "Invalid Street/City/State. Please enter valid address."
                };
            }
            else
            {
                // Assign filters to get property details.
                _address.Street = street;
                _address.Zipcode = Convert.ToInt32(zipcode);
                _address.City = city;
                _address.State = state;
                _property = await _service.GetPropertyDetails(_address);

                viewModel = new PropertyViewModel
                {
                    // Map Property data to view model fields.
                    PropertySearchResultBkt = new PropertyViewModel.PropertySearchResultBucket
                    {
                        Street = _property.Address.Street,
                        City = _property.Address.City,
                        State = _property.Address.State,
                        Zipcode = _property.Address.Zipcode,
                        Latitude = _property.Address.Latitude,
                        Longitude = _property.Address.Longitude,
                        ErrorDescription = _property.ErrorDescription
                    },
                    HasError = _property.ErrorCode > 0
                };
            } 
         
            return PartialView(WebConstants.SearchResultPartialView, viewModel);
        }

        /// <summary>
        /// View for the error page.
        /// </summary>
        /// <returns>Error action result.</returns>
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
    }
}
 