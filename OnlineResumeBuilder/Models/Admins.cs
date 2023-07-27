using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Admins
    { 


        [Key]
        public int AdminID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateFirstName]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateLastName]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birth Date is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateBirthDate]
        [DisplayFormat(DataFormatString = "0:dd MM YYYY", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateAge]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateGender]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidatePhoneNumber]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateEmail]
        public string Email { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateAddress]
        public string Address { get; set; }



        [Required(ErrorMessage = "Country is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateCountry]
        public string Country { get; set; }

        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateState]
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateCity]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateCity]

        [Required(ErrorMessage = "UserName is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateUserName]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidatePassword]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm password required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateConfirmPassword]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Registration Access field required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string RegistrationAccess { get; set; }

    }

    public enum RegistrationAccess
    {
        True,
        False,
    }
}