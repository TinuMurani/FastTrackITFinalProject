using PatientsSchedule.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.Appointments
{
    public interface IDapperAppointmentRepository
    {
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date);
        Task<int> SaveAppointmentAsync(Appointment appointment);
        Task<int> UpdateAppointmentAsync(Appointment appointment);
        Task<int> DeleteAppointmentAsync(int id);
    }
}