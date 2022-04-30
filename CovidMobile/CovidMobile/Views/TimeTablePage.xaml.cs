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
    public partial class TimeTablePage : ContentPage
    {
        private List<TimeTables> TimeTables { get; set; }

        public TimeTablePage()
        {
            InitializeComponent();

            DateDate.MinimumDate = DateTime.Now;
            DateDate.Date = DateTime.Now;
            BtnPreviousDate.IsVisible = false;

            var vacPoints = AppData.GetVaccinationPoints().Where(p => p.UserRoleID != 1).ToList();
            PickerVacPoints.ItemsSource = vacPoints;
        }

        private bool CheckList()
        {
            if (TimeTables == null)
            {
                DisplayAlert("Внимание!", "Выберите пункт вакцинации", "Ok");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UpdateList()
        {
            var timeTableForDay = TimeTables.Where(p => p.Date == DateDate.Date).ToList();
            if (timeTableForDay.Count() == 0)
            {
                ListTimeTable.IsVisible = false;
                TextNoSchedule.IsVisible = true;
            }
            else
            {
                ListTimeTable.IsVisible = true;
                TextNoSchedule.IsVisible = false;

                ListTimeTable.ItemsSource = timeTableForDay;
            }
        }

        private void BtnNextDate_Clicked(object sender, EventArgs e)
        {
            if (CheckList() == true)
            {
                var date = DateDate.Date;
                DateDate.Date = date.AddDays(1);
            }
        }

        private void BtnPreviousDate_Clicked(object sender, EventArgs e)
        {
            if (CheckList() == true)
            {
                var date = DateDate.Date;
                DateDate.Date = date.AddDays(-1);
            }
        }

        private void DateDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            CheckList();

            if (DateDate.Date > DateTime.Now)
                BtnPreviousDate.IsVisible = true;
            else
                BtnPreviousDate.IsVisible = false;

            UpdateList();
        }

        private void PickerVacPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            var point = PickerVacPoints.SelectedItem as VaccinationPoints;
            TimeTables = AppData.GetTimeTables().Where(p => p.VaccinationPoint == point.Name).ToList();

            UpdateList();
        }
    }
}