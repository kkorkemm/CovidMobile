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
            var user = AppData.GetPatients().Where(p => p.Code == TextCode.Text && p.Telephone == TextNumber.Text).FirstOrDefault();

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