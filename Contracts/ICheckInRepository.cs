using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Contracts
{
    public interface ICheckInRepository
    {

        public Task<CheckIn> createCheckIn(int id);//Using booking id to create checkin

        public Task<CheckIn> updateCheckIn(int id);//Using checkin id to update checkin

        public Task<CheckIn> deleteCheckIn(int id); //Using checkin id to delete checkin


    }
}
