using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Models
{
    public class InterventionView
    {
        public Intervention Intervention { get; set; }
        public IEnumerable<Intervention> InterventionList { get; set; }
    }
}
