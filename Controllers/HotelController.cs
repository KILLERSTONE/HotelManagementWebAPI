using HotelManagementWebAPI.Contracts;
using HotelManagementWebAPI.DTO;
using HotelManagementWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRoomRepository _roomRepository;

        public HotelController(IHotelRepository hotelRepository, IEmployeeRepository employeeRepository, IRoomRepository roomRepository)
        {
            _hotelRepository = hotelRepository;
            _employeeRepository = employeeRepository;
            _roomRepository = roomRepository;
        }

        private async Task getDetails(Hotel hotel)
        {
            hotel.Employees = (List<Employee>)await _employeeRepository.getEmployeeByHotel(hotel.Hotel_Id);
            hotel.Rooms = (List<Room>)await _roomRepository.getRoomsByHotel(hotel.Hotel_Id);
        }

        [HttpGet]
        public async Task<IActionResult> getHotels()
        {
            var hotels = await _hotelRepository.getHotels();

            foreach (Hotel hotel in hotels)
            {
                await getDetails(hotel);
            }

            return Ok(hotels);
        }

        [HttpGet("{id}", Name = "getHotelById")]
        public async Task<IActionResult> getHotelById(int id)
        {
            var hotel = await _hotelRepository.getHotelById(id);

            if (hotel is null)
                return NotFound();
            else
            {
                await getDetails(hotel);
                return Ok(hotel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> createHotel([FromBody] HotelForCreationDTO hotel)
        {
            var createdHotel = await _hotelRepository.CreateHotel(hotel);
            return CreatedAtRoute("getHotelById", new { id = createdHotel.Hotel_Id }, createdHotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateHotel(int id, [FromBody]HotelForUpdateDTO hotel)
        {
            var dbHotel = await _hotelRepository.getHotelById(id);
            if (dbHotel is null) return NotFound();

            await _hotelRepository.UpdateHotel(id, hotel);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteHotel(int id)
        {
            var hotel = _hotelRepository.getHotelById(id);
            if (hotel is null) return NotFound();

            else
            {
                await _hotelRepository.DeleteHotel(id);
                return NoContent();
            }

        }

        [HttpGet("ByEmployeeId/{id}")]
        public async Task<IActionResult> getHotelByEmployee(int id)
        {
            var hotel=await _hotelRepository.GetHotelByEmployeeId(id);
            if (hotel is null) return NotFound();
            else
            {
                await getDetails(hotel);
                return Ok(hotel);
            }
        }

        [HttpGet("MultipleResults/{id}")]
        public async Task<IActionResult> getMultipleResults(int id)
        {
            var hotel = await _hotelRepository.getMultipleResults(id);

            if(hotel is null) return NotFound();    
            else return Ok(hotel);
        }


        [HttpGet("MultipleMapping")]
        public async Task<IActionResult> getMultipleMapping()
        {
            var hotels = await _hotelRepository.getMultipleMapping();

             return Ok(hotels);
        }
    }
}
