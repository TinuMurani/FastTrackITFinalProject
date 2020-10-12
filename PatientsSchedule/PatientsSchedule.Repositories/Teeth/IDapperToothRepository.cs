using PatientsSchedule.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.Teeth
{
    public interface IDapperToothRepository
    {
        Task<Tooth> GetToothByIdAsync(int id);
        Task<Tooth> GetToothByCodeAsync(int toothCode);
        Task<IEnumerable<Tooth>> GetTeethAsync();
    }
}