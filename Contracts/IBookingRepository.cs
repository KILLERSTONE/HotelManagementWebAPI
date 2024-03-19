using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Contracts
{
    public interface IBookingRepository
    {

        public Task<IEnumerable<Booking>> getBooking();

        public Task<IEnumerable<Booking>> getBookingsByCustomer(string id);

    }
}
