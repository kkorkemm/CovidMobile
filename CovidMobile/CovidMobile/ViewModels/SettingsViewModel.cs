using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace CovidMobile.ViewModels
{
    internal class SettingsViewModel :BaseViewModel
    {
        public SettingsViewModel()
        {
            Title = "Настройки";

            ExitCommand = new Command(OnExit);
            QuestionnareCommand = new Command(OnQuestionnare);
            ChangeThemeCommand = new Command(OnThemeChange);
            ChangeLangCommand = new Command(OnLangChange);
        }
        
        // COMMANDS 
        public Command ExitCommand { get; }
        public Command QuestionnareCommand { get; }
        public Command ChangeThemeCommand { get; }
        public Command ChangeLangCommand { get; }

        /// <summary>
        /// Пользователь выходит из своей учетной записи
        /// </summary>
        private void OnExit()
        {

        }

        /// <summary>
        /// Переход на страницу с анкетой
        /// </summary>
        private void OnQuestionnare()
        {

        }

        /// <summary>
        /// Смена темы приложения (светлая, темная)
        /// </summary>
        private void OnThemeChange()
        {
            if (Application.Current.UserAppTheme == OSAppTheme.Light)
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
        }

        /// <summary>
        /// Смена языка приложения (русский, казахский, английский)
        /// </summary>
        private void OnLangChange()
        {
            var lang = System.Globalization.CultureInfo.CurrentCulture.Name;
            System.Globalization.CultureInfo newLang;


            if (lang == "en-US")
            {
                newLang = new System.Globalization.CultureInfo("ru-RU");

            }
            else if (lang == "ru-RU")
            {
                newLang = new System.Globalization.CultureInfo("kk-KZ");
            }
            else
            {
                newLang = new System.Globalization.CultureInfo("en-US");
            }

            Thread.CurrentThread.CurrentUICulture = newLang;
            Thread.CurrentThread.CurrentCulture = newLang;
        }
    }
}
