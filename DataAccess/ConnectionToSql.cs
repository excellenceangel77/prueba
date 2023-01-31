using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnectionToSql
    {
        private readonly string connectionString;
        public ConnectionToSql() {
            connectionString= "Server=DESKTOP-ICS1S0S;DataBase=Pru1;integrated security = true";
        }

        public ConnectionToSql(string connectionString)
        {
            this.connectionString= connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}