﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientsSchedule.Library.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task<int> SaveData<T, U>(string storedProcedure, U parameters);
    }
}