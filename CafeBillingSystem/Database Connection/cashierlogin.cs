using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CafeBillingSystem.Entity;

namespace CafeBillingSystem.Database_Connection
{
    public class cashierlogin
    {
        public cashierLoginEntity getCashier(string cashierId, string cashierPassword)
        {
            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("SELECT * from cashierlogin WHERE cashierid = '" + cashierId + "' and cashierpassword = '" + cashierPassword + "'");
            cashierLoginEntity user = new cashierLoginEntity();
            user = GetData(cmd);
            return user;
        }

        cashierLoginEntity GetData(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            cashierLoginEntity obj = new cashierLoginEntity();
            using (reader)
            {
                while (reader.Read())
                {

                    obj.cashierId = reader.GetString(0);
                    obj.cashierPassword = reader.GetString(1);
                    obj.cashierStatus = reader.GetString(2);
                }

                reader.Close();
            }
            cmd.Connection.Close();
            return obj;
        }


        public void Update_Password(string cashierId, string cashierPassword)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("UPDATE cashierlogin SET cashierpassword=@password  WHERE cashierid=@user_id");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@password", cashierPassword);
            cmd.Parameters.AddWithValue("@user_id", cashierId);
            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();


        }

        public void InsertUser(cashierLoginEntity user)
        {
                DatabaseConnection da = new DatabaseConnection();
                SqlCommand cmd = da.GetCommand("INSERT INTO cashierlogin VALUES(@cashierid,@cashierpassword,@cashierstatus)");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cashierid", user.cashierId);
                cmd.Parameters.AddWithValue("@cashierpassword", user.cashierPassword);
                cmd.Parameters.AddWithValue("@cashierstatus", user.cashierStatus);

                cmd.Connection.Open();


                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
        }

        public void DeleteCashierLogin(string cashierId)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("UPDATE cashierLogin SET cashierstatus=@status  WHERE cashierid=@user_id");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@status", "inactive");
            cmd.Parameters.AddWithValue("@user_id", cashierId);
            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();


        }
    }
}

