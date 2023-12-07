using TouristikHotelAPI.Models;

namespace TouristikHotelAPI.Services
{
    public interface IHotelRoomService
    {
        public List<GuestRoom> GetGuestRoomsWithPriceForHotelCode(string hotelCode);

        public string GetCheapestHotelForRoomType(string room);

        public List<Hotel> GetAllHotelsInCityDescendingByLocalCategory(string city);

    }
}
