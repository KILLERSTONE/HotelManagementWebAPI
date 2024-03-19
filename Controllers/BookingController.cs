using HotelManagementWebAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;


        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;

        }


        [HttpGet]
        public async Task<IActionResult> getBookings()
        {
            var bookings = await _bookingRepository.getBooking();
            return Ok(bookings);
        }


    }
}
