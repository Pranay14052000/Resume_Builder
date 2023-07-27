using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Accomplishments
    {
       
        [Required(ErrorMessage = "The Skills field is required.")]
        public Skill Skill { get; set; }

        [Required(ErrorMessage = "The Projects field is required.")]
        public Projects Projects { get; set; }

        [Required(ErrorMessage = "The Internship field is required.")]
        public Internship Internship { get; set; }

        [Required(ErrorMessage = "The Certification field is required.")]
        public Certification Certification { get; set; }


    }
}