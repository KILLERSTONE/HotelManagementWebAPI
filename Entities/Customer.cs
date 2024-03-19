namespace HotelManagementWebAPI.Entities
{
    public class Customer
    {
        public string cName { get; set; }
        public string cPhno { get; set; }

        public string cAdhar { get; set; }

        public DateOnly DOJ { get; set; } 
        public DateOnly DOL { get; set; }


        public Booking booking { get; set; } = new Booking();

    }
}
