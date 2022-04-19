using System;
using System.Collections.Generic;
using System.Text;

namespace CovidMobile.Models
{
    public class Appointments
    {
        public int ID { get; set; }
        public int TimeTableID { get; set; }
        public int ComponentTypeID { get; set; }
        public string ComponentType { get; set; }
        public string DoctorName { get; set; }
        public int VaccinationPointID { get; set; }
        public string VaccinationPointName { get; set; }
        public int PatientID { get; set; }
        public bool IsReceived { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }
        
    }
}
