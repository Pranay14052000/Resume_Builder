using OnlineResumeBuilder.DataAcess;
using OnlineResumeBuilder.Models;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OnlineResumeBuilder.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard/Home

        /// <summary>
        /// displays home view 
        /// Logs exception if found
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            try
            {
                return View();
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");

            }
            
        }

        /// <summary>
        /// displays AboutUs view 
        /// Logs exception if found
        /// </summary>
        /// <returns></returns>

        //GET: Dashboard/AboutUs
        public ActionResult AboutUs()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }



        /// <summary>
        /// displays ContactUs view 
        /// Logs exception if found
        /// </summary>
        /// <returns></returns>
        //GET: Dashboard/ContactUs
        [HttpGet]
        public ActionResult ContactUs()
        {
            try
            {

                return View();
            }
            catch( Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        /// <summary>
        /// If model is valid than calls method to insert form data in db
        /// Logs exception if found
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ContactUs(Contacts contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactsDataAccess obj = new ContactsDataAccess();
                    string result = obj.Insert(contact);
                    TempData["result1"] = result;
                    ModelState.Clear();
                    return View();

                }
                else
                {
                    ModelState.AddModelError("", "Error in submitting");
                    return View();
                }
            }
            catch(Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }

        }
        /// <summary>
        /// Gets the person id from session and passes to view
        /// Logs Exception if found
        /// </summary>
        /// <returns>View</returns>
       
        // GET 
        public ActionResult Resume()
        {
            try
            {
                int personId = (int)Session["personId"];
                // PersonResume personResume=new PersonResume();
                var personResume = performResumeOperations(personId);
                return View("~/Views/Dashboard/Resume.cshtml", personResume);
            }
            catch(Exception e)
            {
                LogException (e);
                return View("~/Views/Shared/Error.cshtml");
            }
        }
             
          /// <summary>
          /// Displays FileDownload view 
          /// Logs Exception if found
          /// </summary>
          /// <returns>View</returns>
        [HttpGet]
        public ActionResult FileDownload()
        {
            try
            {
               
                return View("~/Views/Dashboard/FileDownload.cshtml");

            }
            catch (Exception e)
            {
                LogException(e);
                return View("~/Views/Shared/Error.cshtml");
            }

        }


        /// <summary>
        /// calls resume operations method and GenerateResumePDF method
        /// Logs Exception if found
        /// </summary>
        /// <param name="personResume"></param>
        /// <returns>View/Pdf content</returns>

        [HttpPost]
        public ActionResult FileDownload(PersonResume personResume)
        {
            try
            {
                // Retrieve the personId 
                var personId = (int)Session["PersonID"];

                // Fetch the necessary data using the personId
                var resume = performResumeOperations(personId);

                string pdfFilePath = GenerateResumePDF(resume);

                MessageBox.Show("Save and dwonload successful");
                // Return the PDF file path as the response

                return Content(pdfFilePath);
                //   string filePath = Path.Combine(Server.MapPath("~/Resume/"), relativeFilePath);

                // return View("~/Views/Dashboard/FileDownload.cshtml");
            }
            catch(Exception e )
            {
                LogException(e );
                return View("~/Views/Shared/Error.cshtml");
            }

        }

        // Generate the resume PDF and return the file path

        //works...but image problem
        /*  private string GenerateResumePDF(PersonResume personResume)
          {
              // Create the PDF converter
              HtmlToPdf converter = new HtmlToPdf();

              // Set converter options
              converter.Options.MarginTop = 10;
              converter.Options.MarginBottom = 10;
              converter.Options.PdfPageSize = PdfPageSize.A7;
              converter.Options.MarginBottom = 10;
              // Set a larger width if needed
              // 0 means the height is automatically calculated

              // Generate the HTML content for the resume
              string htmlContent = RenderViewToString("~/Views/Dashboard/Resume.cshtml", personResume);

              // Convert HTML to PDF
              PdfDocument pdf = converter.ConvertHtmlString(htmlContent);

              // pdf file path
              string relativeFilePath = Session["PersonID"] + "resume.pdf";
              // Set the file path for saving the PDF
              string pdfFilePath = Path.Combine(Server.MapPath("~/Resume/"), relativeFilePath);

              // Save the PDF document
              pdf.Save(pdfFilePath);

              int userID = (int)Session["UserID"];
              int personID =(int) Session["PersonID"];

              // Close the PDF document
              pdf.Close();

              UsersDataAccess usersDataAccessObj=new UsersDataAccess();
              usersDataAccessObj.InsertResume(relativeFilePath,userID,personID);
              // Return the file path of the generated PDF
              return pdfFilePath;

          }*/


        /// <summary>
        /// function converts Html content to pdf and saves pdf returns pdf filepath
        /// </summary>
        /// <param name="personResume"></param>
        /// <returns> file path in string format</returns>
        private string GenerateResumePDF(PersonResume personResume)
        {
            
                // Create the PDF converter
                HtmlToPdf converter = new HtmlToPdf();

                // Set converter options
                converter.Options.MarginTop = 10;
                converter.Options.MarginBottom = 10;
                converter.Options.PdfPageSize = PdfPageSize.A7;

                // Generate the HTML content for the resume
                string htmlContent = RenderViewToString("~/Views/Dashboard/Resume.cshtml", personResume);

                // Convert HTML to PDF
                PdfDocument pdf = converter.ConvertHtmlString(htmlContent);

                // pdf file path
                string relativeFilePath = Session["PersonID"] + "resume.pdf";
                // Set the file path for saving the PDF
                string pdfFilePath = Path.Combine(Server.MapPath("~/Resume/"), relativeFilePath);

                // Save the PDF document
                pdf.Save(pdfFilePath);

            //
            string filePath = Path.Combine(Server.MapPath("~/Resume/"), relativeFilePath);

            //
            int userID = (int)Session["UserID"];
                int personID = (int)Session["PersonID"];

                // Close the PDF document
                pdf.Close();

                UsersDataAccess usersDataAccessObj = new UsersDataAccess();
                usersDataAccessObj.InsertResume(relativeFilePath, userID, personID);

                // Return the file path of the generated PDF
                return pdfFilePath;
            
    
        }

        private void SavePDFToDatabase(string pdfFilePath)
        {
            byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfFilePath);

            // Save the PDF bytes to the database (implement your logic here)
            // Example: YourDatabaseContext.SavePDF(pdfBytes);
        }
        // Render a view to a string


        /// <summary>
        /// Renders view to string
        /// </summary>
        /// <param name="viewPath"></param>
        /// <param name="model"></param>
        /// <returns>Content of view in string format</returns>
        /// <exception cref="FileNotFoundException"></exception>
        private string RenderViewToString(string viewPath, object model)
        {
            ViewEngineResult viewEngineResult = ViewEngines.Engines.FindView(ControllerContext, viewPath, null);
            if (viewEngineResult.View != null)
            {
                using (StringWriter sw = new StringWriter())
                {
                    ViewContext viewContext = new ViewContext(ControllerContext, viewEngineResult.View, new ViewDataDictionary(model), new TempDataDictionary(), sw);
                    viewEngineResult.View.Render(viewContext, sw);
                    return sw.GetStringBuilder().ToString();
                }
            }
            else
            {
                throw new FileNotFoundException("View cannot be found.");
            }
        }


        /// <summary>
        /// fetches the data required to create resume from database
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public static  PersonResume performResumeOperations(int personId)
        {
           
            UsersDataAccess usersDataAccess = new UsersDataAccess();
            PersonResume personResume = new PersonResume();
            personResume.MyExperiences= new MyExperiences();
            personResume.MyEducations= new MyEducations();
            personResume.Accomplishments= new Accomplishments();


            personResume.PersonalDetails = usersDataAccess.getPersonalDetails(personId);
            personResume.MyExperiences.Experience=usersDataAccess.getExperienceDetails(personId);
            personResume.MyExperiences.ExperienceSecond=usersDataAccess.getExperienceSecondDetails(personId);
            personResume.MyEducations.Education=usersDataAccess.getEducationDetails(personId);
            personResume.MyEducations.EducationSecond=usersDataAccess.getEducationSecondDetails(personId);
            personResume.Accomplishments.Skill=usersDataAccess.getSkillDetails(personId);
            personResume.Accomplishments.Projects=usersDataAccess.getProjectsDetails(personId);
            personResume.Accomplishments.Internship=usersDataAccess.getInternshipDetails(personId);
            personResume.Accomplishments.Certification=usersDataAccess.getCertificationDetails(personId);
            //  var myExperiences = Session["MyExperiences"] as MyExperiences;

            return personResume;
        }
    
        /// <summary>
        /// Logs Exception to log file
        /// </summary>
        /// <param name="e"></param>
        private void LogException(Exception e)
        {
            string logPath = Server.MapPath("~/DashboardControllerLogs.txt");

            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + e.ToString());
            }
        }


        [HttpPost]
        public ActionResult ClearSession()
        {
            Session.Clear();
            return Json(new { success = true });
        }



    }
}
