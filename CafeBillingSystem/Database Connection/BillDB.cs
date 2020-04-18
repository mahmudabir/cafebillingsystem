using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeBillingSystem.Entity;
using System.Data.SqlClient;
using System.Data;

namespace CafeBillingSystem.Database_Connection
{
    public class BillDB
    {

        public void InsertBill(BillEntity user)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("INSERT INTO bill VALUES(@billid,@billamount)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@billid", user.billId);
            cmd.Parameters.AddWithValue("@billamount", user.billAmount);

            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();



        }


        public List<BillEntity> GetData2(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<BillEntity> list = new List<BillEntity>();
            using (reader)
            {
                while (reader.Read())
                {
                    BillEntity obj = new BillEntity();
                    obj.billId = reader.GetString(0);
                    obj.billAmount = reader.GetString(1);

                    list.Add(obj);
                }
                reader.Close();
            }
            cmd.Connection.Close();
            return list;
        }

        public List<BillEntity> GetItemList()
        {
            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("SELECT * from bill");
            cmd.CommandType = CommandType.Text;
            List<BillEntity> empList = GetData2(cmd);
            return empList;
        }
    }
}
