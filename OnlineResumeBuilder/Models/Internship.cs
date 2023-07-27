using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Internship
    {
        [Key]
        public int InternshipID { get; set; }

        [Required(ErrorMessage = "Title  is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description  is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Description { get; set; }
        public int PersonID { get; set; }
    }
}