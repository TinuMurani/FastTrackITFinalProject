using PatientsSchedule.Core.Models;
using PatientsSchedule.Library.DapperDataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatientsSchedule.Repositories.Interventions
{
    public class DapperInterventionRepository : IDapperInterventionRepository
    {
        private readonly IDapperSqlDataAccess _sql;

        public DapperInterventionRepository(IDapperSqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task<Intervention> GetInterventionById(int id)
        {
            try
            {
                var result = await _sql.LoadData<Intervention, dynamic>("spIntervention_GetById", new { Id = id });
                return result.FirstOrDefault();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Intervention>> GetInterventionsByAppointmentId(int id)
        {
            try
            {
                var result = await _sql.LoadData<Intervention, dynamic>("spIntervention_GetByAppointmentId", new { AppointmentId = id });
                return result;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Intervention>> GetInterventionsByPatientId(int id)
        {
            try
            {
                var result = await _sql.LoadData<Intervention, dynamic>("spIntervention_GetByPatientId", new { PatientId = id });
                return result;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> SaveInterventionAsync(Intervention intervention)
        {
            try
            {
                var result = await _sql.SaveData<Intervention, dynamic>("spIntervention_Insert",
                    new
                    {
                        intervention.AppointmentId,
                        intervention.ToothId,
                        intervention.Description
                    });

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> UpdateInterventionAsync(Intervention intervention)
        {
            try
            {
                var result = await _sql.SaveData<Intervention, dynamic>("spIntervention_Update",
                    new
                    {
                        intervention.Id,
                        intervention.AppointmentId,
                        intervention.ToothId,
                        intervention.Description
                    });

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> DeleteInterventionByIdAsync(int id)
        {
            try
            {
                return await _sql.SaveData<int, dynamic>("spIntervention_DeleteById", new { Id = id });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> DeleteInterventionByAppointmentIdAsync(int appointmentId)
        {
            try
            {
                return await _sql.SaveData<int, dynamic>("spIntervention_DeleteByAppointmentId", new { AppointmentId = appointmentId });
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> DeleteInterventionByPatinetIdAsync(int appointmentId)
        {
            try
            {
                return await _sql.SaveData<int, dynamic>("spIntervention_DeleteByPatientId", new { Patient = appointmentId });
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
