using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }

        [Required(ErrorMessage = "JobTitle is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string JobTitle {get;set;}

        
        [Required(ErrorMessage = "Company is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Company { get; set; }

      
        [Required(ErrorMessage = "City is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string City { get;set;}

     
        [Required(ErrorMessage = "Country is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Country { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Start Date is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateDate]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "EndDate Date is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateDate]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Description  is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Description { get; set; }

        public int PersonID { get; set; }


      //  public List<Experience> ExperienceList { get; set; } = new List<Experience>();


    }
    public class ExperienceViewModel
    {
        public List<Experience> ExperienceList { get; set; } = new List<Experience>();
    }
}