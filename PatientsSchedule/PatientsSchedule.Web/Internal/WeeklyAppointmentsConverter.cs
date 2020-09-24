using PatientsSchedule.Repositories.Patients;
using PatientsSchedule.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Internal
{
    public static class WeeklyAppointmentsConverter
    {
        public static WeeklyAppointments AppointmentsForFrontEnd(Core.Models.WeeklyAppointments input, IDapperPatientRepository patientRepository)
        {
            WeeklyAppointments output = new WeeklyAppointments();

            output.MondayAppointments = GetDailyAppointments(input.MondayAppointments, patientRepository);
            output.TuesdayAppointments = GetDailyAppointments(input.TuesdayAppointments, patientRepository);
            output.WednesdayAppointments = GetDailyAppointments(input.WednesdayAppointments, patientRepository);
            output.ThursdayAppointments = GetDailyAppointments(input.ThursdayAppointments, patientRepository);
            output.FridayAppointments = GetDailyAppointments(input.FridayAppointments, patientRepository);
            output.SaturdayAppointments = GetDailyAppointments(input.SaturdayAppointments, patientRepository);
            output.SundayAppointments = GetDailyAppointments(input.SundayAppointments, patientRepository);

            output.MondayDate = input.MondayDate;
            output.TuesdayDate = input.TuesdayDate;
            output.WednesdayDate = input.WednesdayDate;
            output.ThursdayDate = input.ThursdayDate;
            output.FridayDate = input.FridayDate;
            output.SaturdayDate = input.SaturdayDate;
            output.SundayDate = input.SundayDate;

            return output;
        }

        private static List<Appointment> GetDailyAppointments(IEnumerable<Core.Models.Appointment> appointments, IDapperPatientRepository patientRepository)
        {
            List<Appointment> output = new List<Appointment>();

            foreach (var appointment in appointments)
            {
                output.Add(AppointmentConverter.AppointmentForFrontEnd(appointment, patientRepository).Result);
            }

            return output;
        }
    }
}
