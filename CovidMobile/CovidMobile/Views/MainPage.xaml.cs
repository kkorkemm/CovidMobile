using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidMobile.Views
{
    using Services;
    using Models;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // записи на вакцину
            var userAppointments = AppData.GetAppointments().Where(p => p.PatientID == AppData.CurrentPatient.ID).ToList();

            // запись на первый компонент
            var first = userAppointments.Where(p => p.ComponentTypeID == 1).FirstOrDefault();
            // запись на второй компонент
            var second = userAppointments.Where(p => p.ComponentTypeID == 2).FirstOrDefault();

            // если записей не обнаружено
            if (first != null)
            {
                FirstFrame.BindingContext = first;
            }
            else
            {
                var newFirst = new Appointments()
                {
                    IsReceived = false,
                    Status = "Не получено",
                    BackColor = "#E7F2F8",
                    ForeColor = "#939393",
                    ComponentType = "I компонент"

                };
                FirstFrame.BindingContext = newFirst;
                NextIconFirst.Source = "next_icon.png";
            }

            if (second != null)
            {
                SecondFrame.BindingContext = second;
            }
            else
            {
                var newSecond = new Appointments()
                {
                    IsReceived = false,
                    Status = "Не получено",
                    BackColor = "#E7F2F8",
                    ForeColor = "#939393",
                    ComponentType = "II компонент"
                };
                SecondFrame.BindingContext = newSecond; 
                NextIconSecond.Source = "next_icon.png";
            }

            // Если пользователь уже заполнял анкету
            if (AppData.CurrentPatient.IsQuestionnareCompleted == false)
            {
                BtnQuestionnare.IsVisible = true;
            }
            else
            {
                BtnQuestionnare.IsVisible = false;
            }
        }

        /// <summary>
        /// Переход на страницы с информацией о записях на вакцину
        /// </summary>
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var appointment = (sender as Frame).BindingContext as Appointments;

            if (appointment.Status == "Не получено")
            {
                await Shell.Current.GoToAsync($"NotReceivedComponentPage?componentName={appointment.ComponentType}");
            }
            else
            {
                await Shell.Current.GoToAsync($"ComponentPage?appointmentID={appointment.ID}");
            }
        }

        /// <summary>
        /// Переход на страницу заполнения анкеты
        /// </summary>
        private async void BtnQuestionnare_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("QuestionnarePage");
        }
    }
}