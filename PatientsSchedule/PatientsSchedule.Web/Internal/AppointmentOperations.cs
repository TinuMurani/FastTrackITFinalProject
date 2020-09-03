using PatientsSchedule.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Internal
{
    public static class AppointmentOperations
    {
        public static AppointmentModel PrepareForFrontEnd(AppointmentModel input)
        {
            AppointmentModel output = new AppointmentModel();

            output.Id = input.Id;
            output.PatientId = input.PatientId;
            output.AppointmentDate = InternalConverters.FromStringToDate(input.AppointmentDate);
            output.AppointmentDuration = input.AppointmentDuration;
            output.FromHour = InternalConverters.FromStringFromHour(input.AppointmentDuration);
            output.FromMinute = InternalConverters.FromStringFromMinute(input.AppointmentDuration);
            output.ToHour = InternalConverters.FromStringToHour(input.AppointmentDuration);
            output.ToMinute = InternalConverters.FromStringToMinute(input.AppointmentDuration);

            return output;
        }

        public static AppointmentModel PrepareForFrontEndFormattedDate(AppointmentModel input)
        {
            AppointmentModel output = new AppointmentModel();

            output.Id = input.Id;
            output.PatientId = input.PatientId;
            output.FullName = input.FullName;
            output.AppointmentDate = $"{ input.AppointmentDate.Substring(6, 2) }/{ input.AppointmentDate.Substring(4, 2) }/{ input.AppointmentDate.Substring(0, 4) }";
            output.AppointmentDuration = @$"{ input.AppointmentDuration.Substring(0, 2) }:{ input.AppointmentDuration.Substring(2, 2) } - 
                                            { input.AppointmentDuration.Substring(4, 2) }:{ input.AppointmentDuration.Substring(6, 2) }";
            output.FromHour = InternalConverters.FromStringFromHour(input.AppointmentDuration);
            output.FromMinute = InternalConverters.FromStringFromMinute(input.AppointmentDuration);
            output.ToHour = InternalConverters.FromStringToHour(input.AppointmentDuration);
            output.ToMinute = InternalConverters.FromStringToMinute(input.AppointmentDuration);

            return output;
        }

        public static AppointmentModel PrepareForDatabase(AppointmentModel input)
        {
            AppointmentModel output = new AppointmentModel();

            output.Id = input.Id;
            output.PatientId = input.PatientId;
            output.AppointmentDate = input.AppointmentDate.Replace("-", string.Empty);
            output.AppointmentDuration = InternalConverters.GetDatabaseStringDuration(
                input.FromHour,
                input.FromMinute,
                input.ToHour,
                input.ToMinute);

            return output;
        }
    }
}
