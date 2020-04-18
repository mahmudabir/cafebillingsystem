using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CafeBillingSystem
{
    public class DatabaseConnection
    {
        const string ConnectiosnString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=cafedb; User ID=;Password=";
        public SqlCommand GetCommand(String query)
        {
            var connection = new SqlConnection(ConnectiosnString);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }
    }
}