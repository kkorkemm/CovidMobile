using System;
using System.Collections.Generic;
using System.Text;

namespace CovidMobile.Services
{
    using Models;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Net;

    public class AppData
    {
        /// <summary>
        /// Путь до API
        /// </summary>
        public static string addressPhone = "http://127.0.0.1:12345/api/";

        /// <summary>
        /// Путь до API для андроид
        /// </summary>
        public static string addressEmulator = "http://10.0.2.2:12345/api/";

        /// <summary>
        /// Проверка устройства (эмулятор или телефон)
        /// </summary>
        /// <returns> Нужный адрес API </returns>
        public static string CheckDevice()
        {
            string address;
            try
            {
                string responce = new WebClient().DownloadString(addressPhone);
                address = addressPhone;
            }
            catch
            {
                address = addressEmulator;
            }
            return address;
        }

        /// <summary>
        /// Текущий пользователь системы
        /// </summary>
        public static Patients CurrentPatient { get; set; }

        /// <summary>
        /// Получение списка пациентов с API
        /// </summary>
        /// <returns> Список пациентов </returns>
        public static List<Patients> GetPatients()
        {
            var client = new WebClient();
            string address = CheckDevice();
            var patients = client.DownloadString($"{address}Patients");
            return JsonConvert.DeserializeObject<List<Patients>>(patients);
        }

        /// <summary>
        /// Получение списка пунктов вакцинации с API
        /// </summary>
        /// <returns> Список пунктов вакцинации </returns>
        public static List<VaccinationPoints> GetVaccinationPoints()
        {
            var client = new WebClient();
            string address = CheckDevice();
            var points = client.DownloadString($"{address}VaccinationPoints");
            return JsonConvert.DeserializeObject<List<VaccinationPoints>>(points);
        }

        /// <summary>
        /// Получение расписания на вакцину пунктов вакцинации с API
        /// </summary>
        /// <returns> Расписание на вакцину </returns>
        public static List<TimeTables> GetTimeTables()
        {
            var client = new WebClient();
            string address = CheckDevice();
            var timetables = client.DownloadString($"{address}TimeTables");
            return JsonConvert.DeserializeObject<List<TimeTables>>(timetables);
        }

        /// <summary>
        /// Получение списка отзывов от пациентов на пункты вакцинации с API
        /// </summary>
        /// <returns> Список отзывов </returns>
        public static List<Reviews> GetReviews()
        {
            var client = new WebClient();
            string address = CheckDevice();
            var reviews = client.DownloadString($"{address}Reviews");
            return JsonConvert.DeserializeObject<List<Reviews>>(reviews);
        }

        /// <summary>
        /// Получение списка записей на вакцинацию с API
        /// </summary>
        /// <returns> Список записей </returns>
        public static List<Appointments> GetAppointments()
        {
            var client = new WebClient();
            string address = CheckDevice();
            var appointments = client.DownloadString($"{address}Appointments");
            return JsonConvert.DeserializeObject<List<Appointments>>(appointments);
        }

        /// <summary>
        /// Получение списка докторов с API
        /// </summary>
        /// <returns> Список докторов </returns>
        public static List<Doctor> GetDoctors()
        {
            var client = new WebClient();
            string address = CheckDevice();
            var doctors = client.DownloadString($"{address}Doctors");
            return JsonConvert.DeserializeObject<List<Doctor>>(doctors);
        }

        /// <summary>
        /// Получение анкеты пациента
        /// </summary>
        /// <returns> Список докторов </returns>
        public static Questionnare GetQuestionnare(int PatientID)
        {
            var client = new WebClient();
            string address = CheckDevice();
            var questionnares = client.DownloadString($"{address}Questionnnares");
            List<Questionnare> all = JsonConvert.DeserializeObject<List<Questionnare>>(questionnares);
            return all.Where(p =>p.PatientID == PatientID).FirstOrDefault();
        }
    }
}
