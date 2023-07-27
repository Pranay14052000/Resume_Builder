using OnlineResumeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Globalization;

namespace OnlineResumeBuilder.DataAcess
{
    public class UsersDataAccess
    {/// <summary>
    /// inserts the new  user in database 
    /// </summary>
    /// <param name="user"></param>
    /// <returns>result in string format</returns>
        public string Insert(Users user)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Users_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", 1);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", user.BirthDate);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Country", user.Country);
                cmd.Parameters.AddWithValue("@State", user.State);
                cmd.Parameters.AddWithValue("@City", user.City);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
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


        //get userID
        /// <summary>
        /// calls the sp which takes username as parameter and returns corresponding userId
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>returns result in string format</returns>
        public string GetUserID(String userName)
        {

            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
               // string querry = "Select UserID from Users where UserName=" + userName;
                SqlCommand cmd = new SqlCommand("SPG_UserID", con);
              // SqlCommand cmd =new SqlCommand(querry, con);
                   cmd.CommandType = CommandType.StoredProcedure;
               // cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@UserName", userName);
     
                con.Open();

                result = cmd.ExecuteScalar().ToString();
              
                return result;

            }
      
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// Calls the sp to insert personal details in table
        /// </summary>
        /// <param name="personalDetail"></param>
        /// <returns>personId in string format</returns>
        public string InsertPersonalDetails(PersonalDetails personalDetail)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Personal_Details_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PersonID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@ProfilePhoto", personalDetail.ProfilePhoto);
                cmd.Parameters.AddWithValue("@FirstName", personalDetail.FirstName);
                cmd.Parameters.AddWithValue("@LastName", personalDetail.LastName);
                cmd.Parameters.AddWithValue("@Profession", personalDetail.Profession);
                cmd.Parameters.AddWithValue("@ProfessionalDescription", personalDetail.ProfessionalDescription);
                cmd.Parameters.AddWithValue("@City", personalDetail.City);
                cmd.Parameters.AddWithValue("@State", personalDetail.State);
                cmd.Parameters.AddWithValue("@Country", personalDetail.Country);
                cmd.Parameters.AddWithValue("@PhoneNumber", personalDetail.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", personalDetail.Email);
                string languages = string.Join(",", personalDetail.Languages);
                cmd.Parameters.AddWithValue("@Languages", languages);
                cmd.Parameters.AddWithValue("@UserID", personalDetail.UserID);
                cmd.Parameters.AddWithValue("@Type", "INSERT");

                con.Open();
                cmd.ExecuteNonQuery();

                int personID = (int)cmd.Parameters["@PersonID"].Value;
                
               // result = "Inserted row with PersonID: " + personID;
               // MessageBox.Show(result);
               result=personID.ToString();
                return result;
            }
  
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Insert the experience of person in Experience table
        /// </summary>
        /// <param name="myExperience"></param>
        /// <returns>result message in string format</returns>
        public string InsertExperience(MyExperiences myExperience)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Experience_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ExperienceID",1);
                cmd.Parameters.AddWithValue("@JobTitle",myExperience.Experience.JobTitle);
                cmd.Parameters.AddWithValue("@Company", myExperience.Experience.Company);
                cmd.Parameters.AddWithValue("@City", myExperience.Experience.City);
                cmd.Parameters.AddWithValue("@Country",myExperience.Experience.Country);
                cmd.Parameters.AddWithValue("@StartDate",myExperience.Experience.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", myExperience.Experience.EndDate);

               
                cmd.Parameters.AddWithValue("@Description", myExperience.Experience.Description);
            
                cmd.Parameters.AddWithValue("@PersonID", myExperience.Experience.PersonID);
                cmd.Parameters.AddWithValue("@Type","INSERT");
          
                con.Open();
                cmd.ExecuteNonQuery();

                result = "Inserted Successfully";
         
                return result;
            }
      
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        ///  Insert the experience of person in  table
        /// </summary>
        /// <param name="myExperience"></param>
        /// <returns>result message in string format</returns>
        public string InsertExperienceSecond(MyExperiences myExperience)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Experience_Second_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ExperienceID",1);
                cmd.Parameters.AddWithValue("@JobTitle", myExperience.ExperienceSecond.JobTitle);
                cmd.Parameters.AddWithValue("@Company", myExperience.ExperienceSecond.Company);
                cmd.Parameters.AddWithValue("@City", myExperience.ExperienceSecond.City);
                cmd.Parameters.AddWithValue("@Country", myExperience.ExperienceSecond.Country);
                cmd.Parameters.AddWithValue("@StartDate", myExperience.ExperienceSecond.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", myExperience.ExperienceSecond.EndDate);
                cmd.Parameters.AddWithValue("@Description", myExperience.ExperienceSecond.Description);
                cmd.Parameters.AddWithValue("@PersonID", myExperience.ExperienceSecond.PersonID);
                cmd.Parameters.AddWithValue("@Type", "INSERT");

                con.Open();
                cmd.ExecuteNonQuery();

                result = "Inserted Successfully in Experience Second";
             
                return result;
            }
    
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// insert the education in coreesponding education table
        /// </summary>
        /// <param name="myEducation"></param>
        /// <returns>results in string format</returns>
        public string InsertEducation(MyEducations myEducation)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Education_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EducationID", 1);
                cmd.Parameters.AddWithValue("@InstituteName",myEducation.Education.InstituteName);
                cmd.Parameters.AddWithValue("@InstituteLocation", myEducation.Education.InstituteLocation);
                cmd.Parameters.AddWithValue("@Qualification", myEducation.Education.Qualification);
                cmd.Parameters.AddWithValue("@CompletionYear", myEducation.Education.CompletionYear);
                cmd.Parameters.AddWithValue("@PersonID",myEducation.Education.PersonID);
             
                cmd.Parameters.AddWithValue("@Type", "INSERT");

                con.Open();
                cmd.ExecuteNonQuery();

                result = "Inserted Successfully in Education";
             
                return result;
            }
   
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        ///  insert the education in coreesponding education table
        /// </summary>
        /// <param name="myEducation"></param>
        /// <returns>returns result message in string format</returns>
        public string InsertEducationSecond(MyEducations myEducation)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Education_Second_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EducationID", 1);
                cmd.Parameters.AddWithValue("@InstituteName", myEducation.Education.InstituteName);
                cmd.Parameters.AddWithValue("@InstituteLocation", myEducation.Education.InstituteLocation);
                cmd.Parameters.AddWithValue("@Qualification", myEducation.Education.Qualification);
                cmd.Parameters.AddWithValue("@CompletionYear", myEducation.Education.CompletionYear);
                cmd.Parameters.AddWithValue("@PersonID", myEducation.Education.PersonID);

                cmd.Parameters.AddWithValue("@Type", "INSERT");

                con.Open();
                cmd.ExecuteNonQuery();

                result = "Inserted Successfully in Education Second";
              
                return result;
            }
    
            finally
            {
                con.Close();
            }
        }



        /// <summary>
        /// Inserts the skills in  table using sp
        /// </summary>
        /// <param name="accomplishment"></param>
        /// <returns>returns result in string format</returns>
        public string InsertSkill(Accomplishments accomplishment)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Skill_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SID", 1);
                cmd.Parameters.AddWithValue("@Skills", accomplishment.Skill.Skills);
                cmd.Parameters.AddWithValue("@PersonID", accomplishment.Skill.PersonID);
                cmd.Parameters.AddWithValue("@Type", "INSERT");
       
                con.Open();
                cmd.ExecuteNonQuery();

                result = "Inserted Successfully in skill";
            
                return result;
            }
     
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Inserts the Projects in  table using sp
        /// </summary>
        /// <param name="accomplishment"></param>
        /// <returns>result in  string format </returns>
        public string InsertProjects(Accomplishments accomplishment)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Projects_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProjectID", 1);
                cmd.Parameters.AddWithValue("@ProjectTitle", accomplishment.Projects.ProjectTitle);
                cmd.Parameters.AddWithValue("@Description", accomplishment.Projects.Description);
   
                cmd.Parameters.AddWithValue("@PersonID", accomplishment.Projects.PersonID);
    
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                con.Open();
                cmd.ExecuteNonQuery();

                result = "Inserted Successfully in projects";
         
                return result;
            }
   
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// inserts intership data in table
        /// </summary>
        /// <param name="accomplishment"></param>
        /// <returns>returns result in string format</returns>
        public string InsertInternship(Accomplishments accomplishment)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Internship_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InternshipID", 1);
                cmd.Parameters.AddWithValue("@Title", accomplishment.Internship.Title);
                cmd.Parameters.AddWithValue("@Description", accomplishment.Internship.Description);
                cmd.Parameters.AddWithValue("@PersonID", accomplishment.Internship.PersonID);
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                con.Open();
                cmd.ExecuteNonQuery();

                result = "Inserted Successfully in internship";

                return result;
            }
   
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Insert Certification data in string format
        /// </summary>
        /// <param name="accomplishment"></param>
        /// <returns>result in string format</returns>
        public string InsertCertification(Accomplishments accomplishment)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Certification_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CertificateID", 1);
                cmd.Parameters.AddWithValue("@Title", accomplishment.Certification.Title);
                cmd.Parameters.AddWithValue("@Description", accomplishment.Certification.Description);
                cmd.Parameters.AddWithValue("@PersonID", accomplishment.Certification.PersonID);
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                con.Open();
                cmd.ExecuteNonQuery();

                result = "Inserted Successfully in Certification";
              
                return result;
            }
    
            finally
            {
                con.Close();
            }
        }
        //###################
        /// <summary>
        /// calls the sp and gets personal details based on parameter value 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> PersonalDetails type object </returns>
        public PersonalDetails getPersonalDetails(int id)
        {
            SqlConnection con = null;
            PersonalDetails personalDetails = null;
         

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Personal_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    reader.Read();


                    personalDetails = new PersonalDetails
                    {
                        ProfilePhoto = reader["ProfilePhoto"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Profession = reader["Profession"].ToString(),
                        ProfessionalDescription = reader["ProfessionalDescription"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        Country = reader["Country"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Languages = reader["Languages"].ToString()

                    };
                  

                    reader.Close();

                }
               
            }
     
           finally{
                con.Close();
            }

            return personalDetails;
        }

        //
        /// <summary>
        /// gets the experience details of respective personid 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Experience type object</returns>
        public Experience getExperienceDetails(int id)
        {
            SqlConnection con = null;
            Experience experience = null;


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Experience_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    reader.Read();


                    experience = new Experience
                    {
                        JobTitle = reader["JobTitle"].ToString(),
                        Company = reader["Company"].ToString(),
                        City = reader["City"].ToString(),
                        Country = reader["Country"].ToString(),
                        StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                         EndDate = DateTime.Parse(reader["EndDate"].ToString()),
                        Description = reader["Description"].ToString(),
                       

                    };
            

                    reader.Close();

                   
                }

            }
   
            finally
            {
                con.Close();
            }

            return experience;
        }


        /// <summary>
        ///  gets the experience details of respective personid 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ExperienceSecond type object</returns>
        public ExperienceSecond getExperienceSecondDetails(int id)
        {
            SqlConnection con = null;
            ExperienceSecond experienceSecond = null;


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Experience_Second_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                  
                    reader.Read();


                    experienceSecond = new ExperienceSecond
                    {
                        JobTitle = reader["JobTitle"].ToString(),
                        Company = reader["Company"].ToString(),
                        City = reader["City"].ToString(),
                        Country = reader["Country"].ToString(),
                        StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                        EndDate = DateTime.Parse(reader["EndDate"].ToString()),
                        Description = reader["Description"].ToString(),


                    };


                    reader.Close();

                 
                }

            }
     
            finally
            {
                con.Close();
            }

            return experienceSecond;
        }

        /// <summary>
        /// gets the Education details of respective personid 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>getEducationDetails type object</returns>
        public Education getEducationDetails(int id)
        {
            SqlConnection con = null;
            Education education = null;


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Education_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                 
                    reader.Read();


                    education = new Education
                    {
                        InstituteName = reader["InstituteName"].ToString(),
                        InstituteLocation = reader["InstituteLocation"].ToString(),
                        Qualification = reader["Qualification"].ToString(),
                        CompletionYear = reader["CompletionYear"].ToString(),
                   
                    };


                    reader.Close();

                 
                }

            }
   
            finally
            {
                con.Close();
            }

            return education;
        }


        /// <summary>
        /// gets the Education details of respective personid 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EducationSecond type object</returns>
        public EducationSecond getEducationSecondDetails(int id)
        {
            SqlConnection con = null;
            EducationSecond educationSecond = null;


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Education_Second_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                   
                    reader.Read();


                    educationSecond = new EducationSecond
                    {
                        InstituteName = reader["InstituteName"].ToString(),
                        InstituteLocation = reader["InstituteLocation"].ToString(),
                        Qualification = reader["Qualification"].ToString(),
                        CompletionYear = reader["CompletionYear"].ToString(),

                    };


                    reader.Close();

                  
                }

            }
   
            finally
            {
                con.Close();
            }

            return educationSecond;
        }

        /// <summary>
        /// gets the Projects details of respective personid 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Projects type object</returns>

        public Projects getProjectsDetails(int id)
        {
            SqlConnection con = null;
            Projects projects = null;


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Projects_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                   
                    reader.Read();


                    projects = new Projects
                    {
                        ProjectTitle = reader["ProjectTitle"].ToString(),
                        Description = reader["Description"].ToString()

                    };


                    reader.Close();

                  
                }

            }
    
            finally
            {
                con.Close();
            }

            return projects;
        }


        /// <summary>
        /// gets the Internship details of respective personid 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Internship type object</returns>

        public Internship getInternshipDetails(int id)
        {
            SqlConnection con = null;
            Internship internship = null;


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Internship_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    
                    reader.Read();


                    internship = new Internship
                    {
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString()

                    };


                    reader.Close();

                    
                }

            }
   
            finally
            {
                con.Close();
            }

            return internship;
        }


        /// <summary>
        /// gets the Certification details of respective personid
        /// </summary>
        /// <param name="id"></param>
        /// <returnsr>Certification type object</returns>
        public Certification getCertificationDetails(int id)
        {
            SqlConnection con = null;
            Certification certification = null;


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Certification_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    
                    reader.Read();


                    certification = new Certification
                    {
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString()

                    };


                    reader.Close();

                    
                }

            }
   
            finally
            {
                con.Close();
            }

            return certification;
        }


        /// <summary>
        /// insert resume related details in table using sp
        /// </summary>
        /// <param name="relativeFilePath"></param>
        /// <param name="userID"></param>
        /// <param name="personID"></param>
        /// <returns>result in string format </returns>

        public string InsertResume(string relativeFilePath,int userID,int personID)
        {
            SqlConnection con = null;

            string result = "";

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Resumes_Crud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ResumeID", 1);
                cmd.Parameters.AddWithValue("@FilePath", relativeFilePath);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@PersonID", personID);
                cmd.Parameters.AddWithValue("@Type", "Insert");
                con.Open();
                cmd.ExecuteNonQuery();

                result = "Inserted Successfully in Resumes";

                return result;
            }
    
            finally
            {
                con.Close();
            }

        }

        /// <summary>
        /// calls the sp and gets the resume for corresponding userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List of Resume type</returns>
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
        /// gets the filepath corresponding to entered resumeId
        /// </summary>
        /// <param name="resumeID"></param>
        /// <returns>file path in string format</returns>
        public string GetResumeFilePath(int resumeID)
        {
            
            SqlConnection con = null;
            string filepath = "";


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Resumes_Filepath", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResumeID", resumeID);

                con.Open();
              
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    filepath= reader["FilePath"].ToString();
 
                }

                return filepath;
            }
     
            finally
            {
                con.Close();
            }

        }


        /// <summary>
        /// Deletes the respective resume from databas based on id
        /// </summary>
        /// <param name="resumeID"></param>
        /// <returns>result in string format</returns>
       public string DeleteResumeFromDatabase(int resumeID)
        {

            SqlConnection con = null;
            string result = "";


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPD_Resume", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResumeID", resumeID);

                con.Open();

                cmd.ExecuteNonQuery();

                result = "Deleted Successfully";

                return result;

          
            }
  
            finally
            {
                con.Close();
            }

        }




        /// <summary>
        /// gets the skils details from table based on person id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Skill type object</returns>
        public Skill getSkillDetails(int id)
        {
            SqlConnection con = null;
            Skill skill = null;


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Skill_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    
                    reader.Read();


                    skill = new Skill
                    {
                        Skills = reader["Skills"].ToString(),
                  
                    };


                    reader.Close();

                    
                }

            }
     
            finally
            {
                con.Close();
            }

            return skill;
        }


        /// <summary>
        /// Checks if user Exists in database with given username as parameter
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>returns the no of users present with given name in database </returns>
        public int CheckUserExists(string userName)
        {

            SqlConnection con = null;

            int result;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Check_User_Exists", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", userName);
                da.SelectCommand = cmd;

                con.Open();

                da.Fill(dt);
                //  MessageBox.Show(dt.Rows[0][0].ToString());

                    result =(int) dt.Rows[0][0];
                return result;

            }
  
            finally
            {
                con.Close();
            }


        }



        /// <summary>
        /// checks whetther user with given username and password exists in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns> result of no of users present with given username in string format</returns>
        public string Login(Login user)
        {

            SqlConnection con = null;

            string result = "";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SP_User_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                da.SelectCommand = cmd;

                con.Open();

                da.Fill(dt);
                //  MessageBox.Show(dt.Rows[0][0].ToString());

                if (dt.Rows[0][0].ToString() == "1" && dt.Rows[0][1].ToString()=="Users")
                {

                    return result = dt.Rows[0][1].ToString();
                }
                else if(dt.Rows[1][0].ToString() == "1" && dt.Rows[1][1].ToString() == "Admin")
                {
                    return result = dt.Rows[1][1].ToString();

                } 
                else
                {
                    return result;
                }

            }
 
            finally
            {
                con.Close();
            }

        }


      


        /// <summary>
        /// calls the sp and gets the data from contacts tables
        /// </summary>
        /// <returns>List of type Contacts</returns>
        public List<Contacts> GetContacts()
        {
            List<Contacts> contacts = new List<Contacts>();
            SqlConnection con = null;



            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Contacts", con);
                cmd.CommandType = CommandType.StoredProcedure;
              
                con.Open();


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    Contacts contact = new Contacts();
                    contact.ContactID = Convert.ToInt32(reader["ContactID"]);
                    contact.FirstName = reader["FirstName"].ToString();
                    contact.LastName = reader["LastName"].ToString();
                    contact.Email = reader["Email"].ToString();
                    contact.PhoneNumber = reader["PhoneNumber"].ToString();
                    contact.Message = reader["Message"].ToString();

                    contacts.Add(contact);
                }

                return contacts;
            }
     
            finally
            {
                con.Close();
            }

        }


        /// <summary>
        /// gets the list of users registered
        /// </summary>
        /// <returns>List of Users type</returns>
        public List<Users> GetUsers()
        {

            List<Users> users = new List<Users>();
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPG_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Users user = new Users();
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Gender = reader["Gender"].ToString();
                    user.PhoneNumber = reader["PhoneNumber"].ToString();
                    user.Email = reader["Email"].ToString();

                    users.Add(user);
                }

                return users;
            }
     
            finally
            {
                con.Close();
            }

        }

        /// <summary>
        /// Deletes the user with corresponding userId
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool DeleteUser(int userID)
        {

            SqlConnection con = null;
            bool result = false;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SPD_User", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userID);

                con.Open();
                cmd.ExecuteScalar();
                result = true;
                MessageBox.Show("Deleted Successfully...");
                return result;

            }
      
            finally
            {
                con.Close();
            }
        }

    }
}