using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;
using BirthdayCalendar;

namespace BirthdayCalendar.Views.Pages
{
    public partial class LoginPage : ContentPage
    {
        #region Constructor

        public LoginPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <returns><c>true</c>, if user was authenticated, <c>false</c> otherwise.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        private bool AuthenticateUser(string username, string password)
        {
            return BirthdayCalendar.App.Login(username, password);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Login clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (AuthenticateUser(txtUsername.Text, txtPassword.Text))
                {
                    BirthdayCalendar.App.LoggedIn = true;
                    Navigation.PopModalAsync();
                }
                else
                    DisplayAlert("Login Failed", "Invalid Username/Password. Try again", "OK");
            }
            else
                DisplayAlert("Login Missing", "Please enter Username and Password and try again", "OK");
        }

        #endregion
    }
}

