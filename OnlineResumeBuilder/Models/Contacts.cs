using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Contacts
    {
        [Key]
       public int ContactID { get; set; }

        [Required (ErrorMessage ="First name is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateFirstName]
        public string FirstName { get; set;}


        [Required (ErrorMessage ="Last name is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateLastName(ErrorMessage ="Invalid Last name")]
        public string LastName { get; set;}
    

        [Required (ErrorMessage ="Email is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateEmail(ErrorMessage ="Invalid email")]
        public string Email { get; set; }

        [Required (ErrorMessage ="Phone number is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidatePhoneNumber(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set;}

        [Required (ErrorMessage ="Message is required")]
        public string Message { get; set;}  

    }

    public enum Gender
    {
        Male,
        Female,
        Others

    }
}
