using System;
using System.Collections.Generic;
using System.Text;

namespace CovidMobile.Models
{
    public class AppointmentPOST
    {
        public long ID { get; set; }
        public long TimeTableID { get; set; }
        public int ComponentTypeID { get; set; }
        public int PatientID { get; set; }
        public bool IsReceived { get; set; }
    }
}
