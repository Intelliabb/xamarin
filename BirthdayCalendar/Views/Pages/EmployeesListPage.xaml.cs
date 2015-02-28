using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;
using BirthdayCalendar.Data;
using BirthdayCalendar.Models;

namespace BirthdayCalendar.Views.Pages
{
    public partial class EmployeesListPage : ContentPage
    {
        private MainViewModel _vm = new MainViewModel();

        public EmployeesListPage()
        {
            InitializeComponent();
            InitializeNewButton();
            NavigationPage.SetHasNavigationBar(this, true);

            BindingContext = _vm;
        }

        /// <summary>
        /// Initializes the new button.
        /// </summary>
        private void InitializeNewButton()
        {
            var newButton = new ToolbarItem
                {
                    Text = "New",
                    Order = ToolbarItemOrder.Primary,
                };
            newButton.Clicked += btnNew_Clicked;

            this.ToolbarItems.Add(newButton);
        }

        /// <summary>
        /// Raises the appearing event.
        /// </summary>
        protected override void OnAppearing()
        {
            if (!BirthdayCalendar.App.LoggedIn)
                Navigation.PushModalAsync(new LoginPage());

            var list = _vm.Employees;

            if (list.Count() == 0)
                _vm.AddSamples();

            listView.ItemsSource = list;

            base.OnAppearing();
        }

        /// <summary>
        /// New clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        private void btnNew_Clicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EmployeeSavePage(new Employee()));
        }

        /// <summary>
        /// Lists the view item selected.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void listViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedEmployee = e.SelectedItem as Employee;
            if (selectedEmployee == null)
                return;

            Navigation.PushAsync(new EmployeeDetailsPage(selectedEmployee));
            listView.SelectedItem = null;
        }
    }
}

