using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidMobile.UserControls
{
    using Services;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogoNameControl : Grid
    {
        public LogoNameControl()
        {
            InitializeComponent();
        }

        protected override void OnParentSet()
        {
            if (AppData.CurrentPatient != null)
            {
                TextUserName.Text = AppData.CurrentPatient.FullName;
            }
            else
            {
                TextUserName.Text = "Войдите, чтобы продолжить";
            }
        }
    }
}