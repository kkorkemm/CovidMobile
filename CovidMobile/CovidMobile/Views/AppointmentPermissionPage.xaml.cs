using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidMobile.Views
{
    using Models;
    using Newtonsoft.Json;
    using Services;
    using System.Net;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ComponentID), "componentID")]
    [QueryProperty(nameof(TimeTableID), "timeTableID")]
    public partial class AppointmentPermissionPage : ContentPage
    {

        private int CurrentComponentID { get; set; }

        private void LoadComponentID(int componentID)
        {
            CurrentComponentID = componentID;
        }

        public int ComponentID
        {
            set
            {
                LoadComponentID(value);
            }
        }

        private int CurrentTimeTableID { get; set; }

        private void LoadTimeTableID(int timeTableID)
        {
            CurrentTimeTableID = timeTableID;
        }

        public int TimeTableID
        {
            set
            {
                LoadTimeTableID(value);
            }
        }

        public AppointmentPermissionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var questionnare = AppData.GetQuestionnare(AppData.CurrentPatient.ID);
            if (questionnare != null)
            {
                BtnQuestionnare.IsVisible = false;
            }
        }

        /// <summary>
        /// На страницу для заполнения анкеты
        /// </summary>
        private async void BtnQuestionnare_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("QuestionnarePage");
        }

        /// <summary>
        /// Сохранение записи
        /// </summary>
        private async void BtnAgree_Clicked(object sender, EventArgs e)
        {
            if (CheckAgree.IsChecked == false)
            {
                await DisplayAlert("Внимание!", "Нельзя сохранить запись на вакцинацию без согласия", "Ok");
                return;
            }

            AppointmentPOST appointmentPOST = new AppointmentPOST()
            {
                TimeTableID = CurrentTimeTableID,
                PatientID = AppData.CurrentPatient.ID,
                ComponentTypeID = CurrentComponentID,
                IsReceived = false
            };


            try
            {
                var client = new WebClient();
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var result = client.UploadString(AppData.CheckDevice() + "Appointments", JsonConvert.SerializeObject(appointmentPOST));

                await DisplayAlert("Успех!", "Запись на вакцину прошла успешно!", "Ok");
                await Shell.Current.GoToAsync("../../..");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Внимание!", ex.Message, "Ok");
                return;
            }
        }
    }
}