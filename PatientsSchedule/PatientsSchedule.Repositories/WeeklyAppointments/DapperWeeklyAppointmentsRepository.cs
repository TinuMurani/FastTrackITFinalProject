using PatientsSchedule.Core.Models;
using PatientsSchedule.Library.DapperDataAccess;
using PatientsSchedule.Repositories.Appointments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.WeeklyAppointments
{
    public class DapperWeeklyAppointmentsRepository : IDapperWeeklyAppointmentsRepository
    {
        private readonly IDapperAppointmentRepository _appointmentRepository;
        private DateTime _monday;

        public DapperWeeklyAppointmentsRepository(IDapperAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Core.Models.WeeklyAppointments> GetWeeklyAppointments(DateTime referenceDate)
        {
            _monday = referenceDate.AddDays(1 - Helpers.DateConverter.GetIntDayOfWeek(referenceDate.DayOfWeek));
            Core.Models.WeeklyAppointments output = new Core.Models.WeeklyAppointments();

            output.MondayAppointments = await _appointmentRepository.GetAppointmentsByDateAsync(_monday);
            output.TuesdayAppointments = await _appointmentRepository.GetAppointmentsByDateAsync(_monday.AddDays(1));
            output.WednesdayAppointments = await _appointmentRepository.GetAppointmentsByDateAsync(_monday.AddDays(2));
            output.ThursdayAppointments = await _appointmentRepository.GetAppointmentsByDateAsync(_monday.AddDays(3));
            output.FridayAppointments = await _appointmentRepository.GetAppointmentsByDateAsync(_monday.AddDays(4));
            output.SaturdayAppointments = await _appointmentRepository.GetAppointmentsByDateAsync(_monday.AddDays(5));
            output.SundayAppointments = await _appointmentRepository.GetAppointmentsByDateAsync(_monday.AddDays(6));

            output.MondayDate = _monday.ToShortDateString();
            output.TuesdayDate = _monday.AddDays(1).ToShortDateString();
            output.WednesdayDate = _monday.AddDays(2).ToShortDateString();
            output.ThursdayDate = _monday.AddDays(3).ToShortDateString();
            output.FridayDate = _monday.AddDays(4).ToShortDateString();
            output.SaturdayDate = _monday.AddDays(5).ToShortDateString();
            output.SundayDate = _monday.AddDays(6).ToShortDateString();

            return output;
        }
    }
}
