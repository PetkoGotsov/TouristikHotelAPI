namespace TouristikHotelAPI.Models
{
    public class Hotel
    {
        public string Code { get; set; }
    
        public string HotelName { get; set; }

        public double LocalCategory { get; set; }

        public string City { get; set; }

        public int NumberOfRooms { get; set; }

        public List<GuestRoom> GuestRooms { get; set; }

    }
}
