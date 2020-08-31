using Microsoft.Extensions.Configuration;
using PatientsSchedule.Library.DataAccess;
using PatientsSchedule.Web.DataOperations;
using PatientsSchedule.Web.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.Models
{
    public class WeeklyAppointmentsModel
    {
        private readonly IDbDataAccess _dbDataAccess;
        DateTime _monday;

        public WeeklyAppointmentsModel(IDbDataAccess dbDataAccess, DateTime referenceDay)
        {
            _dbDataAccess = dbDataAccess;
            _monday = referenceDay.AddDays(1 - InternalConverters.GetIntDayOfWeek(referenceDay.DayOfWeek));
        }

        public async Task<IEnumerable<AppointmentModel>> GetProgramari(DateTime date)
        {
            return await _dbDataAccess.GetAppointmentsByDateAsync(InternalConverters.GetDatabaseStringDate(date));
        }

        [DisplayName("Luni")]
        public List<AppointmentModel> ProgramariLuni 
        {
            get
            {
                List<AppointmentModel> result = new List<AppointmentModel>();

                foreach (var item in GetProgramari(_monday).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }
        //public async Task<IEnumerable<AppointmentModel>> ProgramariLuni()
        //{
        //    return await _dbDataAccess.GetAppointmentsByDateAsync(InternalConverters.GetStringDate(_monday));
        //}

        [DisplayName("Marti")]
        public List<AppointmentModel> ProgramariMarti
        {
            get
            {
                List<AppointmentModel> result = new List<AppointmentModel>();

                foreach (var item in GetProgramari(_monday.AddDays(1)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Miercuri")]
        public List<AppointmentModel> ProgramariMiercuri
        {
            get
            {
                List<AppointmentModel> result = new List<AppointmentModel>();

                foreach (var item in GetProgramari(_monday.AddDays(2)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Joi")]
        public List<AppointmentModel> ProgramariJoi
        {
            get
            {
                List<AppointmentModel> result = new List<AppointmentModel>();

                foreach (var item in GetProgramari(_monday.AddDays(3)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Vineri")]
        public List<AppointmentModel> ProgramariVineri
        {
            get
            {
                List<AppointmentModel> result = new List<AppointmentModel>();

                foreach (var item in GetProgramari(_monday.AddDays(4)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Sambata")]
        public List<AppointmentModel> ProgramariSambata
        {
            get
            {
                List<AppointmentModel> result = new List<AppointmentModel>();

                foreach (var item in GetProgramari(_monday.AddDays(5)).Result)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        [DisplayName("Duminica")]
        public List<AppointmentModel> ProgramariDuminica
        {
            get
            {
                List<AppointmentModel> result = new List<AppointmentModel>();

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
    }
}
