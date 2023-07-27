using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Skill
    {
        [Key]
        public int SID { get; set; }

        [Required(ErrorMessage = "Skill  is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateField]
        public string Skills { get; set; }
        public int PersonID { get; set; }
    }
}