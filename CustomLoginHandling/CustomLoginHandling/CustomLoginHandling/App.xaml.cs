using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomLoginHandling.Helpers;
using CustomLoginHandling.Pages;
using Xamarin.Forms;

namespace CustomLoginHandling
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //INITIALLY LOGIN PAGE WILL BE THE PAGE
            //WE WILL BE USING https://nuget.org/packages/Xam.Plugins.Settings/ to persist our login token
            if(string.IsNullOrWhiteSpace(Settings.AuthToken))
                MainPage = new NavigationPage(new LoginPage());
            else
                MainPage = new NavigationPage(new MainPage());
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
    }
}
