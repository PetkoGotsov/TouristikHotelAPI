namespace TouristikHotelAPI.Models
{
    public class HotelProvider
    {
        public string Id { get; set; }
    
        public string Name { get; set; }

        public string Currency { get; set; }

        public List<Hotel> Hotels { get; set; }

    }
}
