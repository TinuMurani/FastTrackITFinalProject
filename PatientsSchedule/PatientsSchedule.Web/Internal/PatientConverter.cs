using PatientsSchedule.Web.Models;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PatientsSchedule.Web.Internal
{
    public static class PatientConverter
    {
        public static Patient PatientForFrontEnd(Core.Models.Patient patient)
        {
            return new Patient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Address = patient.Address,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email
            };
        }

        public static Core.Models.Patient PatientForDb(Patient patient)
        {
            return new Core.Models.Patient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Address = patient.Address,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email
            };
        }

        public static List<Patient> ListForFrontEnd(IEnumerable<Core.Models.Patient> patients)
        {
            List<Patient> output = new List<Patient>();

            foreach (var patient in patients)
            {
                output.Add(PatientForFrontEnd(patient));
            }

            return output;
        }
    }
}
