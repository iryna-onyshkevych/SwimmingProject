using System.Data.SqlClient;

namespace Swimming.ADO.DAL.Repositories.Connection
{
    public interface IConnection
    {
        public SqlConnection CreateSqlConnection();
    }
}
