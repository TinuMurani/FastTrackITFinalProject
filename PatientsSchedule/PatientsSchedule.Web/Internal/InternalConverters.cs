using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Internal
{
    public class InternalConverters
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

        public static string GetStringDate(DateTime date)
        {
            return $"{ date.Year }{ date.Month.ToString().PadLeft(2, '0') }{ date.Day.ToString().PadLeft(2, '0') }";
        }

        public static string GetFormattedStringDate(DateTime date)
        {
            return $"{ date.Day.ToString().PadLeft(2, '0') }/{ date.Month.ToString().PadLeft(2, '0') }/{ date.Year }";
        }
        public static string GetFormattedStringDuration(string duration)
        {
            return $"{ duration.Substring(0, 2) }:{ duration.Substring(2, 2) } - { duration.Substring(4, 2) }:{ duration.Substring(6, 2) }";
        }
    }
}
