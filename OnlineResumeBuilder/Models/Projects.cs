using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Projects
    {
        [Key]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "ProjectTitle  is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string ProjectTitle { get; set; }

        [Required(ErrorMessage = "Description  is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Description { get; set; }
        public int PersonID { get; set; }
    }
}