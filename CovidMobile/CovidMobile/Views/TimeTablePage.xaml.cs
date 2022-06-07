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
    [QueryProperty(nameof(ComponentID), "componentID")]
    public partial class TimeTablePage : ContentPage
    {
        private int CurrentComponentID { get; set; }

        private void LoadComponentID(int componentID)
        {
            CurrentComponentID = componentID;
        }

        public int ComponentID
        {
            set
            {
                LoadComponentID(value);
            }
        }

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

        /// <summary>
        /// Перед выбором даты нужно выбрать пункт вакцинации
        /// </summary>
        /// <returns> Выбран ли пункт вакцинации </returns>
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

        /// <summary>
        /// Обновить расписание при выборе даты или пункта
        /// </summary>
        private void UpdateList()
        {
            var timeTableForDay = TimeTables.Where(p => p.Date == DateDate.Date && (p.ComponentID == CurrentComponentID || p.ComponentID == 0)).ToList();
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

        /// <summary>
        /// Следующая дата
        /// </summary>
        private void BtnNextDate_Clicked(object sender, EventArgs e)
        {
            if (CheckList() == true)
            {
                var date = DateDate.Date;
                DateDate.Date = date.AddDays(1);
            }
        }

        /// <summary>
        /// Предыдущая дата
        /// </summary>
        private void BtnPreviousDate_Clicked(object sender, EventArgs e)
        {
            if (CheckList() == true)
            {
                var date = DateDate.Date;
                DateDate.Date = date.AddDays(-1);
            }
        }

        /// <summary>
        /// При выборе даты
        /// </summary>
        private void DateDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            CheckList();

            if (DateDate.Date > DateTime.Now)
                BtnPreviousDate.IsVisible = true;
            else
                BtnPreviousDate.IsVisible = false;

            UpdateList();
        }

        /// <summary>
        /// При выборе пункта вакцинации
        /// </summary>
        private void PickerVacPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            var point = PickerVacPoints.SelectedItem as VaccinationPoints;
            TimeTables = AppData.GetTimeTables().Where(p => p.VaccinationPoint == point.Name).ToList();

            UpdateList();
        }

        /// <summary>
        /// При выборе времени приема
        /// </summary>
        private async void ListTimeTable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var timeTable = e.SelectedItem as TimeTables;

            await Shell.Current.GoToAsync($"AppointmentPermissionPage?timeTableID={timeTable.ID}&componentID={CurrentComponentID}");
        }
    }
}