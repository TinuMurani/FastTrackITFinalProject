using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PatientsSchedule.Library.DapperDataAccess;
using PatientsSchedule.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Web.DataOperations
{
    public class DbDataAccess : IDbDataAccess
    {
        private readonly IDapperSqlDataAccess _sql;

        public DbDataAccess(IDapperSqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            try
            {
                var patient = await _sql.LoadData<Patient, dynamic>("spPatients_GetById", new { Id = id });

                return patient.FirstOrDefault();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            try
            {
                return await _sql.LoadData<Patient, dynamic>("spPatients_GetAll", new { });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> SavePatientAsync(Patient patient)
        {
            try
            {
                return await _sql.SaveData<Patient, dynamic>("spPatients_Insert",
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

        public async Task<int> UpdatePatientAsync(Patient patient)
        {
            try
            {
                return await _sql.SaveData<Patient, dynamic>("spPatients_Update",
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
                return await _sql.SaveData<Patient, dynamic>("spPatients_DeleteById", new { Id = id });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(string date)
        {
            try
            {
                var result = await _sql.LoadData<Appointment, dynamic>("spAppointments_GetByDate", new { AppointmentDate = date });

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> SaveAppointmentAsync(Appointment appointment)
        {
            try
            {
                return await _sql.SaveData<Appointment, dynamic>("spAppointments_Insert",
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

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            try
            {
                var result = await _sql.LoadData<Appointment, dynamic>("spAppointments_GetById", new { Id = id });

                return result.FirstOrDefault();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> UpdateAppointmentAsync(Appointment appointment)
        {
            try
            {
                return await _sql.SaveData<Appointment, dynamic>("spAppointments_Update",
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
                return await _sql.SaveData<Appointment, dynamic>("spAppointments_DeleteById", new { Id = id });
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
