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
    public partial class VacPointsListPage : ContentPage
    {
        public VacPointsListPage()
        {
            InitializeComponent();

            var pointsList = AppData.GetVaccinationPoints().Where(p => p.UserRoleID != 1);
            ListVacPoints.ItemsSource = pointsList.ToList();
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var pointsList = AppData.GetVaccinationPoints().Where(p => p.UserRoleID != 1);

            if (!string.IsNullOrWhiteSpace(TextSearch.Text))
            {
                ListVacPoints.ItemsSource = pointsList.Where(p => p.Name.Contains(TextSearch.Text) || p.Address.Contains(TextSearch.Text));
            }
            else
            {
                ListVacPoints.ItemsSource = pointsList;
            }
        }

        /// <summary>
        /// Переход на страницу с информацией о пункте вакцинации
        /// </summary>
        private async void ListVacPoints_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int pointId = (e.SelectedItem as VaccinationPoints).ID;
            await Shell.Current.GoToAsync($"VacPointsInfoPage?vacPointId={pointId}");
        }
    }
}