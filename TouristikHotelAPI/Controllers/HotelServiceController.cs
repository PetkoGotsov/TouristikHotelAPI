using Microsoft.AspNetCore.Mvc;
using TouristikHotelAPI.Models;
using TouristikHotelAPI.Services;

namespace TouristikHotelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelServiceController : ControllerBase
    {
        private readonly ILogger<HotelServiceController> _logger;

        private readonly IHotelRoomService _hotelRoomService;

        public HotelServiceController(ILogger<HotelServiceController> logger, IHotelRoomService hotelRoomService)
        {
            _logger = logger;
            _hotelRoomService = hotelRoomService;
        }

        [HttpGet("GetGuestRoomsWithPriceForHotelCode")]
        public IActionResult GetGuestRoomsWithPriceForHotelCode(string hotelCode)
        {
            var match = _hotelRoomService.GetGuestRoomsWithPriceForHotelCode(hotelCode);
            return match != null ?
                Ok(match)
                : NotFound(match);
        }

        [HttpGet("GetCheapestHotelForRoomType")]
        public IActionResult GetCheapestHotelForRoomType(string room)
        {
            var match = _hotelRoomService.GetCheapestHotelForRoomType(room);
            return match != null ?
                Ok(match)
                : NotFound(match);
        }

        [HttpGet("GetAllHotelsInCityDescendingByLocalCategory")]
        public IActionResult GetAllHotelsInCityDescendingByLocalCategory(string city)
        {
            var match = _hotelRoomService.GetAllHotelsInCityDescendingByLocalCategory(city);
            return match != null ?
                Ok(match)
                : NotFound(match);
        }
    }
}
