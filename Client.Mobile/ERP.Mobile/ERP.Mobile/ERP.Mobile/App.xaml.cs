using ERP.Mobile.ViewModels.Core;
using ERP.Mobile.Views.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ERP.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Views.Core.Layout();

            ShowLoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void ShowLoginPage()
        {
            var login = new Views.Core.Login();
            login.BindingContext = new LoginViewModel();

            MainPage = login;
        }
    }
}
