using PatientsSchedule.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.Interventions
{
    public interface IDapperInterventionRepository
    {
        Task<Intervention> GetInterventionById(int id);
        Task<IEnumerable<Intervention>> GetInterventionsByAppointmentId(int id);
        Task<IEnumerable<Intervention>> GetInterventionsByPatientId(int id);
        Task<int> SaveInterventionAsync(Intervention intervention);
        Task<int> UpdateInterventionAsync(Intervention intervention);
        Task<int> DeleteInterventionByIdAsync(int id);
        Task<int> DeleteInterventionByAppointmentIdAsync(int appointmentId);
        Task<int> DeleteInterventionByPatinetIdAsync(int appointmentId);
    }
}