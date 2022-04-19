using System;
using System.Collections.Generic;
using System.Text;

namespace CovidMobile.Models
{
    public class VaccinationPoints
    {
        public int ID { get; set; }
        public int UserRoleID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }
        public string Telephone { get; set; }
        public object Photo { get; set; }
        public float AverageRating { get; set; }

        public string AverageText => $"{AverageRating} из 5";
    }
}
