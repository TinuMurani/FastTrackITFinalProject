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
        private readonly IConfiguration _configuration;
        private readonly ISqlDataAccess _sql;

        public DbDataAccess(IConfiguration configuration, ISqlDataAccess sql)
        {
            _configuration = configuration;
            _sql = sql;
        }

        public async Task<PatientModel> GetPatientByIdAsync(int id)
        {
            var patient = await _sql.LoadData<PatientModel, dynamic>("spPatients_GetById", new { Id = id });

            return patient.FirstOrDefault();
        }

        public async Task<IEnumerable<PatientModel>> GetAllPatientsAsync()
        {
            return await _sql.LoadData<PatientModel, dynamic>("spPatients_GetAll", new { });
        }

        public async Task<int> SavePatientAsync(PatientModel patient)
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

        public async Task<int> UpdatePatientAsync(PatientModel patient)
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

        public async Task<int> DeletePatientAsync(int id)
        {
            return await _sql.SaveData<PatientModel, dynamic>("spPatients_DeleteById", new { Id = id });
        }

        public async Task<IEnumerable<AppointmentModel>> GetAppointmentsByDateAsync(string date)
        {
            var result = await _sql.LoadData<AppointmentModel, dynamic>("spAppointments_GetByDate", new { AppointmentDate = date } );

            return result;
        }
    }
}
