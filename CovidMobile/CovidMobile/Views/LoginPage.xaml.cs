using CovidMobile.ViewModels;
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

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Проверка пользователя и переход на страницу подтверждения
        /// </summary>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Проверка на заполнение полей
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(TextNumber.Text))
                errors.AppendLine("Введите номер");
            if (string.IsNullOrWhiteSpace(TextCode.Text))
                errors.AppendLine("Введите ИИН");

            if (errors.Length > 0)
            {
                await DisplayAlert("Внимание!", errors.ToString(), "Ок");
                return;
            }

            // Поиск пользователя
            var user = AppData.GetPatients().Where(p => p.Code == TextCode.Text && p.Telephone == TextNumber.Text).FirstOrDefault();

            // Проверка на существование пользователя
            if (user != null)
            {
                await Shell.Current.GoToAsync($"LoginCheckPage?patientID={user.ID}");
            }
            else
            {
                await DisplayAlert("Ошибка!", "Пользователь не найден. \n Проверьте ИИН и номер телефона", "Ок");
            }
        }
    }
}