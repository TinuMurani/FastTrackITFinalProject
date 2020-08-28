using PatientsSchedule.Web.DataOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }

        public string FullName { get; set; }
        
        public string AppointmentDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime FromHour { get; set; }

        [DataType(DataType.Time)]
        public DateTime ToHour { get; set; }
        public string AppointmentDuration { get; set; }
    }
}
