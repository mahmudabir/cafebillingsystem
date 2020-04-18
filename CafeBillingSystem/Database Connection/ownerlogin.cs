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
    public class ownerlogin
    {
        public ownerLoginEntity getOwner(string ownerId, string ownerPassword)
        {
            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("SELECT * from ownerlogin WHERE ownerid = '" + ownerId + "' and ownerpassword = '" + ownerPassword + "'");
            ownerLoginEntity user = new ownerLoginEntity();
            user = GetData(cmd);
            return user;
        }

        ownerLoginEntity GetData(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            ownerLoginEntity obj = new ownerLoginEntity();
            using (reader)
            {
                while (reader.Read())
                {

                    obj.ownerId = reader.GetString(0);
                    obj.ownerPassword = reader.GetString(1);
                    obj.ownerStatus = reader.GetString(2);
                }

                reader.Close();
            }
            cmd.Connection.Close();
            return obj;
        }


        public void Update_Password(string ownerId, string ownerPassword)
        {

            DatabaseConnection da = new DatabaseConnection();
            SqlCommand cmd = da.GetCommand("UPDATE ownerlogin SET ownerpassword=@password  WHERE ownerid=@user_id");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@password", ownerPassword);
            cmd.Parameters.AddWithValue("@user_id", ownerId);
            cmd.Connection.Open();


            cmd.ExecuteNonQuery();
            cmd.Connection.Close();


        }
    }
}
