namespace HotelManagementWebAPI.Entities
{
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get;set; }
        public string Employee_Password { get;set; }

        public string Employee_Designation { get;set; }

        public string Employee_Address { get;set; } 
        public string Employee_Email { get;set;}

        //public int hId { get; set; }
    }
}
