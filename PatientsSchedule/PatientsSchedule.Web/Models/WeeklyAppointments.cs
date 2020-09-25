using System.Collections.Generic;
using System.ComponentModel;

namespace PatientsSchedule.Web.Models
{
    public class WeeklyAppointments
    {
        [DisplayName("Luni")]
        public List<Appointment> MondayAppointments { get; set; }

        [DisplayName("Marti")]
        public List<Appointment> TuesdayAppointments { get; set; }

        [DisplayName("Miercuri")]
        public List<Appointment> WednesdayAppointments { get; set; }

        [DisplayName("Joi")]
        public List<Appointment> ThursdayAppointments { get; set; }

        [DisplayName("Vineri")]
        public List<Appointment> FridayAppointments { get; set; }

        [DisplayName("Sambata")]
        public List<Appointment> SaturdayAppointments { get; set; }

        [DisplayName("Duminica")]
        public List<Appointment> SundayAppointments { get; set; }

        public string MondayDate { get; set; }
        public string TuesdayDate { get; set; }
        public string WednesdayDate { get; set; }
        public string ThursdayDate { get; set; }
        public string FridayDate { get; set; }
        public string SaturdayDate { get; set; }
        public string SundayDate { get; set; }
        /*
        private readonly IDbDataAccess _dbDataAccess;
        private DateTime _monday;

        public WeeklyAppointments(IDbDataAccess dbDataAccess, DateTime referenceDay)
        {
            _dbDataAccess = dbDataAccess;
            _monday = referenceDay.AddDays(1 - InternalConverters.GetIntDayOfWeek(referenceDay.DayOfWeek));
        }

        public async Task<IEnumerable<Appointment>> GetProgramari(DateTime date)
        {
            return await _dbDataAccess.GetAppointmentsByDateAsync(InternalConverters.GetDatabaseStringDate(date));
        }

        [DisplayName("Luni")]
        public List<Appointment> ProgramariLuni 
        {
            get
            {
                List<Appointment> result = new List<Appointment>();

                foreach (var item in GetProgramari(_monday).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Marti")]
        public List<Appointment> ProgramariMarti
        {
            get
            {
                List<Appointment> result = new List<Appointment>();

                foreach (var item in GetProgramari(_monday.AddDays(1)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Miercuri")]
        public List<Appointment> ProgramariMiercuri
        {
            get
            {
                List<Appointment> result = new List<Appointment>();

                foreach (var item in GetProgramari(_monday.AddDays(2)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Joi")]
        public List<Appointment> ProgramariJoi
        {
            get
            {
                List<Appointment> result = new List<Appointment>();

                foreach (var item in GetProgramari(_monday.AddDays(3)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Vineri")]
        public List<Appointment> ProgramariVineri
        {
            get
            {
                List<Appointment> result = new List<Appointment>();

                foreach (var item in GetProgramari(_monday.AddDays(4)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Sambata")]
        public List<Appointment> ProgramariSambata
        {
            get
            {
                List<Appointment> result = new List<Appointment>();

                foreach (var item in GetProgramari(_monday.AddDays(5)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Duminica")]
        public List<Appointment> ProgramariDuminica
        {
            get
            {
                List<Appointment> result = new List<Appointment>();

                foreach (var item in GetProgramari(_monday.AddDays(6)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }


        public string DataLuni
        {
            get
            {
                return InternalConverters.GetFrontEndStringDate(_monday);
            }
        }
        public string DataMarti
        {
            get
            {
                return InternalConverters.GetFrontEndStringDate(_monday.AddDays(1));
            }
        }
        public string DataMiercuri
        {
            get
            {
                return InternalConverters.GetFrontEndStringDate(_monday.AddDays(2));
            }
        }
        public string DataJoi
        {
            get
            {
                return InternalConverters.GetFrontEndStringDate(_monday.AddDays(3));
            }
        }
        public string DataVineri
        {
            get
            {
                return InternalConverters.GetFrontEndStringDate(_monday.AddDays(4));
            }
        }
        public string DataSambata
        {
            get
            {
                return InternalConverters.GetFrontEndStringDate(_monday.AddDays(5));
            }
        }
        public string DataDuminica
        {
            get
            {
                return InternalConverters.GetFrontEndStringDate(_monday.AddDays(6));
            }
        }
        */
    }
}
