using System;
using System.Collections.Generic;
using System.Text;

namespace PatientsSchedule.Core.Models
{
    public class Intervention
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int ToothId { get; set; }
        public string Description { get; set; }
    }
}

