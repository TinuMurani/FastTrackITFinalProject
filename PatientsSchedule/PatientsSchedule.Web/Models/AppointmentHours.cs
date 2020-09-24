using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Models
{
    public class AppointmentHours
    {
        public List<string> Hours 
        {
            get
            {
                List<string> output = new List<string>();

                for (int i = 0; i < 24; i++)
                {
                    output.Add(i.ToString().PadLeft(2, '0'));
                }

                return output;
            }
        }
        public List<string> Minutes 
        {
            get
            {
                List<string> output = new List<string>();

                for (int i = 0; i < 60; i++)
                {
                    output.Add(i.ToString().PadLeft(2, '0'));
                }

                return output;
            }
        }
    }
}
