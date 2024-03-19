namespace HotelManagementWebAPI.Entities
{
    public class Room
    {

        public int Room_No { get; set; }
        public string Room_Type { get; set; }

        public Boolean is_Available { get; set; }

        public string Room_Price { get; set; }

        public string Room_Amenities { get;set; }



    }
}
