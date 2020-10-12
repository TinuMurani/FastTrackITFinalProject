using PatientsSchedule.Web.Models;
using System.Collections.Generic;

namespace PatientsSchedule.Web.Internal
{
    public static class TeethConverters
    {
        public static Tooth ToothForFrontEnd(Core.Models.Tooth tooth) 
        {
            Tooth output = new Tooth();
            output.Id = tooth.Id;
            output.ToothCode = tooth.ToothCode;
            output.ToothDescription = tooth.ToothDescription;

            return output;
        }

        public static List<Tooth> TeethForFrontEnd(IEnumerable<Core.Models.Tooth> teeth)
        {
            List<Tooth> output = new List<Tooth>();

            foreach (var tooth in teeth)
            {
                output.Add(ToothForFrontEnd(tooth));
            }

            return output;
        }
    }
}
