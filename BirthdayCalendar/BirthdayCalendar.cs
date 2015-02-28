using System;

using Xamarin.Forms;
using BirthdayCalendar.Views.Pages;

namespace BirthdayCalendar
{
    public class App : Application
    {
        public static bool LoggedIn;

        public static Page GetMainPage()
        {
            return new NavigationPage(new EmployeesListPage());
        }

        public App()
        {
            MainPage = GetMainPage();
        }
        public static bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
                return false;

            if (username == "h" && password == "p")
            {
                return LoggedIn = true;
            }
            else
            {
                LoggedIn = false;
                return false;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            LoggedIn = false;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

