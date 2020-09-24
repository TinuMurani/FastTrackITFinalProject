using System;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.WeeklyAppointments
{
    public interface IDapperWeeklyAppointmentsRepository
    {
        Task<Core.Models.WeeklyAppointments> GetWeeklyAppointments(DateTime referenceDate);
    }
}