using OnlineResumeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace OnlineResumeBuilder.DataAcess
{
    public class ContactsDataAccess
    {
        /// <summary>
        /// Inserts the data / messages enetered by web users in db
        /// </summary>
        /// <param name="contact"></param>
        /// <returns> result in string format</returns>
        public string Insert(Contacts contact)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Contacts_Crud",con);
                cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContactID", 1);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                cmd.Parameters.AddWithValue("@Message", contact.Message);
                cmd.Parameters.AddWithValue("Type", "INSERT");
                con.Open();
               cmd.ExecuteScalar();
                // result= "rows affected "+cmd.Parameters[0].Value;
                result = "successfully submitted";
                MessageBox.Show("Submited Successfully...");
                return result;
                
            }
      
            finally
            {
                con.Close();
            }
          
        }
    }
}