using HotelManagementWebAPI.Context;
using HotelManagementWebAPI.Contracts;
using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Repository
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly DapperContext _dapperContext;

        public CheckInRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public Task<CheckIn> createCheckIn(int booking_id)//Bookiung id to create a checkin
        {
            throw new NotImplementedException();
        }

        public async Task<CheckIn> deleteCheckIn(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CheckIn> updateCheckIn(int id)
        {
            throw new NotImplementedException();
        }
    }
}
