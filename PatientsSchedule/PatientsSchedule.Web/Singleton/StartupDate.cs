using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Singleton
{
    public class StartupDate : IStartupDate
    {
        public DateTime ReferenceDate { get; set; } = DateTime.Now;
    }
}
