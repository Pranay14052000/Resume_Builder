using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class Resume
    {
        public int ResumeID { get; set; }
        public string FilePath { get; set; }


        //PersonID I didn;t use everywhere //used in admin user data section
        public int PersonID { get; set; }

        public string ResumePersonPhoto { get; set; }
    }
}