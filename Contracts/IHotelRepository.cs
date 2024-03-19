using HotelManagementWebAPI.DTO;
using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Contracts
{
    public interface IHotelRepository
    {

        public Task<IEnumerable<Hotel>> getHotels();
        public Task<Hotel> getHotelById(int id);

        public Task<Hotel> CreateHotel(HotelForCreationDTO hotel);

        public Task UpdateHotel(int id, HotelForUpdateDTO company);

        public Task DeleteHotel(int id);

        public Task<Hotel> GetHotelByEmployeeId(int id);

        public Task<Hotel> getMultipleResults(int id);

        public Task<List<Hotel>> getMultipleMapping();

        public Task CreateMultipleHotels(List<HotelForCreationDTO> hotels);
    }
}
