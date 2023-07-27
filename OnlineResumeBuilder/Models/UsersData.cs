using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class UsersData
    {
        public bool UserIsPresent(string username)
        {

            SqlConnection con = null;
         
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("uspUserRegister", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username);
                da.SelectCommand = cmd;

                con.Open();

                da.Fill(dt);




                if (dt.Rows[0][0].ToString() == "0")
                {

                    return  false;
                }
                else
                {
                    return true;

                }

            }
            catch
            {

                // actual if return type was string it would have been retuned empty so here as per my logic it is // true

                return true;
            }
            finally
            {
                con.Close();
            }
        }

    }
}