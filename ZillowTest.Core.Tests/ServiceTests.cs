using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using ZillowTest.Core.Services;
using ZillowTest.Models.Interface;
using ZillowTest.Core.Utilities;
using ZillowTest.Core.Enums;

namespace ZillowTest.Core.Tests
{
    /// <summary>
    /// Test of the <see cref="Services" /> class.
    /// </summary>
    public class ServiceTests
    {
        private readonly Mock<IOptions<ZillowConfiguration>> _zillowConfiguration;
        private readonly Mock<IProperty> _property;
        private readonly IService _services;

        /// <summary>Initializes a new instance of the <see cref="ServiceTests" />.</summary>
        public ServiceTests()
        {
            _zillowConfiguration = new Mock<IOptions<ZillowConfiguration>>();
            _property = new Mock<IProperty>();
            _services = new Services.Services(_zillowConfiguration.Object, _property.Object);
        }

        /// <summary>All arguments must be non-null.</summary>
        [Fact(DisplayName = "Construction should throw exceptions if any parameter is null.")]
        public void Construction_Of_Service_Requires_Non_Null_Arguments()
        {
            // AAA
            Assert.Throws<ArgumentNullException>(() => new Services.Services(null, null));
        }

        /// <summary>Calling GetPropertyDetails with null address value should throw exception as expected.</summary>
        [Fact]
        public void GetProperty_Details_Should_Throw_Exception_With_Null_Address_Value()
        {
            // AAA
            AssertEx.ThrowsAsync(() => _services.GetPropertyDetails(null));
        }

        /// <summary>Calling GetPropertyDetails with no street address should throw exception as expected.</summary>
        [Fact]
        public void GetProperty_Details_Without_Street_Should_Throw_Exception()
        {
            // Arrange
            var address = new Mock<IAddress>();
            address.SetupProperty(x => x.City, "Irvine");

            // Assert and Act
            var ex = AssertEx.ThrowsAsync(() => _services.GetPropertyDetails(address.Object));
        }

        /// <summary>Calling GetPropertyDetails with no state and city of the property should throw exception as expected.</summary>
        [Fact]
        public void GetProperty_Details_Without_State_And_City_Should_Throw_Exception()
        {
            // Arrange
            var address = new Mock<IAddress>();
            address.SetupProperty(x => x.Street, "101 Beacon Park");

            // Assert
            var exception = AssertEx.ThrowsAsync(() => _services.GetPropertyDetails(address.Object));

            // Act
            Assert.NotNull(exception);
            Assert.IsType<MissingCityStateZipException>(exception.Result);
        }

        /// <summary>Calling GetPropertyDetails with valid parameters should return correct property details with valid
        /// error code.</summary>
        [Fact]
        public async Task GetProperty_Details_With_Valid_Parameter_Should_Return_CorrectResult()
        {
            // Arrange
            var address = new Mock<IAddress>();
            address.SetupProperty(x => x.Street, "116 Newall");
            address.SetupProperty(x => x.State, "CA");
            address.SetupProperty(x => x.City, "Irvine");

            var property = new Mock<IProperty>();
            property.SetupProperty(x => x.IsRentZestimate, false);
            property.SetupProperty(x => x.Address, address.Object);
            property.SetupProperty(x => x.PropertyId, 254684);
            property.SetupProperty(x => x.ErrorDescription, "Request successfully processed.");

            // Arrange
            var appSetting = new ZillowConfiguration { ZillowGetSearchResults = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id=X1-ZWz1dyb53fdhjf_6jziz" };
            var zillowConfigurationMock = new Mock<IOptions<ZillowConfiguration>>();

            // We need to set the Value of IOptions to be the ZillowConfiguration Class.
            zillowConfigurationMock.Setup(x => x.Value).Returns(appSetting);
            var services = new Services.Services(zillowConfigurationMock.Object, property.Object);

            // Assert
            var result = await services.GetPropertyDetails(address.Object);

            // Act
            Assert.NotNull(result);
            Assert.NotNull(result.Address);
            Assert.Equal(address.Object.City, result.Address.City);
            Assert.Equal(address.Object.State, result.Address.State);
            Assert.Equal(address.Object.Street, result.Address.Street);
            Assert.Equal(ErrorCodeType.Success.GetDescription(), result.ErrorDescription);
        }

        /// <summary>Calling GetPropertyDetails with wrong addresss should return correct error code with description.</summary>
        [Fact]
        public async Task NotExists_Address_Should_Return_NoResultFound_ErrorCode()
        {
            // Arrange
            var appSetting = new ZillowConfiguration { ZillowGetSearchResults = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id=X1-ZWz1dyb53fdhjf_6jziz" };
            var zillowConfigurationMock = new Mock<IOptions<ZillowConfiguration>>();

            // We need to set the Value of IOptions to be the ZillowConfiguration Class.
            zillowConfigurationMock.Setup(x => x.Value).Returns(appSetting);

            var address = new Mock<IAddress>();
            address.SetupProperty(x => x.Street, "123 ABC");
            address.SetupProperty(x => x.State, "CA");
            address.SetupProperty(x => x.City, "Santa Monica");
            var property = new Mock<IProperty>();
            property.SetupProperty(x => x.ErrorDescription, ErrorCodeType.NoAddressFound.GetDescription());

            var services = new Services.Services(zillowConfigurationMock.Object, property.Object);

            // Assert
            var result = await services.GetPropertyDetails(address.Object);

            // Act
            Assert.NotNull(result);
            Assert.Equal(ErrorCodeType.NoAddressFound.GetDescription(), result.ErrorDescription);
        }
    }
}
