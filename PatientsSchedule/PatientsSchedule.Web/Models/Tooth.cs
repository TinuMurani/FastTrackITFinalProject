using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Models
{
    public class Tooth
    {
        public int Id { get; set; }
        public int ToothCode { get; set; }
        public string ToothDescription { get; set; }
        public string FullDetails
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ToothDescription))
                {
                    return $"{ ToothCode }";
                }

                return $"{ ToothCode } ({ ToothDescription })";
            }
        }
    }
}
