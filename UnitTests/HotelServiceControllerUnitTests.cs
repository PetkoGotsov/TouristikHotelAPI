using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TouristikHotelAPI.Controllers;
using TouristikHotelAPI.Services;

namespace UnitTests
{
    public class HotelServiceControllerUnitTests
    {
        private HotelServiceController _controller;

        [SetUp]
        public void Setup()
        {
            //Arrange
            var mockServiceLogger = new Mock<ILogger<HotelRoomService>>();
            var inMemorySettings = new Dictionary<string, string> {
                {"Hotels:JsonPath", "Static/hoteldata.json"}
            };
            IConfiguration mockConfiguration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            var service = new HotelRoomService(mockServiceLogger.Object, mockConfiguration);
            var mockControllerLogger = new Mock<ILogger<HotelServiceController>>();
            _controller = new HotelServiceController(mockControllerLogger.Object, service);
        }

        [Test]
        public void TestGetGuestRoomsWithPriceForHotelCodeShouldReturnOK()
        {
            // Arrange
            var hotelCode = "SPRIN";

            //Act
            var result = _controller.GetGuestRoomsWithPriceForHotelCode(hotelCode);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsNotNull(((OkObjectResult)result).Value);
        }

        [Test]
        public void TestGetGuestRoomsWithPriceForHotelCodeShouldReturnNotFoundResult()
        {
            //Arrange
            //Act
            var result = _controller.GetGuestRoomsWithPriceForHotelCode(null);

            //Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public void TestGetCheapestHotelForRoomTypeShouldReturnOK()
        {
            // Arrange
            var room = "Double Room Standard";

            //Act
            var result = _controller.GetCheapestHotelForRoomType(room);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsNotNull(((OkObjectResult)result).Value);
            Assert.AreEqual(((OkObjectResult)result).Value, "Shelbyville Motors");
        }

        [Test]
        public void TestGetCheapestHotelForRoomTypeShouldReturnNotFoundResult()
        {
            //Act
            var result = _controller.GetCheapestHotelForRoomType(null);

            //Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public void TestGetAllHotelsInCityDescendingByLocalCategoryShouldReturnOK()
        {
            // Arrange
            var city = "Springfield";

            //Act
            var result = _controller.GetAllHotelsInCityDescendingByLocalCategory(city);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsNotNull(((OkObjectResult)result).Value);
        }

        [Test]
        public void TestGetAllHotelsInCityDescendingByLocalCategoryShouldReturnNotFoundResult()
        {
            //Act
            var result = _controller.GetAllHotelsInCityDescendingByLocalCategory(null);

            //Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }
    }
}