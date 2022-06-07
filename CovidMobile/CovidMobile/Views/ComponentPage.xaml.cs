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
    using Services;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(AppointmentID), "appointmentID")]
    public partial class ComponentPage : ContentPage
    {
        /// <summary>
        /// Текущая запись на вакцину
        /// </summary>
        private Appointments CurrentAppointment { get; set; }

        private void AppoitmentLoad(int appointmentID)
        {
            CurrentAppointment = AppData.GetAppointments().Where(p => p.ID == appointmentID).FirstOrDefault();
        }

        /// <summary>
        /// Параметр
        /// </summary>
        public int AppointmentID
        {
            set
            {
                AppoitmentLoad(value);
            }
        }

        public ComponentPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = CurrentAppointment;

            // если компонент получен, видна кнопка для получения справки, иначе - кнопка для редактирования
            //if (CurrentAppointment.IsReceived == true)
            //{
            //    BtnGetPDF.IsVisible = true;
            //    BtnEdit.IsVisible = false;
            //}
            //else
            //{
            //    BtnGetPDF.IsVisible = false;
            //    BtnEdit.IsVisible = true;
            //}
        }

        /// <summary>
        /// Переход на страницу пункта вакцинации (фрейм Место сдачи)
        /// </summary>
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            int pointId = CurrentAppointment.VaccinationPointID;
            await Shell.Current.GoToAsync($"VacPointsInfoPage?vacPointId={pointId}");
        }
    }
}