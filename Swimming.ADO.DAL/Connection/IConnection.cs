using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Swimming.ADO.DAL.Repositories.Connection
{
    public interface IConnection
    {
        public SqlConnection CreateSqlConnection();
    }
}
