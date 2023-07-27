using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class PersonResume
    {
        public  PersonalDetails PersonalDetails { get; set; }
        public MyExperiences MyExperiences { get; set; }
        public MyEducations MyEducations { get; set; }
        public Accomplishments Accomplishments { get; set; }

    }
}