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
    public class ItemDB
    {
        public itemEntity getItem(string itemId)
        {
            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("SELECT * from item WHERE itemid = '" + itemId + "' ");
            itemEntity user = new itemEntity();
            user = GetData(cmd);
            return user;
        }

        public itemEntity GetData(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            itemEntity obj = new itemEntity();
            using (reader)
            {
                while (reader.Read())
                {

                    obj.itemId = reader.GetString(0);
                    obj.itemName = reader.GetString(1);
                    obj.itemCost = reader.GetString(2);

                }

                reader.Close();
            }
            cmd.Connection.Close();
            return obj;
        }

        public void Update_Cost(string itemId, string itemCost)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("UPDATE item SET itemcost=@cost  WHERE itemid=@user_id");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cost", itemCost);
            cmd.Parameters.AddWithValue("@user_id", itemId);
            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public List<itemEntity> GetData2(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<itemEntity> list = new List<itemEntity>();
            using (reader)
            {
                while (reader.Read())
                {
                    itemEntity obj = new itemEntity();
                    obj.itemId = reader.GetString(0);
                    obj.itemName = reader.GetString(1);
                    obj.itemCost = reader.GetString(2);
                    
                    list.Add(obj);
                }
                reader.Close();
            }
            cmd.Connection.Close();
            return list;
        }

        public List<itemEntity> GetItemList()
        {
            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("SELECT * from item");
            cmd.CommandType = CommandType.Text;
            List<itemEntity> empList = GetData2(cmd);
            return empList;
        }
    }
}
