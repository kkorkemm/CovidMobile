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
    public partial class QuestionnarePage : ContentPage
    {
        Questionnare CurrentQuestionnare { get; set; }

        public QuestionnarePage()
        {
            InitializeComponent();

            CurrentQuestionnare = AppData.GetQuestionnare(AppData.CurrentPatient.ID);
            if (CurrentQuestionnare == null)
            {
                CurrentQuestionnare = new Questionnare()
                {
                    PatientID = AppData.CurrentPatient.ID
                };
            }

            BindingContext = CurrentQuestionnare;
        }

        /// <summary>
        /// Сохранение анкеты
        /// </summary>
        private void BtnPost_Clicked(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            
            try
            {
                if (CurrentQuestionnare.ID == 0)
                {
                    var result = client.UploadString(AppData.CheckDevice() + "Questionnnares", JsonConvert.SerializeObject(CurrentQuestionnare));
                }
                else
                {
                    var result = client.UploadString(AppData.CheckDevice() + "Questionnnares/" + CurrentQuestionnare.ID.ToString(), "PUT", JsonConvert.SerializeObject(CurrentQuestionnare));
                }

                DisplayAlert("Успех!", "Анкета успешно сохранена!", "Ok");
                Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                DisplayAlert("Внимание!", ex.Message, "Ok");
            }
        }
    }
}