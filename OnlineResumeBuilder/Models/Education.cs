using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Education
    {//PK
        [Key]
        public int EducationID { get; set; }

        [Required(ErrorMessage = "InstituteName is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string InstituteName { get; set; }

        [Required(ErrorMessage = "InstituteLocation is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string InstituteLocation { get; set; }

        [Required(ErrorMessage = "Qualification is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "CompletionYear is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string CompletionYear { get; set; }

        //FK
        public int PersonID { get; set; }


        public List<Education> EducationList { get; set; }=new List<Education>();
    }
}