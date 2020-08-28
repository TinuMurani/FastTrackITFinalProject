using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace PatientsSchedule.Library.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private IConfiguration _configuration;
        private string _connectionString;
        private readonly string _dbConnectionStringName = "ScheduleDatabase";

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetConnectionString(_dbConnectionStringName);
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                IEnumerable<T> rows = await connection.QueryAsync<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);

                return rows;
            }
        }

        public async Task<int> SaveData<T, U>(string storedProcedure, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                int output = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return output;
            }
        }
    }
}
