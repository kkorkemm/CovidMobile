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
    [QueryProperty(nameof(VacPointId), "vacPointId")]
    public partial class VacPointsInfoPage : ContentPage
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

        public VacPointsInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = CurrentVacPoint;

            var review = AppData.GetReviews().Where(p => p.VaccinationPointID == CurrentVacPoint.ID && p.Text != null).FirstOrDefault();

            FrameReview.BindingContext = review;
        }

        /// <summary>
        /// Переход на страницу со всеми отзывами о пункте вакцинации
        /// </summary>
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"VacPointsReviewsPage?vacPointId={CurrentVacPoint.ID}");
        }
    }
}