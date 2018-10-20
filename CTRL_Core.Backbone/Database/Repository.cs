using CTRL_Core.Backbone.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace CTRL_Core.Backbone.Database
{
    public class Repository : IRepository
    {
        private IDatabaseConnection _connection;

        public Repository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public void ExecuteStoredProcedureCommand(string sproc, DynamicParameters parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(_connection.ConnectionString))
            {
                connection.Execute(sproc, parameters, commandType: CommandType.StoredProcedure);
            };
        }

        public IEnumerable<T> ExecuteStoredProcedureQuery<T>(string sproc, DynamicParameters parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(_connection.ConnectionString))
            {
                return connection.Query<T>(sproc, parameters, commandType: CommandType.StoredProcedure) ?? new List<T>();
            };
        }
    }
}
