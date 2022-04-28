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
    [QueryProperty(nameof(VacPointId), "vacPointId")]
    public partial class VacPointsReviewsPage : ContentPage
    {
        private VaccinationPoints CurrentVacPoint { get; set; }

        private void VacPointIdLoad(int vacPointId)
        {
            CurrentVacPoint = AppData.GetVaccinationPoints().Where(p => p.ID == vacPointId).FirstOrDefault();
        }

        public int VacPointId
        {
            set
            {
                VacPointIdLoad(value);
            }
        }

        public VacPointsReviewsPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            BindingContext = CurrentVacPoint;

            var reviewList = AppData.GetReviews().Where(p => p.VaccinationPointID == CurrentVacPoint.ID).ToList();

            ListReviews.ItemsSource = reviewList;
        }

        /// <summary>
        /// Переход на страницу для оставления отзыва
        /// </summary>
        private async void BtnAddReview_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"VacPointsAddReviewPage?vacPointId={CurrentVacPoint.ID}");
        }
    }
}