﻿using Dapper;
using System.Collections.Generic;

namespace CTRL.Core.Interfaces
{
    public interface IRepository
    {
        void ExecuteStoredProcedureCommand(string sproc, DynamicParameters parameters);

        IEnumerable<T> ExecuteStoredProcedureQuery<T>(string sproc, DynamicParameters parameters);
    }
}
