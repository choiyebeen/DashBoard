using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Choiyebeen.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Server=localhost; Database=MVVMLoginDb; Integrated Security=true;";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString); //mssql
        }
        protected MySqlConnection GetMySqlConnection()
        {
            return new MySqlConnection(_connectionString); //mysql
        }
    }
}
