using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Contracts
{
    public interface IEmployeeRepository
    {

        public Task<IEnumerable<Employee>> getEmployees();


        public Task<IEnumerable<Employee>> getEmployeeByHotel(int id);
    }
}
