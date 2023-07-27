using OnlineResumeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace OnlineResumeBuilder.DataAcess
{
    public class AdminsDataAccess
    {
        /// <summary>
        /// Registers user in database using sp
        /// </summary>
        /// <param name="admin"></param>
        /// <returns> result in string format</returns>
        public string RegisterAdmin(Admins admin)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Admins_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AdminID", 1);
                cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", admin.BirthDate);
                cmd.Parameters.AddWithValue("@Age", admin.Age);
                cmd.Parameters.AddWithValue("@Gender", admin.Gender);
                cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@Address", admin.Address);
                cmd.Parameters.AddWithValue("@Country", admin.Country);
                cmd.Parameters.AddWithValue("@State", admin.State);
                cmd.Parameters.AddWithValue("@City", admin.City);
                cmd.Parameters.AddWithValue("@UserName", admin.UserName);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                cmd.Parameters.AddWithValue("@RegistrationAccess", admin.RegistrationAccess);
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                con.Open();
                cmd.ExecuteScalar();
                result = "rows affected " + cmd.Parameters[0].Value;
                MessageBox.Show("Registered Successfully...");
                return result;

            }        
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Gets the data of resumes for particular user id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns> returns resume data in list format</returns>
        public List<Resume> GetResumesForUser(int userID)
        {
            List<Resume> resumes = new List<Resume>();
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_User_Resumes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Resume resume = new Resume();
                    resume.ResumeID = Convert.ToInt32(reader["ResumeID"]);
                    resume.FilePath = reader["FilePath"].ToString();
                    resume.PersonID = Convert.ToInt32(reader["PersonID"]);
                    resume.ResumePersonPhoto = reader["ResumePersonPhoto"].ToString();
                    resumes.Add(resume);
                }

                return resumes;
            }
         
            finally
            {
                con.Close();
            }

        }

        /// <summary>
        /// Takes the userName as parameter calls sp and gets the result where user has access or not
        /// </summary>
        /// <param name="userName"></param>
        /// <returns> True/False in string format</returns>
        public string RegistrationAccess(string userName)
        {

            SqlConnection con = null;

            string result = "";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Registration_Access_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", userName);
                da.SelectCommand = cmd;

                con.Open();

                da.Fill(dt);
                //  MessageBox.Show(dt.Rows[0][0].ToString());
                result = dt.Rows[0][0].ToString();
              
            return result;

            }

            finally
            {
                con.Close();
            }

        }

        public string UpdateUsersPhoneNumber(Users user)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPU_Users_PhoneNumber", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                con.Open();
                cmd.ExecuteScalar();
                result = "Success";
                return result;

            }

            finally
            {
                con.Close();
            }
        }



    }
}