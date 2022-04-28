using CovidMobile.ViewModels;
using CovidMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CovidMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            // РЕГИСТРАЦИЯ СТРАНИЦ
            
            InitializeComponent();

            Routing.RegisterRoute("LoginCheckPage", typeof(LoginCheckPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("NotReceivedComponentPage", typeof(NotReceivedComponentPage));
            Routing.RegisterRoute("ComponentPage", typeof(ComponentPage));
            Routing.RegisterRoute("VacPointsInfoPage", typeof(VacPointsInfoPage));
            Routing.RegisterRoute("VacPointsReviewsPage", typeof(VacPointsReviewsPage));
            Routing.RegisterRoute("VacPointsAddReviewPage", typeof(VacPointsAddReviewPage));
            Routing.RegisterRoute("QuestionnarePage", typeof(QuestionnarePage));
        }

    }
}
