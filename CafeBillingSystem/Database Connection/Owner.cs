using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeBillingSystem.Database_Connection;
using CafeBillingSystem.Entity;
using System.Data.SqlClient;
using System.Data;

namespace CafeBillingSystem.Database_Connection
{
    public class Owner
    {
        public owner getOwner(string ownerId)
        {
            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("SELECT * from owner WHERE ownerid = '" + ownerId + "' ");
            owner user = new owner();
            user = GetData(cmd);
            return user;
        }

        owner GetData(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            owner obj = new owner();
            using (reader)
            {
                while (reader.Read())
                {

                    obj.ownerId = reader.GetString(0);
                    obj.ownerName = reader.GetString(1);
                    obj.ownerPhone = reader.GetString(2);
                    obj.ownerStatus = reader.GetString(3);

                }

                reader.Close();
            }
            cmd.Connection.Close();
            return obj;
        }

        public void Updae_Phone(string ownerId, string ownerPhone)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("UPDATE owner SET ownerphone=@phone  WHERE ownerid=@user_id");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@phone", ownerPhone);
            cmd.Parameters.AddWithValue("@user_id", ownerId);
            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }
    }
}
