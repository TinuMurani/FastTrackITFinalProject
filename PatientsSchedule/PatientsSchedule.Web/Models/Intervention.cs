using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Models
{
    public class Intervention
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime AppointmentDate { get; set; }
        public int ToothId { get; set; }
        public int ToothCode { get; set; }
        public string Description { get; set; }
    }
}
