using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string AppointmentDate { get; set; }

        public string AppointmentDuration { get; set; }
    }
}
