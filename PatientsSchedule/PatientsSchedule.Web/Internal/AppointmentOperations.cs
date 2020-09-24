﻿using PatientsSchedule.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Internal
{
    public static class AppointmentOperations
    {
        public static Appointment PrepareForFrontEnd(Appointment input)
        {
            Appointment output = new Appointment();

            output.Id = input.Id;
            output.PatientId = input.PatientId;
            output.AppointmentDate = input.AppointmentDate;
            output.AppointmentDuration = input.AppointmentDuration;
            output.FromHour = InternalConverters.FromStringFromHour(input.AppointmentDuration);
            output.FromMinute = InternalConverters.FromStringFromMinute(input.AppointmentDuration);
            output.ToHour = InternalConverters.FromStringToHour(input.AppointmentDuration);
            output.ToMinute = InternalConverters.FromStringToMinute(input.AppointmentDuration);

            return output;
        }

        public static Appointment PrepareForFrontEndFormattedDate(Appointment input)
        {
            Appointment output = new Appointment();

            output.Id = input.Id;
            output.PatientId = input.PatientId;
            output.FullName = input.FullName;
            output.AppointmentDate = input.AppointmentDate; //$"{ input.AppointmentDate.Day }/{ input.AppointmentDate.Month }/{ input.AppointmentDate.Year }";
            output.AppointmentDuration = @$"{ input.AppointmentDuration.Substring(0, 2) }:{ input.AppointmentDuration.Substring(2, 2) } - 
                                            { input.AppointmentDuration.Substring(4, 2) }:{ input.AppointmentDuration.Substring(6, 2) }";
            output.FromHour = InternalConverters.FromStringFromHour(input.AppointmentDuration);
            output.FromMinute = InternalConverters.FromStringFromMinute(input.AppointmentDuration);
            output.ToHour = InternalConverters.FromStringToHour(input.AppointmentDuration);
            output.ToMinute = InternalConverters.FromStringToMinute(input.AppointmentDuration);

            return output;
        }

        public static Appointment PrepareForDatabase(Appointment input)
        {
            Appointment output = new Appointment();

            output.Id = input.Id;
            output.PatientId = input.PatientId;
            output.AppointmentDate = input.AppointmentDate; //.Replace("-", string.Empty);
            output.AppointmentDuration = InternalConverters.GetDatabaseStringDuration(
                input.FromHour,
                input.FromMinute,
                input.ToHour,
                input.ToMinute);

            return output;
        }
    }
}
