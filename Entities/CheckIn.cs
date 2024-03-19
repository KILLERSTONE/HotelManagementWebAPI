namespace HotelManagementWebAPI.Entities
{
    public class CheckIn
    {
        public int checkinId { get; set; }
        public Boolean checkinStatus { get; set; }

        public Booking booking { set; get; }

    }
}
