using PatientsSchedule.Core.Models;
using PatientsSchedule.Library.DapperDataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.Appointments
{
    public class DapperAppointmentRepository : IDapperAppointmentRepository
    {
        private readonly IDapperSqlDataAccess _sql;

        public DapperAppointmentRepository(IDapperSqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date)
        {
            try
            {
                var result = await _sql.LoadData<Appointment, dynamic>("spAppointments_GetByDate", new { AppointmentDate = date.Date });

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
