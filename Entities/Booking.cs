namespace HotelManagementWebAPI.Entities
{
    public class Booking
    {
        public int bookingId { get; set; }
        public DateTime bookingDate { get; set; }

        public string invoice { get; set; }

    }
}
