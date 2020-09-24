using System;
using System.Collections.Generic;
using System.Text;

namespace PatientsSchedule.Core.Models
{
    public class WeeklyAppointments
    {
        public IEnumerable<Appointment> MondayAppointments { get; set; }
        public IEnumerable<Appointment> TuesdayAppointments { get; set; }
        public IEnumerable<Appointment> WednesdayAppointments { get; set; }
        public IEnumerable<Appointment> ThursdayAppointments { get; set; }
        public IEnumerable<Appointment> FridayAppointments { get; set; }
        public IEnumerable<Appointment> SaturdayAppointments { get; set; }
        public IEnumerable<Appointment> SundayAppointments { get; set; }

        public string MondayDate { get; set; }
        public string TuesdayDate { get; set; }
        public string WednesdayDate { get; set; }
        public string ThursdayDate { get; set; }
        public string FridayDate { get; set; }
        public string SaturdayDate { get; set; }
        public string SundayDate { get; set; }
    }
}
