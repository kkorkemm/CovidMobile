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
    }
}