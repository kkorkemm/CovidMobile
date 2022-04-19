using System;
using System.Collections.Generic;
using System.Text;

namespace CovidMobile.Models
{
    public class Patients
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string Telephone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsQuestionnareCompleted { get; set; }
        
    }
}
