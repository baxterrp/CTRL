using CTRL_Core.Backbone.Interfaces;

namespace CTRL_Core.Backbone.Database
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public string ConnectionString { get; }

        public DatabaseConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
