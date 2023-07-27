using OnlineResumeBuilder.DataAcess;
using OnlineResumeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.Process.WebApi.Models;

namespace OnlineResumeBuilder.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        ///AdminRegistration Get method renders the view and if exception occurs log that exception
        /// </summary>
        /// <returns>Admin registraton view</returns>
        [HttpGet]
        public ActionResult AdminRegistration()
        {
            try
            {
                return View("~/Views/Admin/AdminRegistration.cshtml");
            }
            catch (Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// if user with entered username if doesn't exists then Registers the user also gives error message
       /// Logs the exception if found
        /// </summary>
        /// <param name="admin"></param>
        /// <returns> views</returns>

        [HttpPost]
        public ActionResult AdminRegistration(Admins admin)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    AdminsDataAccess obj = new AdminsDataAccess();
                    UsersDataAccess usersDataAccess = new UsersDataAccess();
                    int result = usersDataAccess.CheckUserExists(admin.UserName);
                    //  TempData["result1"] = result;
        
                    if (result == 0)
                    {
                        admin.Password = HashPaasword(admin.Password);

                        ModelState.Clear();

                        string insertUserResult = obj.RegisterAdmin(admin);
                        // MessageBox.Show(insertUserResult);

                        return View("~/Views/Admin/AdminRegistration.cshtml");

                    }
                    else if (result != 0)
                    {
                        MessageBox.Show("User name exists");

                        return View("~/Views/Admin/AdminRegistration.cshtml");
                    }
                    return View("~/Views/Admin/AdminRegistration.cshtml");

                }
                else
                {
                    MessageBox.Show("Error in SignUp");
                    return View("~/Views/Admin/AdminRegistration.cshtml");
                }
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }

        }


        /// <summary>
        /// Creates a list and gets the contacts/messages sent by web users and list them
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Contacts()
        {
            try
            {

                List<Contacts> contacts = new List<Contacts>();
                UsersDataAccess dataAccess = new UsersDataAccess();
                contacts = dataAccess.GetContacts();
                return View("~/Views/Admin/Contacts.cshtml", contacts);
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        /// <summary>
        /// Creates a list of users  and displays a view where admin can delete user and see user related data
       ///  Logs exception
        /// </summary>
        /// <returns> View</returns>
        [HttpGet]
        public ActionResult UserInformation()
        {
            try
            {
                List<Users> users = new List<Users>();
                UsersDataAccess dataAccess = new UsersDataAccess();
                users = dataAccess.GetUsers();
                return View("~/Views/Admin/UserInformation.cshtml", users);
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        /// <summary>
        /// Deletes the user based on userID and logs exception if found
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Json Object</returns>
        public ActionResult DeleteUser(int userID)
        {
            try
            {

                UsersDataAccess dataAccess = new UsersDataAccess();
                bool result = dataAccess.DeleteUser(userID);
                if (result)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception e)
            {
                LogException (e);
                return View("~/Views/Shared/Error.cshtml");
            }

          
        }

        /// <summary>
        /// gets the  resumes saved by user based on userId and list them  where admin can download them 
        /// Logs exception if found
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>View</returns>
        public ActionResult UserData(int userID)
        {
            try
            {
                List<Resume> resume = new List<Resume>();
                AdminsDataAccess dataAccess = new AdminsDataAccess();
                resume = dataAccess.GetResumesForUser(userID);
                return View("~/Views/Admin/UserData.cshtml", resume);
            }
            catch (Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }


        }

        /// <summary>
        /// Downloads the resume of user and logs the exception if found
        /// </summary>
        /// <param name="resumeID"></param>
        /// <returns> File if successful else view</returns>
     
        [HttpGet]
        public ActionResult DownloadResume(int resumeID)
        {
            try
            {
                UsersDataAccess userDataAccess = new UsersDataAccess();
                // Fetch the file path for the given resume ID
                string relativeFilePath = userDataAccess.GetResumeFilePath(resumeID);
                string filePath = Path.Combine(Server.MapPath("~/Resume/"), relativeFilePath);

                // Check if the file exists
                if (System.IO.File.Exists(filePath))
                {
                    // Return the file for download
                    return File(filePath, "application/pdf", resumeID + "resume.pdf");
                }

                // If the file doesn't exist, return an error message or redirect to an error page
                return Content("Resume not found.");
            }
        catch(Exception e)
            {
                LogException (e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        /// <summary>
        /// Static method used to hash the  password 
        /// </summary>
        /// <param name="password"></param>
        /// <returns>hashed password</returns>
        private static string HashPaasword(string password)
        {
            string hash = String.Empty;
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;

        }

        /// <summary>
        /// Logs the exception to file
        /// </summary>
        /// <param name="e"></param>
        private  void LogException(Exception e)
        {
            string logPath = Server.MapPath("~/AdminControllerLogs.txt");

            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + e.ToString());
            }
        }

        public ActionResult EditNumber(int userId, string phoneNumber)
        {


            if ( phoneNumber != "")
            {
                Users users = new Users();
                users.PhoneNumber = phoneNumber;
                users.UserID = userId;
                AdminsDataAccess dataAccess = new AdminsDataAccess();
                string result = dataAccess.UpdateUsersPhoneNumber(users);
                if (result == "Success")
                {
                    return Json(new { success = true });

                }
                else
                {
                    // Return an error response
                    return Json(new { success = false });
                }


            }
            // Retrieve the user from the database using the userId
            else
            {

                return Json(new { success = false });
            }
        }
    }
}