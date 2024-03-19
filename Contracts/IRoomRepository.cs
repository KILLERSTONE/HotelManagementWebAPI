using HotelManagementWebAPI.Entities;
namespace HotelManagementWebAPI.Contracts
{
    public interface IRoomRepository
    {
        public Task<IEnumerable<Room>> getRooms();

        public Task<IEnumerable<Room>> getRoomsByHotel(int id);
    }
}
