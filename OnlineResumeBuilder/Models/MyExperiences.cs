using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class MyExperiences
    {
        public Experience Experience { get; set; }
        public ExperienceSecond ExperienceSecond { get; set; }
    }

    public enum Countries
    {
        India,
        USA
    }
}