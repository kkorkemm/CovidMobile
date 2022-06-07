using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CovidMobile.Models
{
    public class TimeTables
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string VaccinationPoint { get; set; }
        public string DoctorName { get; set; }
        public int PatientCount { get; set; }

        public string BackColor => PatientCount == 5 ? "#BEBEBE" : "#68D172";

        public int ComponentID
        {
            get
            {
                var compID = Services.AppData.GetAppointments().Where(p => p.TimeTableID == ID).FirstOrDefault();
                if (compID == null)
                    return 0;
                else
                    return compID.ComponentTypeID;
            }
        }
    }
}
