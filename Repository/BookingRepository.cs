using Dapper;
using HotelManagementWebAPI.Context;
using HotelManagementWebAPI.Contracts;
using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DapperContext _context;

        public BookingRepository(DapperContext context) { _context = context; }
       
        public async Task<IEnumerable<Booking>> getBooking()
        {
            var q = "select * from Booking";

            using (var con = _context.CreateConnection())
            {
                var bookings = await con.QueryAsync<Booking>(q);

                return bookings.ToList();
            }
        }

        public async Task<IEnumerable<Booking>> getBookingsByCustomer(string phno)
        {
            var q = "select * from Booking where cPhno="+phno;

            using (var con = _context.CreateConnection())
            {
                var bookings = await con.QueryAsync<Booking>(q);

                return bookings.ToList();
            }
        }
    }
}
