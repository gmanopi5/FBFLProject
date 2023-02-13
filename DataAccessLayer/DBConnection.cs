using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    internal class DBConnection : IDBConnection
    {
        public SqlConnection GetDBConnection()
        {
            SqlConnection conn = null;

            string connectionString =
                @"Data Source=localhost;Initial Catalog=FBFL_db;Integrated Security=True";
            conn = new SqlConnection(connectionString);

            return conn;
        }
    }
}
