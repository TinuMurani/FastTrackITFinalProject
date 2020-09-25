using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Internal
{
    public static class InternalConverters
    {
        public static string GetFrontEndStringDuration(string duration)
        {
            return $"{ duration.Substring(0, 2) }:{ duration.Substring(2, 2) } - { duration.Substring(4, 2) }:{ duration.Substring(6, 2) }";
        }

    }
}
