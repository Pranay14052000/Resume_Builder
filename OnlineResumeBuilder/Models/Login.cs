using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Login
    {
        [Required (ErrorMessage="UserName is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidateUserName]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [OnlineResumeBuilder.Models.CustomValidationAttributes.ValidatePassword]
        public string Password { get; set; }
    }
}