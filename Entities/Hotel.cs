namespace HotelManagementWebAPI.Entities
{
    public class Hotel
    {
        public int Hotel_Id { get; set; }
        public string Hotel_Name { get; set; }
        public string Hotel_Location { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();


        public List<Room> Rooms { get; set; } = new List<Room>();

        internal Hotel ToList()
        {
            throw new NotImplementedException();
        }
    }
}
