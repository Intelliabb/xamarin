using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BirthdayCalendar.Models;
using BirthdayCalendar.Data;

namespace BirthdayCalendar.Views.Pages
{
    public partial class EmployeeSavePage : ContentPage
    {
        private EmployeeSaveViewModel _vm;

        public EmployeeSavePage(Employee employee)
        {
            InitializeComponent();
            InitializeCancelButton();
            NavigationPage.SetHasNavigationBar(this, true);

            _vm = new EmployeeSaveViewModel(employee);

            BindingContext = _vm.Employee;
        }

        protected override void OnAppearing()
        {
            if (_vm.Employee.ID > 0)
            {
                Title = _vm.Employee.Name;
                DeleteButton.IsVisible = true;
            }
            else
            {
                Title = string.Empty;
                DeleteButton.IsVisible = false;
            }
            base.OnAppearing();
        }

        void SaveButton_Clicked(object sender, EventArgs e)
        {
            SaveEmployee();
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void InitializeCancelButton()
        {
            var newButton = new ToolbarItem
                {
                    Text = "Cancel",
                    Order = ToolbarItemOrder.Primary
                };
            newButton.Clicked += btnCancel_Clicked;

            this.ToolbarItems.Add(newButton);
        }

        async void SaveEmployee()
        {
            try
            {
                _vm.SaveEmployee();
            }
            catch (Exception ex)
            {
                var e = ex.InnerException ?? ex;
                await DisplayAlert("Error", string.Format("Could not save '{0}'. Error: {1}", ContactName.Text, e.Message), "Retry");
            }
            finally
            {
                await Navigation.PopAsync();
            }
        }

        async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if ((bool) await DisplayAlert("Delete", string.Format("Are you sure you want to delete {0}?", ContactName.Text), "Yes", "No"))
            {
                _vm.DeleteEmployee();
                await Navigation.PopToRootAsync();
            }
        }
    }
}

