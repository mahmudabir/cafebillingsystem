using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeBillingSystem.Database_Connection;
using CafeBillingSystem.Entity;
using System.Data;
using System.Data.SqlClient;



namespace CafeBillingSystem.Database_Connection
{
    
    public class CashierDB
    {
        public cashier getCashier(string cashierId)
        {
            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("SELECT * from cashier WHERE cashierid = '" + cashierId + "' ");
            cashier user = new cashier();
            user = GetData(cmd);
            return user;
        }

        cashier GetData(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            cashier obj = new cashier();
            using (reader)
            {
                while (reader.Read())
                {

                    obj.cashierId = reader.GetString(0);
                    obj.cashireName = reader.GetString(1);
                    obj.cashierPhone = reader.GetString(2);
                    obj.cashierAddress = reader.GetString(3);
                    obj.cashierSalary = reader.GetString(4);
                    obj.cashierStatus = reader.GetString(5);

                }

                reader.Close();
            }
            cmd.Connection.Close();
            return obj;
        }

        public void InsertCashier(cashier user)
        {

                DatabaseConnection da = new DatabaseConnection();
                SqlCommand cmd = da.GetCommand("INSERT INTO cashier VALUES(@cashierid,@cashiername,@cashierphone,@cashieraddress,@cashiersalary,@cashierstatus)");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cashierid", user.cashierId);
                cmd.Parameters.AddWithValue("@cashiername", user.cashireName);
                cmd.Parameters.AddWithValue("@cashierphone", user.cashierPhone);
                cmd.Parameters.AddWithValue("@cashieraddress", user.cashierAddress);
                cmd.Parameters.AddWithValue("@cashiersalary", user.cashierSalary);
                cmd.Parameters.AddWithValue("@cashierstatus", user.cashierStatus);

                cmd.Connection.Open();


                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            

            
        }

        public void DeleteCashier(string cashierId)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("UPDATE cashier SET cashierstatus=@status  WHERE cashierid=@user_id");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@status","inactive");
            cmd.Parameters.AddWithValue("@user_id", cashierId);
            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();


        }

        public void UpdateCashier(string cashierId, string salary)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("UPDATE cashier SET cashiersalary=@salary  WHERE cashierid=@user_id");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@user_id", cashierId);
            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();


        }

        public void UpdateCashierSelf(string cashierId, string cashierPhone)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("UPDATE cashier SET cashierphone=@phone  WHERE cashierid=@user_id");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@phone", cashierPhone);
            cmd.Parameters.AddWithValue("@user_id", cashierId);
            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();


        }

        public List<cashier> GetData2(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<cashier> list = new List<cashier>();
            using (reader)
            {
                while (reader.Read())
                {
                    cashier obj = new cashier();
                    obj.cashierId = reader.GetString(0);
                    obj.cashireName = reader.GetString(1);
                    obj.cashierPhone = reader.GetString(2);
                    obj.cashierAddress = reader.GetString(3);
                    obj.cashierSalary = reader.GetString(4);
                    obj.cashierStatus = reader.GetString(5);

                    list.Add(obj);
                }
                reader.Close();
            }
            cmd.Connection.Close();
            return list;
        }

        public List<cashier> GetCashierList()
        {
            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("SELECT * from cashier where cashierstatus=@status");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@status", "active");
            List<cashier> empList = GetData2(cmd);
            return empList;
        }

    }
}
