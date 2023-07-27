using OnlineResumeBuilder.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using OnlineResumeBuilder.Models;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OnlineResumeBuilder.Controllers
{
    public class UsersController : Controller
    {/// <summary>
    /// Clears the session and Logs the esception if found
    /// </summary>
    /// <returns> Views</returns>
        [HttpGet]

        public ActionResult Login()
        {

            try
            {
                Session.Clear();

                return View("~/Views/Users/Login.cshtml");
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        /// <summary>
        /// If user credentials are valid then user logged in else receives error message
        /// Logs the exception if found 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Views</returns>
        [HttpPost]
        public ActionResult Login(Login user)
        {
            
            try
            {

                if (ModelState.IsValid)
                {
                    user.Password = HashPaasword(user.Password);
                    UsersDataAccess obj = new UsersDataAccess();
                    string result = obj.Login(user);
                    TempData["result1"] = result;

                    if (result == "Users")
                    {
                        ModelState.Clear();

                        Session["UserName"] = user.UserName;

                        string userId = obj.GetUserID(user.UserName);
                        Session["UserID"] = int.Parse(userId);
                        return RedirectToAction("PersonalDetails", "Users");

                    }
                    else if (result == "Admin")
                    {
                        ModelState.Clear();

                        Session["UserName"] = user.UserName;
                     
                        AdminsDataAccess adminsDataAccess = new AdminsDataAccess();
                      string registrationAccess=adminsDataAccess.RegistrationAccess(user.UserName);
                        Session["RegistrationAccess"]=registrationAccess;
                        // string userId = obj.GetUserID(user.UserName);
                        //  Session["UserID"] = int.Parse(userId);
                        return RedirectToAction("UserInformation", "Admin");
                    }

                    MessageBox.Show("Error in logging in");
                    return View("~/Views/Users/Login.cshtml");

                }
                else
                {
                    MessageBox.Show("Error in logging in");
                    return View("~/Views/Users/Login.cshtml");
                }
            }
            catch (Exception e) {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }

        }

        /// <summary>
        /// returms signup view and logs exception if found
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult SignUp()
        {
            try
            {
                return View("~/Views/Users/SignUp.cshtml");
            }
            catch(Exception e) {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// Checks if username already exists if not then registers user and redirects to login page 
        /// else if username exits error message is recieved
        /// Logs exception if found
        /// </summary>
        /// <param name="user"></param>
        /// <returns>View</returns>
        //Post
        [HttpPost]
        public ActionResult SignUp(Users user)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    UsersDataAccess obj = new UsersDataAccess();
                    int result = obj.CheckUserExists(user.UserName);
                    //   TempData["result1"] = result;

                    if (result == 0)
                    {

                        ModelState.Clear();

                        user.Password = HashPaasword(user.Password);
                        // string insertUserResult = obj.Insert(user);
                        MessageBox.Show("Now Login");

                        return RedirectToAction("Login", "Users");

                    }
                    else if (result != 0)
                    {
                        MessageBox.Show("Username already exists");

                        return View("~/Views/Users/SignUp.cshtml");
                    }
                    return View("~/Views/Users/SignUp.cshtml");

                }
                else
                {
                    MessageBox.Show("Error in SignUp");
                    return View("~/Views/Users/SignUp.cshtml");
                }
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");

            }

        }


        /// <summary>
        /// gets the PersonalDetails object from session if null then creates new instance and passes to view
        /// Logs the exception if found
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public ActionResult PersonalDetails()
        {
            try
            {

                //  var personalDetails = Session["PersonalDetails"] as PersonalDetails;
                //  var model = new PersonalDetails();
                var personalDetails = Session["PersonalDetails"] as PersonalDetails;
                if (personalDetails == null)
                {
                    personalDetails = new PersonalDetails(); // Create a new instance as a fallback
                }

                return View("~/Views/Users/PersonalDetails.cshtml", personalDetails);
            }
            catch (Exception e)
            {
                LogException (e);
                return View("~/Views/Shared/Error.cshtml");

            }
        }

        /// <summary>
        /// saves the PersonalDetails object to session storage
        /// saves the profile photo file to directory
        /// //Logs the exception if found
        /// </summary>
        /// <param name="personalDetails"></param>
        /// <returns>View</returns>
        [HttpPost]
       public ActionResult PersonalDetails(PersonalDetails personalDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
               
                    HttpPostedFileBase profileFile = personalDetails.ProfileFile;

                    byte[] imageBytes;
                    using (BinaryReader reader = new BinaryReader(profileFile.InputStream))
                    {
                        imageBytes = reader.ReadBytes(profileFile.ContentLength);
                    }
                    string base64String = Convert.ToBase64String(imageBytes);


                    //previous name
                    personalDetails.ProfilePhoto = base64String;
                    Session["PersonalDetails"] = personalDetails;

                    // Return the updated personalDetails model to the view

                    return RedirectToAction("MyExperiences", "Users");

                }

                // If the model state is not valid, create a new instance of the PersonalDetails model and pass it to the view


                return View("~/Views/Users/PersonalDetails.cshtml");
            }
            catch (Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        /// <summary>
        /// gets the MyExperiences object from session if null then creates new instance and passes to view
        /// Logs the exception if found
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public ActionResult MyExperiences()
        {

            try
            {
              
                var myexperiences = Session["MyExperiences"] as MyExperiences;
                if (myexperiences == null)
                {
                    myexperiences = new MyExperiences(); // Create a new instance as a fallback
                }


                // Pass the personalDetails model to the view
                return View("~/Views/Users/MyExperiences.cshtml", myexperiences);
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }

        }

        /// <summary>
        ///  saves the myexperiences object to session storage
        /// Logs the exception if found
        /// </summary>
        /// <param name="myexperiences"></param>
        /// <returns>View</returns>

        [HttpPost]

        public ActionResult MyExperiences(MyExperiences myexperiences)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Session["MyExperiences"] = myexperiences;

                    // Return the updated personalDetails model to the view
                    return RedirectToAction("MyEducations", "Users");
                }


                return View("~/Views/Users/MyExperiences.cshtml");
            }
            catch(Exception e)
            {
                LogException (e);
                return View("~/Views/Shared/Error.cshtml");

            }
        }


        /// <summary>
        /// gets the MyEducations object from session if null then creates new instance and passes to view
        /// Logs the exception if found
        /// </summary>
        /// <returns>View</returns>

        [HttpGet]
        public ActionResult MyEducations()
        {
            try
            {
              ;
                var myeducations = Session["MyEducations"] as MyEducations;
                if (myeducations == null)
                {
                    myeducations = new MyEducations(); // Create a new instance as a fallback
                }

                return View("~/Views/Users/MyEducations.cshtml", myeducations);
            }
            catch (Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }

        }

        /// <summary>
        ///  saves the myeducations object to session storage
        /// Logs the exception if found
        /// </summary>
        /// <param name="myeducations"></param>
        /// <returns>View</returns>
        [HttpPost]

        public ActionResult MyEducations(MyEducations myeducations)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Session["MyEducations"] = myeducations;

                    // Return the updated personalDetails model to the view
                    return RedirectToAction("Accomplishments", "Users");
                }

                return View("~/Views/Users/MyEducations.cshtml");
            }
            catch( Exception e)
            {
                LogException(e) ;
                return View("~/Views/Shared/Error.cshtml");
            }
        }



        /// <summary>
        /// gets the Accomplishments object from session if null then creates new instance and passes to view
        /// Logs the exception if found
        /// </summary>
        /// <returns>View</returns>

        [HttpGet]
        public ActionResult Accomplishments()
        {
            try
            {
        
                var accomplishment = Session["Accomplishments"] as Accomplishments;
                if (accomplishment == null)
                {
                    accomplishment = new Accomplishments();
                }

                return View("~/Views/Users/Accomplishments.cshtml", accomplishment);
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }

        }

        /// <summary>
        /// recieves the objects from session storage and insert and calls the functions to save them to db
        /// if any state is invalid displays error message
        /// saves person id to session storage
        /// send the personresume model obj to resume view
        /// Logs exception if found
        /// Redirects to FileDownload view
        /// </summary>
        /// <param name="accomplishment"></param>
        /// <returns> View</returns>
        [HttpPost]

        public ActionResult Accomplishments(Accomplishments accomplishment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var personalDetails = Session["PersonalDetails"] as PersonalDetails;
                    var myExperiences = Session["MyExperiences"] as MyExperiences;
                    var myEducations = Session["MyEducations"] as MyEducations;
                    if (personalDetails != null && myExperiences != null && myEducations != null)
                    {

                        Session["Accomplishments"] = accomplishment;

                        string userName = Session["UserName"] as string;


                        //  string userId= usersDataAccess.GetUserID(userName);
                        // Session["UserID"]= int.Parse(userId);
                        int userId = (int)Session["UserID"];

                        personalDetails.UserID = userId;
                        Session["PersonalDetails"] = personalDetails;

                        //RECEIVED PERSON ID OF LATEST ENTRY
                        UsersDataAccess usersDataAccess = new UsersDataAccess();
                        string personId = usersDataAccess.InsertPersonalDetails(personalDetails);
                        Session["personId"] = int.Parse(personId);
                        //

                        myExperiences.Experience.PersonID = int.Parse(personId);
                        myExperiences.ExperienceSecond.PersonID = int.Parse(personId);


                        string result1 = usersDataAccess.InsertExperience(myExperiences);
                        string result2 = usersDataAccess.InsertExperienceSecond(myExperiences);
                        //string result2= usersDataAccess.



                        myEducations.Education.PersonID = int.Parse(personId);
                        myEducations.EducationSecond.PersonID = int.Parse(personId);

                        result1 = usersDataAccess.InsertEducation(myEducations);
                        result2 = usersDataAccess.InsertEducationSecond(myEducations);


                        var acccomplishments = Session["Accomplishments"] as Accomplishments;
                        accomplishment.Skill.PersonID = int.Parse(personId);
                        accomplishment.Projects.PersonID = int.Parse(personId);
                        accomplishment.Internship.PersonID = int.Parse(personId);
                        accomplishment.Certification.PersonID = int.Parse(personId);

                        result1 = usersDataAccess.InsertSkill(acccomplishments);
                        result2 = usersDataAccess.InsertProjects(accomplishment);
                        string result3 = usersDataAccess.InsertInternship(accomplishment);
                        string result4 = usersDataAccess.InsertCertification(accomplishment);


                        //SINCE CONTROLLER ARE SEPARATED..


                        var personResume = DashboardController.performResumeOperations(int.Parse(personId));

                        Session["PersonID"] = int.Parse(personId);
                        // Return the updated personalDetails model to the view
                        ///////  change done to set resume template temporary change
                        View("Resume", personResume);
                        // return RedirectToAction("Resume","Dashboard");
                        return RedirectToAction("FileDownload", "Dashboard");
                    }
                    else if (personalDetails == null || myExperiences == null || myEducations != null)
                    {

                        if (personalDetails == null)
                        {
                            MessageBox.Show("PersonalDetails model state is invalid");
                        }
                        else if (myExperiences == null)
                        {
                            MessageBox.Show("Experience model state is invalid");
                        }
                        else if (myEducations == null)
                        {
                            MessageBox.Show("Educations model state is invalid");
                        }
                        return View("~/Views/Users/Accomplishments.cshtml");

                    }

                    /////////////
                }
                return View("~/Views/Users/Accomplishments.cshtml");
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");

            }

        }


        /// <summary>
        /// gets the UserId from session storage
        /// Gets the List of resume saved for that userId
        /// Logs the exception if found
        /// </summary>
        /// <returns> Views</returns>
        //moved from dashboard controller to users//
        [HttpGet]
        public ActionResult MyResumes()
        {
            try
            {
                UsersDataAccess usersDataAccess = new UsersDataAccess();

                // Return the updated personalDetails model to the view
                int userID = (int)Session["UserID"];

                // Fetch the resumes for the current user from the database
                List<Resume> resumes = usersDataAccess.GetResumesForUser(userID);

                // Pass the resumes to the view
                return View("~/Views/Users/MyResumes.cshtml", resumes);

            }
            catch (Exception e)
            {
                LogException (e);
                return View("~/Views/Shared/Error.cshtml");
            }

        }

        /// <summary>
        /// if resume file exists then returns the file for download else return message 
        /// Logs the exception if found
        /// </summary>
        /// <returns>File/View</returns>

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
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }


        /// <summary>
        /// Deletes the resume based on resume id if resume not found returns error  message 
        /// Logs the exception if found
        /// </summary>
        /// <returns>View/Message</returns>
        [HttpGet]
        public ActionResult DeleteResume(int resumeID)
        {
            try
            {

                // Fetch the file path for the given resume ID
                UsersDataAccess userDataAccess = new UsersDataAccess();
                // Fetch the file path for the given resume ID
                string relativeFilePath = userDataAccess.GetResumeFilePath(resumeID);
                string filePath = Path.Combine(Server.MapPath("~/Resume/"), relativeFilePath);


                // Check if the file exists
                if (System.IO.File.Exists(filePath))
                {
                    // Delete the file from the server
                    System.IO.File.Delete(filePath);

                    // Delete the resume record from the database
                    userDataAccess.DeleteResumeFromDatabase(resumeID);

                    // Redirect back to the MyResumes page
                    return RedirectToAction("MyResumes");
                }
                else if (relativeFilePath != "")
                {
                    // Delete the resume record from the database
                    userDataAccess.DeleteResumeFromDatabase(resumeID);

                    // Redirect back to the MyResumes page
                    return RedirectToAction("MyResumes");
                }

                // If the file doesn't exist, return an error message or redirect to an error page
                return Content("Resume not found.");
            }
            catch (Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// Takes exception as parameter and logs it to file
        /// </summary>
        /// <param name="e"></param>

        private void LogException(Exception e)
        {
            string logPath = Server.MapPath("~/UsersControllerLogs.txt");

            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + e.ToString());
            }
        }


        /// <summary>
        /// hashes the password entered
        /// </summary>
        /// <param name="password"></param>
        /// <returns>hashed password string</returns>
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




    }
}