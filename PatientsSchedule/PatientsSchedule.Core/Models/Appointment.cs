using System;
using System.Collections.Generic;
using System.Text;

namespace PatientsSchedule.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentDuration { get; set; }
    }
}
