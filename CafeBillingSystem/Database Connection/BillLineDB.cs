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
    public class BillLineDB
    {
        public void InsertBillLine(BillLineEntity user)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("INSERT INTO billline VALUES(@billlineid,@billid, @itemid, @amount)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@billlineid", user.billLineId);
            cmd.Parameters.AddWithValue("@billid", user.billId);
            cmd.Parameters.AddWithValue("@itemid", user.itemId);
            cmd.Parameters.AddWithValue("@amount", user.amount);

            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();



        }

        public List<BillLineEntity> GetData2(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<BillLineEntity> list = new List<BillLineEntity>();
            using (reader)
            {
                while (reader.Read())
                {
                    BillLineEntity obj = new BillLineEntity();
                    obj.billLineId = reader.GetString(0);
                    obj.billId = reader.GetString(1);
                    obj.itemId = reader.GetString(2);
                    obj.amount = reader.GetString(3);

                    list.Add(obj);
                }
                reader.Close();
            }
            cmd.Connection.Close();
            return list;
        }

        public List<BillLineEntity> GetBillLineList(string billId)
        {
            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("SELECT * from billline where billid=@billid");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@billid", billId);
            List<BillLineEntity> empList = GetData2(cmd);
            return empList;
        }
    }
}
