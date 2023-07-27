using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class PersonalDetails
    {
        public int PersonID { get; set; }
        //  public string profilePhoto { get; set; }


     
        public string ProfilePhoto { get; set; }
        public HttpPostedFileBase ProfileFile { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateFirstName]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateLastName]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Profession is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Profession { get; set; }



        [Required(ErrorMessage = "ProfessionalDescription is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string ProfessionalDescription { get; set; }


        [Required(ErrorMessage = "City is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string City { get; set; }


        [Required(ErrorMessage = "State is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string State { get; set; }


        [Required(ErrorMessage = "Country is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Country { get; set; }
        // public string Pincode  { get; set; }


        [Required(ErrorMessage = "PhoneNumber is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidatePhoneNumber]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateEmail]
        public string Email { get; set; }

        //intialise to avoid null pointer exception in view

        //   public string Languages { get; set; }
        [Required(ErrorMessage = "Languages  required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public  string Languages { get; set; }
        public int UserID { get; set; }



        //function for assigning languages fetch from database , separated to list


    }
}