using PatientsSchedule.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.Patients
{
    public interface IDapperPatientRepository
    {
        Task<Patient> GetPatientByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<int> SavePatientAsync(Patient patient);
        Task<int> UpdatePatientAsync(Patient patient);
        Task<int> DeletePatientAsync(int id);
    }
}