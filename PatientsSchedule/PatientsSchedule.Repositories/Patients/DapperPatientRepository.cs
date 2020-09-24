using PatientsSchedule.Core.Models;
using PatientsSchedule.Library.DapperDataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.Patients
{
    public class DapperPatientRepository : IDapperPatientRepository
    {
        private readonly IDapperSqlDataAccess _sql;

        public DapperPatientRepository(IDapperSqlDataAccess sql)
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
    }
}
