using PatientsSchedule.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.DataOperations
{
    public interface IDbDataAccess
    {
        Task<Patient> GetPatientByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<int> SavePatientAsync(Patient patient);
        Task<int> UpdatePatientAsync(Patient patient);
        Task<int> DeletePatientAsync(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(string date);
        Task<int> SaveAppointmentAsync(Appointment appointment);
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<int> UpdateAppointmentAsync(Appointment appointment);
        Task<int> DeleteAppointmentAsync(int id);
    }
}