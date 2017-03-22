using Moq;
using Xunit;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZillowTest.Models.Interface;
using ZillowTest.Core.Services;
using ZillowTest.Web.Controllers;
using ZillowTest.Web.ViewModels;
using ZillowTest.Constants;

namespace ZillowTest.Web.Tests
{
    /// <summary>
    /// Test of the <see cref="HomeController" /> class.
    /// </summary>
    public class HomeControllerTests
    {
        private readonly Mock<IAddress> _address;
        private readonly Mock<IProperty> _property;        
        private readonly Mock<IService> _services;
        private readonly HomeController _controller;

        /// <summary>Initializes a new instance of the <see cref="HomeControllerTests" />.</summary>
        public HomeControllerTests()
        {           
            _address = new Mock<IAddress>();
            _property = new Mock<IProperty>();
            _services = new Mock<IService>();
            _controller = new HomeController(_services.Object, _property.Object, _address.Object);
        }

        /// <summary>All arguments of homecontroller must be non-null.</summary>
        [Fact(DisplayName = "Constructor should throw exceptions if controller constructor parameters are null")]
        public void Construction_Of_HomeController_Requires_Non_Null_Arguments()
        {
            // AAA
            Assert.Throws<ArgumentNullException>(() => new HomeController(null, _property.Object, _address.Object));          
            Assert.Throws<ArgumentNullException>(() => new HomeController(null, null, _address.Object));
            Assert.Throws<ArgumentNullException>(() => new HomeController(null, null, null));
        }

        [Fact(DisplayName = "Index should return default property search view")]
        public void Index_should_return_default_propertyResult_view()
        {
            // Arrange
            var result = _controller.Index();

            // Assert & Act
            Assert.NotNull(result);
            var viewResult = (ViewResult)result;
            Assert.IsAssignableFrom<PropertyViewModel>(viewResult.Model);
            Assert.True(string.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == WebConstants.IndexView);
        }

        /// <summary>Requesting SearchResult action method with valid parameters should return correct property details with valid
        /// error code.</summary>
        [Fact]
        public async Task SearchResult_With_Valid_Parameter_Should_Return_CorrectViewResult()
        {
            // Arrange
            var address = new Mock<IAddress>();
            address.SetupProperty(x => x.Street, "2701 Ocean Park");
            address.SetupProperty(x => x.State, "CA");
            address.SetupProperty(x => x.City, "Santa Monica");
            address.SetupProperty(x => x.Zipcode, 90405);

            var property = new Mock<IProperty>();
            property.SetupProperty(x => x.IsRentZestimate, false);
            property.SetupProperty(x => x.Address, address.Object);
            property.SetupProperty(x => x.PropertyId, 254684);
            property.SetupProperty(x => x.ErrorDescription, "Request successfully processed");
            _services.Setup(x => x.GetPropertyDetails(It.IsAny<IAddress>())).ReturnsAsync(property.Object);

            // Assert
            var result = await _controller.SearchResult("2701 Ocean Park", "Santa Monica", "CA", "90405");

            // Act
            Assert.NotNull(result);
            var viewResult = (PartialViewResult)result;
            var viewModel = Assert.IsAssignableFrom<PropertyViewModel>(viewResult.ViewData.Model);
            Assert.True(string.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == WebConstants.SearchResultPartialView);
            Assert.NotNull(viewModel.PropertySearchResultBkt);
            Assert.Equal(property.Object.Address.Street, viewModel.PropertySearchResultBkt.Street);
            Assert.Equal(property.Object.Address.City, viewModel.PropertySearchResultBkt.City);
            Assert.Equal(property.Object.ErrorDescription, viewModel.PropertySearchResultBkt.ErrorDescription);
        }      
    }
}
