using PatientsSchedule.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.DataOperations
{
    public interface IDbDataAccess
    {
        Task<PatientModel> GetPatientByIdAsync(int id);
        Task<IEnumerable<PatientModel>> GetAllPatientsAsync();
        Task<int> SavePatientAsync(PatientModel patient);
        Task<int> UpdatePatientAsync(PatientModel patient);
        Task<int> DeletePatientAsync(int id);
        Task<IEnumerable<AppointmentModel>> GetAppointmentsByDateAsync(string date);
    }
}