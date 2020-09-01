using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PatientsSchedule.Library.DataAccess;
using PatientsSchedule.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.DataOperations
{
    public class DbDataAccess : IDbDataAccess
    {
        private readonly ISqlDataAccess _sql;

        public DbDataAccess(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task<PatientModel> GetPatientByIdAsync(int id)
        {
            try
            {
                var patient = await _sql.LoadData<PatientModel, dynamic>("spPatients_GetById", new { Id = id });

                return patient.FirstOrDefault();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PatientModel>> GetAllPatientsAsync()
        {
            try
            {
                return await _sql.LoadData<PatientModel, dynamic>("spPatients_GetAll", new { });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> SavePatientAsync(PatientModel patient)
        {
            try
            {
                return await _sql.SaveData<PatientModel, dynamic>("spPatients_Insert",
                        new
                        {
                            patient.FirstName,
                            patient.LastName,
                            patient.Address,
                            patient.PhoneNumber,
                            patient.Email
                        });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> UpdatePatientAsync(PatientModel patient)
        {
            try
            {
                return await _sql.SaveData<PatientModel, dynamic>("spPatients_Update",
                        new
                        {
                            patient.Id,
                            patient.FirstName,
                            patient.LastName,
                            patient.Address,
                            patient.PhoneNumber,
                            patient.Email
                        });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> DeletePatientAsync(int id)
        {
            try
            {
                return await _sql.SaveData<PatientModel, dynamic>("spPatients_DeleteById", new { Id = id });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AppointmentModel>> GetAppointmentsByDateAsync(string date)
        {
            try
            {
                var result = await _sql.LoadData<AppointmentModel, dynamic>("spAppointments_GetByDate", new { AppointmentDate = date });

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> SaveAppointmentAsync(AppointmentModel appointment)
        {
            try
            {
                return await _sql.SaveData<AppointmentModel, dynamic>("spAppointments_Insert",
                        new
                        {
                            appointment.PatientId,
                            appointment.AppointmentDate,
                            appointment.AppointmentDuration
                        });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<AppointmentModel> GetAppointmentByIdAsync(int id)
        {
            try
            {
                var result = await _sql.LoadData<AppointmentModel, dynamic>("spAppointments_GetById", new { Id = id });

                return result.FirstOrDefault();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> UpdateAppointmentAsync(AppointmentModel appointment)
        {
            try
            {
                return await _sql.SaveData<AppointmentModel, dynamic>("spAppointments_Update",
                        new
                        {
                            Id = appointment.Id,
                            PatientId = appointment.PatientId,
                            AppointmentDate = appointment.AppointmentDate,
                            AppointmentDuration = appointment.AppointmentDuration
                        });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> DeleteAppointmentAsync(int id)
        {
            try
            {
                return await _sql.SaveData<AppointmentModel, dynamic>("spAppointments_DeleteById", new { Id = id });
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
