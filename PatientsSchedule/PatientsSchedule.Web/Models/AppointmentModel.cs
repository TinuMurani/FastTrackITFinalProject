using PatientsSchedule.Web.DataOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Patient's Name")]
        public int PatientId { get; set; }

        [DisplayName("Patient's Name")]
        public string FullName { get; set; }
        
        [Required]
        [DisplayName("Appointment Date")]
        public string AppointmentDate { get; set; }

        [Required]
        [DisplayName("From Hour")]
        public string FromHour { get; set; }
        
        [Required]
        [DisplayName("From Minute")]
        public string FromMinute { get; set; }

        [Required]
        [DisplayName("To Hour")]
        public string ToHour { get; set; }
        
        [Required]
        [DisplayName("To Minute")]
        public string ToMinute { get; set; }

        [DisplayName("Appointment Duration")]
        public string AppointmentDuration { get; set; }
    }
}
