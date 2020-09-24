using System;
using System.Collections.Generic;
using System.Text;

namespace PatientsSchedule.Repositories.Helpers
{
    internal static class DateConverter
    {
        public static int GetIntDayOfWeek(DayOfWeek dayOfWeek)
        {
            int output = 0;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    output = 1;
                    break;
                case DayOfWeek.Tuesday:
                    output = 2;
                    break;
                case DayOfWeek.Wednesday:
                    output = 3;
                    break;
                case DayOfWeek.Thursday:
                    output = 4;
                    break;
                case DayOfWeek.Friday:
                    output = 5;
                    break;
                case DayOfWeek.Saturday:
                    output = 6;
                    break;
                case DayOfWeek.Sunday:
                    output = 7;
                    break;
                default:
                    break;
            }

            return output;
        }
    }
}
