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

        [Required]
        public int PatientId { get; set; }

        public string FullName { get; set; }
        
        [Required]
        public string AppointmentDate { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        public string FromHour { get; set; }
        
        [Required]
        public string FromMinute { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        public string ToHour { get; set; }
        
        [Required]
        public string ToMinute { get; set; }
        public string AppointmentDuration { get; set; }
    }
}
