using System;
using System.Collections.Generic;
using System.Text;

namespace CovidMobile.Models
{
    public class Questionnare
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public bool IsBeenInPlaces { get; set; }
        public bool IsBeenContactedInPlaces { get; set; }
        public bool IsBeenContacted { get; set; }
        public bool IsWorking { get; set; }
        public bool IsSick { get; set; }
        public bool IsCovidBefore { get; set; }
        public bool IsSickNow { get; set; }
        
    }
}
