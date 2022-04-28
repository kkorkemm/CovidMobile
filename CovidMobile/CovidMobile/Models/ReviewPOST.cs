using System;
using System.Collections.Generic;
using System.Text;

namespace CovidMobile.Models
{
    public class ReviewPOST
    {
        public int ID { get; set; }
        public int VaccinationPointID { get; set; }
        public int PatientID { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
    }
}
