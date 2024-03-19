using Dapper;
using HotelManagementWebAPI.Context;
using HotelManagementWebAPI.Contracts;
using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DapperContext _context;
        public RoomRepository(DapperContext context) { _context = context; }
        public async Task<IEnumerable<Room>> getRooms()
        {
            var query = "select * from Rooms";

            using (var con = _context.CreateConnection())
            {
                var rooms = await con.QueryAsync<Room>(query);

                return rooms.ToList();
            }

        }

        public async Task<IEnumerable<Room>> getRoomsByHotel(int id)
        {
            var query = "select * from Rooms where Hotel_Id=" + id;

            using(var con=_context.CreateConnection()) { 
            
                var rooms=await con.QueryAsync<Room>(query);    
                return rooms.ToList();
            }
        }
    }
}
