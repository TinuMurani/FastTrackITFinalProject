using PatientsSchedule.Repositories.Appointments;
using PatientsSchedule.Repositories.Patients;
using PatientsSchedule.Repositories.Teeth;
using PatientsSchedule.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Internal
{
    public static class InterventionConverters
    {
        public static Intervention InterventionForFrontEnd(Core.Models.Intervention intervention, 
            IDapperToothRepository toothRepository, 
            IDapperPatientRepository patientRepository,
            IDapperAppointmentRepository appointmentRepository)
        {
            Intervention output = new Intervention();

            output.Id = intervention.Id;
            output.AppointmentId = intervention.AppointmentId;
            output.PatientName = PatientConverter.PatientForFrontEnd(
                patientRepository.GetPatientByIdAsync(
                    appointmentRepository.GetAppointmentByIdAsync(intervention.AppointmentId)
                    .Result.PatientId)
                .Result)
                .FullName;
            output.AppointmentDate = appointmentRepository.GetAppointmentByIdAsync(intervention.AppointmentId).Result.AppointmentDate;
            output.ToothId = intervention.ToothId;
            output.ToothCode = toothRepository.GetToothByIdAsync(intervention.ToothId).Result.ToothCode;
            output.Description = intervention.Description;

            return output;
        }

        public static IEnumerable<Intervention> InterventionsForFrontEnd(IEnumerable<Core.Models.Intervention> interventions, 
            IDapperToothRepository toothRepository,
            IDapperPatientRepository patientRepository,
            IDapperAppointmentRepository appointmentRepository)
        {
            List<Intervention> output = new List<Intervention>();

            foreach (var intervention in interventions)
            {
                output.Add(InterventionForFrontEnd(intervention, toothRepository, patientRepository, appointmentRepository));
            }

            return output;
        }
    }
}
