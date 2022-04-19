using System;
using System.Collections.Generic;
using System.Text;

namespace CovidMobile.Models
{
    public class TimeTables
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string VaccinationPoint { get; set; }
        public string DoctorName { get; set; }
      
    }
}
