using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Dal.Interfaces
{
    interface IConnection
    {
        public SqlConnection GetSqlConnection(string conString)
        {
            return new SqlConnection(conString);
        }

        public SqlConnection OpenConnection(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            return sqlConnection;
        }

        public void CloseConnection(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
    }
}
