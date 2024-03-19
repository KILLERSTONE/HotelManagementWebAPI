using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Contracts
{
    public interface ICustomerRepository
    {

        public Task<Customer> setCustomer(Customer customer);
        public Task<Customer> getCustomerByAdhar(string adhar);

        public Task<Customer> getCustomerByDOJ(DateOnly doj);
    }
}
