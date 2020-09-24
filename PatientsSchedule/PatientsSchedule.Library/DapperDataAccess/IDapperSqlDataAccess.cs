using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientsSchedule.Library.DapperDataAccess
{
    public interface IDapperSqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task<int> SaveData<T, U>(string storedProcedure, U parameters);
    }
}