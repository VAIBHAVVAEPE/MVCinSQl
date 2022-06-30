using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MVCinSQl.Models
{
    public class UserDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UserDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public int Save(User u)
        {
            string q = "insert into UserTable values(@FullName,@EmailId,@Password,@RoleId)";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@FullName", u.FullName);
            cmd.Parameters.AddWithValue("@EmailId", u.EmailId);
            cmd.Parameters.AddWithValue("@Password", u.Password);
            cmd.Parameters.AddWithValue("@RoleId", 2);
           

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public bool Verify(User u)
        {
            string email;
            string pass;
            string q = "Select EmailId,Password from UserTable where EmailId=@EmailId";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@EmailId", u.EmailId);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                email = dr["EmailId"].ToString();
                pass = dr["Password"].ToString();
            }
            else
            {
                con.Close();
                return false;
            }
            if (email == u.EmailId && pass == u.Password)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

    }
}
