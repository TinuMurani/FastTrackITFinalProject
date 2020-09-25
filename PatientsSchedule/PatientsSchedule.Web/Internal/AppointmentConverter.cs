using Microsoft.AspNetCore.Components.Forms;
using PatientsSchedule.Repositories.Appointments;
using PatientsSchedule.Repositories.Patients;
using PatientsSchedule.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Internal
{
    public static class AppointmentConverter
    {
        public static async Task<Appointment> AppointmentForFrontEnd(Core.Models.Appointment input, IDapperPatientRepository patientRepository)
        {
            Appointment output = new Appointment();

            output.Id = input.Id;
            output.PatientId = input.PatientId;
            output.FullName = PatientConverter.PatientForFrontEnd(await patientRepository.GetPatientByIdAsync(input.PatientId)).FullName;
            output.AppointmentDate = input.AppointmentDate;
            output.AppointmentDuration = input.AppointmentDuration;
            output.FromHour = input.AppointmentDuration.Substring(0, 2);
            output.FromMinute = input.AppointmentDuration.Substring(2, 2);
            output.ToHour = input.AppointmentDuration.Substring(4, 2);
            output.ToMinute = input.AppointmentDuration.Substring(6, 2);

            return output;
        }

        public static Core.Models.Appointment AppointmentForDb(Appointment input)
        {
            Core.Models.Appointment output = new Core.Models.Appointment();

            output.Id = input.Id;
            output.PatientId = input.PatientId;
            output.AppointmentDate = input.AppointmentDate.Date;
            output.AppointmentDuration = $"{ input.FromHour }{ input.FromMinute }{ input.ToHour }{ input.ToMinute }";

            return output;
        }
    }
}
