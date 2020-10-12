using PatientsSchedule.Core.Models;
using PatientsSchedule.Library.DapperDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.Teeth
{
    public class DapperToothRepository : IDapperToothRepository
    {
        private readonly IDapperSqlDataAccess _sql;

        public DapperToothRepository(IDapperSqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task<Tooth> GetToothByIdAsync(int id)
        {
            var output = await _sql.LoadData<Tooth, dynamic>("spTooth_GetById", new { Id = id });
            return output.FirstOrDefault();
        }

        public async Task<Tooth> GetToothByCodeAsync(int toothCode)
        {
            var output = await _sql.LoadData<Tooth, dynamic>("spTooth_GetByCode", new { ToothCode = toothCode });
            return output.FirstOrDefault();
        }

        public async Task<IEnumerable<Tooth>> GetTeethAsync()
        {
            var output = await _sql.LoadData<Tooth, dynamic>("spTeeth_GetAll", new { });
            return output;
        }
    }
}
