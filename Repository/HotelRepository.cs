using System.Data;
using Dapper;
using HotelManagementWebAPI.Context;
using HotelManagementWebAPI.Contracts;
using HotelManagementWebAPI.DTO;
using HotelManagementWebAPI.Entities;

namespace HotelManagementWebAPI.Repository
{
    public class HotelRepository:IHotelRepository
    {
        private readonly DapperContext _context;

        public HotelRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Hotel> CreateHotel(HotelForCreationDTO Hotel)
        {
            var query = "INSERT INTO Hotel(Hotel_Name,Hotel_Location) VALUES (@Name,@Location)"+
                "Select CAST(SCOPE_IDENTITY() as int)";
            var parameters= new DynamicParameters();
            parameters.Add("Name", Hotel.Name, DbType.String);
            parameters.Add("Location", Hotel.Location, DbType.String);

            using(var con=_context.CreateConnection())
            {
                var id = await con.QuerySingleAsync<int>(query, parameters);

                var createdHotel = new Hotel
                {
                    Hotel_Id = id,
                    Hotel_Name = Hotel.Name,
                    Hotel_Location = Hotel.Location
                };

                return createdHotel;
            }
        }

        public async Task CreateMultipleHotels(List<HotelForCreationDTO> Hotels)
        {
            var query = "INSERT INTO Hotel (Hotel_Name,Hotel_Location) VALUES (@Name,@Location)";

            using(var con=_context.CreateConnection())
            {
                con.Open();

                using(var transaction = con.BeginTransaction())
                {
                    foreach(var Hotel in Hotels) {
                        var parameters=new DynamicParameters();
                        parameters.Add("Name",Hotel.Name, DbType.String);
                        parameters.Add("Location",Hotel.Location, DbType.String);
                        
                        await con.ExecuteAsync(query,parameters,transaction);
                    }
                    transaction.Commit();
                }
            }
        }

        public async Task DeleteHotel(int id)
        {
            var query = "delete from Hotel where Hotel_Id=@id";

            using(var con=_context.CreateConnection())
            {
                await con.ExecuteAsync(query,new {id});
            }
        }

        public async Task<Hotel> GetHotelByEmployeeId(int id)
        {
            var procedureName = "ShowHotelByEmployeeId";
            var parameters=new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32,ParameterDirection.Input);

            using(var con = _context.CreateConnection())
            {
                var Hotel=await con.QueryFirstOrDefaultAsync<Hotel>
                    (procedureName, parameters,commandType: CommandType.StoredProcedure);

                return Hotel;
            }
        }

        public async Task<Hotel> getHotelById(int id)
        {
            var query="SELECT * from Hotel where Hotel_Id=@id";

            using (var con=_context.CreateConnection())
            {
                var Hotels=await con.QuerySingleOrDefaultAsync<Hotel>(query,new {id});
                return Hotels;
            }
        }

        public async Task<IEnumerable<Hotel>> getHotels()
        {
            var query = "SELECT * from Hotel";

            using (var connection = _context.CreateConnection())
            {
                var Hotels=await connection.QueryAsync<Hotel>(query);

                return Hotels.ToList();
            }
        }

        public async Task<List<Hotel>> getMultipleMapping()
        {
            var query = "SELECT h.*, e.* FROM Hotel h JOIN HotelEmployee e ON h.Hotel_Id = e.Hotel_Id";

            using (var con = _context.CreateConnection())
            {
                var HotelDict = new Dictionary<int, Hotel>();
                var Hotels = await con.QueryAsync<Hotel, Employee, Hotel>(
                    query,
                    (Hotel, employee) =>
                    {
                        if (!HotelDict.TryGetValue(Hotel.Hotel_Id, out var currHotel))
                        {
                            currHotel = Hotel;
                            currHotel.Employees = new List<Employee>(); // Initialize the Employees list
                            HotelDict.Add(currHotel.Hotel_Id, currHotel);
                        }

                        currHotel.Employees.Add(employee); // Add employee to the current Hotel

                        return currHotel;
                    },
                    splitOn: "Hotel_Id" // Specify the column to split the result sets
                );

                return Hotels.Distinct().ToList();
            }
        }


        public async Task<Hotel> getMultipleResults(int id)
        {
            var query = "select * from Hotel where Hotel_Id=@id;" +
                        "select * from HotelEmployee where Hotel_Id=@id";

            using (var con = _context.CreateConnection())
            using (var multi = await con.QueryMultipleAsync(query, new { id }))
            {
                var Hotel = await multi.ReadSingleOrDefaultAsync<Hotel>();

                if (Hotel != null)
                {
                    // Specify the correct column name for splitting the result sets
                    Hotel.Employees = (await multi.ReadAsync<Employee>()).ToList();
                }

                return Hotel;
            }
        }

        public async Task UpdateHotel(int id, HotelForUpdateDTO Hotel)
        {
            var query = "update Hotel set";
            var parameters = new DynamicParameters();

            if (Hotel.Name != null)
            {
                query += " Hotel_Name = @Name,";
                parameters.Add("Name", Hotel.Name, DbType.String);
            }

            if (Hotel.Location != null)
            {
                query += " Hotel_Location = @Location,";
                parameters.Add("Location", Hotel.Location, DbType.String);
            }

            query = query.TrimEnd(',');

            query += " where Hotel_Id = @Id";
            parameters.Add("Id", id, DbType.Int32);

            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }


    }
}
