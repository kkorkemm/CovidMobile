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
    using System.Net;
    using Newtonsoft.Json;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(VacPointId), "vacPointId")]
    public partial class VacPointsAddReviewPage : ContentPage
    {
        private VaccinationPoints CurrentVacPoint { get; set; }
        private int StarCount = 0;

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

        protected override void OnAppearing()
        {
            BindingContext = CurrentVacPoint;
        }

        public VacPointsAddReviewPage()
        {
            InitializeComponent();
        }

        private async void BtnPostReview_Clicked(object sender, EventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (StarCount == 0)
                errors.AppendLine("Укажите свою оценку");

            if (errors.Length > 0)
            {
                await DisplayAlert("Внимание!", errors.ToString(), "Ok");
                return;
            }

            ReviewPOST reviewPOST = new ReviewPOST()
            {
                VaccinationPointID = CurrentVacPoint.ID,
                PatientID = AppData.CurrentPatient.ID,
                Rating = StarCount,
                Text = TextReviewText.Text
            };


            try
            {
                var client = new WebClient();
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var result = client.UploadString(AppData.CheckDevice() + "Reviews", JsonConvert.SerializeObject(reviewPOST));

                await DisplayAlert("Успех!", "Отзыв успешно отправлен!", "Ok");
                await Shell.Current.GoToAsync("..");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Внимание!", ex.Message, "Ok");
                return;
            }
        }

        private void BtnFirstStar_Clicked(object sender, EventArgs e)
        {
            BtnFirstStar.Source = "star_icon_yellow.png";
            BtnSecondStar.Source = BtnThirdStar.Source = BtnFourthStar.Source = BtnFifthStar.Source = "star_icon.png";
            StarCount = 1;
        }

        private void BtnSecondStar_Clicked(object sender, EventArgs e)
        {
            BtnFirstStar.Source = BtnSecondStar.Source = "star_icon_yellow.png";
            BtnThirdStar.Source = BtnFourthStar.Source = BtnFifthStar.Source = "star_icon.png";
            StarCount = 2;
        }

        private void BtnThirdStar_Clicked(object sender, EventArgs e)
        {
            BtnFirstStar.Source = BtnSecondStar.Source = BtnThirdStar.Source = "star_icon_yellow.png";
            BtnFourthStar.Source = BtnFifthStar.Source = "star_icon.png";
            StarCount = 3;
        }

        private void BtnFourthStar_Clicked(object sender, EventArgs e)
        {
            BtnFirstStar.Source = BtnSecondStar.Source = BtnThirdStar.Source = BtnFourthStar.Source = "star_icon_yellow.png";
            BtnFifthStar.Source = "star_icon.png";
            StarCount = 4;
        }

        private void BtnFifthStar_Clicked(object sender, EventArgs e)
        {
            BtnFirstStar.Source = BtnSecondStar.Source = BtnThirdStar.Source = BtnFourthStar.Source = BtnFifthStar.Source = "star_icon_yellow.png";
            StarCount = 5;
        }
    }
}