using HotelManagementWebAPI.Contracts;
using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<Customer> getCustomerByAdhar(string adhar)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> getCustomerByDOJ(DateOnly doj)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> setCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
