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
    [QueryProperty(nameof(ComponentType), "componentName")]
    public partial class NotReceivedComponentPage : ContentPage
    {
        private string ComponentTypeName { get; set; }
        private int ComponentID { get; set; }

        private void ComponentTypeLoad(string componentName)
        {
            ComponentTypeName = componentName;
        }

        public string ComponentType
        {
            set
            {
                ComponentTypeLoad(value);
            }
        }

        public NotReceivedComponentPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            TextComponent.Text = ComponentTypeName;
            ComponentID = ComponentTypeName == "I компонент" ? 1 : 2;
        }

        private async void BtnCreateAppointment_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"TimeTablePage?componentID={ComponentID}");
        }
    }
}