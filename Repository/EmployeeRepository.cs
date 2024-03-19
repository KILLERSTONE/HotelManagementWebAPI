using Dapper;
using HotelManagementWebAPI.Context;
using HotelManagementWebAPI.Contracts;
using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context) {
            _context = context;
}
        public async Task<IEnumerable<Employee>> getEmployees()
        {

            var query = "select * from HotelEmployee";

            using(var connection=_context.CreateConnection())
            {
                var Employees =await connection.QueryAsync<Employee>(query);

                return Employees.ToList();

            }
        }

        public async Task<IEnumerable<Employee>> getEmployeeByHotel(int hId)
        {
            var query = "select * from HotelEmployee where Hotel_Id=" + hId;
            using (var connection = _context.CreateConnection())
            {
                var Employees = await connection.QueryAsync<Employee>(query);

                return Employees.ToList();

            }

        }

    }
}
