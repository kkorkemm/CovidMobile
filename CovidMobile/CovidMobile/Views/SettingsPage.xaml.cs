using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidMobile.Views
{
    using Services;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new SettingsViewModel();

            if (AppData.CurrentPatient == null)
            {
                BtnExit.IsEnabled = false;
                BtnQuestion.IsEnabled = false;
            }
            else
            {
                BtnQuestion.IsEnabled = true;
                BtnExit.IsEnabled = true;
            }

        }

        private async void BtnQuestion_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("QuestionnarePage");
        }

        private void BtnTheme_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.UserAppTheme == OSAppTheme.Light)
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
                BtnTheme.Text = "Тема: темная";
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
                BtnTheme.Text = "Тема: светлая";
            }
        }
    }
}