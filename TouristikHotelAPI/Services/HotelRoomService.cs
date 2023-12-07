using Newtonsoft.Json;
using System.Net.Http.Json;
using TouristikHotelAPI.Models;

namespace TouristikHotelAPI.Services
{
    public class HotelRoomService : IHotelRoomService
    {
        private static HotelProvider _hotelProvider = new HotelProvider();

        private readonly ILogger _logger;

        public HotelRoomService(ILogger<HotelRoomService> logger, IConfiguration configuration) 
        {
            var hotelsJsonPath = configuration.GetSection("Hotels")["JsonPath"];
            _logger = logger;
            _hotelProvider = JsonConvert.DeserializeObject<HotelProvider>(File.ReadAllText(hotelsJsonPath));
            _logger.LogInformation($"Successfully loaded {_hotelProvider.Hotels.Count} from {hotelsJsonPath}");
        }

        public List<GuestRoom> GetGuestRoomsWithPriceForHotelCode(string hotelCode)
        {
            var match = _hotelProvider.Hotels.Count() != 0 ? _hotelProvider.Hotels.FirstOrDefault(h => h.Code == hotelCode)
                : null;
            _logger.LogInformation($"GetGuestRoomsWithPriceForHotelCode {hotelCode} returns {(match != null ? 1 : 0)} elements");

            return match != null ? match.GuestRooms 
                : null;
        }

        public string GetCheapestHotelForRoomType(string room)
        {
            var match = _hotelProvider.Hotels.Count() != 0 ?_hotelProvider.Hotels.Where(h => h.GuestRooms.Any(gr => gr.Room == room))
                : null;
            _logger.LogInformation($"GetCheapestHotelForRoomType {room} returns {(match != null ? match.Count() : 0)} elements");

            return match != null && match.Count() != 0 ? match
                .Select(h => new { hotelName = h.HotelName, guestRoom = h.GuestRooms.FirstOrDefault(gr => gr.Room == room) })
                .OrderBy(o => o.guestRoom.PricePerNight).FirstOrDefault().hotelName
                : null;
        }

        public List<Hotel> GetAllHotelsInCityDescendingByLocalCategory(string city)
        {
            var match = _hotelProvider.Hotels.Count() != 0 ? _hotelProvider.Hotels.Where(h => h.City == city)
                : null;
            _logger.LogInformation($"GetAllHotelsInCityDescendingByLocalCategory {city} returns {(match != null ? match.Count() : 0)} elements");

            return match != null && match.Count() != 0 ? match.OrderByDescending(h => h.LocalCategory).ToList()
                : null;
        }
    }
}
