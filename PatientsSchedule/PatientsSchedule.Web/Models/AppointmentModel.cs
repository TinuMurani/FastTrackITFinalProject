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
        [DisplayName("Numele pacientului")]
        public int PatientId { get; set; }

        [DisplayName("Numele pacientului")]
        public string FullName { get; set; }
        
        [Required]
        [DisplayName("Data programarii")]
        public string AppointmentDate { get; set; }

        [Required]
        [DisplayName("De la ora")]
        public string FromHour { get; set; }
        
        [Required]
        [DisplayName("Minutul")]
        public string FromMinute { get; set; }

        [Required]
        [DisplayName("Pana la ora")]
        public string ToHour { get; set; }
        
        [Required]
        [DisplayName("Minutul")]
        public string ToMinute { get; set; }

        [DisplayName("Durata programarii")]
        public string AppointmentDuration { get; set; }
    }
}
