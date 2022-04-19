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
    [QueryProperty(nameof(PatientID), "patientID")]
    public partial class LoginCheckPage : ContentPage
    {
        private string code;
        private Patients CheckedPatient { get; set; }

        /// <summary>
        /// Получение параметры с предыдущей страницы
        /// </summary>
        /// <param name="patientID"> ID текущего пользователя системы </param>
        private void PatientIDLoad(int patientID)
        {
            CheckedPatient = AppData.GetPatients().Where(p => p.ID == patientID).FirstOrDefault();
        }
 
        /// <summary>
        /// Параметр
        /// </summary>
        public int PatientID
        {
            set
            {
                PatientIDLoad(value);
            }
        }

        public LoginCheckPage()
        {
            InitializeComponent();

            GenerateCode();
        }

        /// <summary>
        /// Генерирование случайного кода для подтверждения номера (пока просто как сообщение)
        /// </summary>
        private async void GenerateCode()
        {
            string codeSymbols = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKZXCVBNM";

            Random r = new Random();

            for (int i = 0; i < 4; i++)
            {
                int index = r.Next(0, codeSymbols.Length);
                code += codeSymbols[index].ToString();
            }

            await DisplayAlert("Внимание!", $"Код: {code}", "Ok");
        }

        /// <summary>
        /// Генерирование нового кода
        /// </summary>
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            GenerateCode();
        }

        /// <summary>
        /// Проверка кода и переход к главной странице
        /// </summary>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (code == TextCode.Text)
            {
                AppData.CurrentPatient = CheckedPatient;
                await Shell.Current.GoToAsync("MainPage");
            }
            else
            {
                await DisplayAlert("Ошибка!", "Неверный код", "Ок");
            }
        }
    }
}