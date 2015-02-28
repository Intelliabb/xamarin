using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BirthdayCalendar.Models;
using BirthdayCalendar.Data;

namespace BirthdayCalendar.Views.Pages
{
    public partial class EmployeeDetailsPage : ContentPage
    {
        private EmployeeViewModel _vm;

        public EmployeeDetailsPage(Employee employee)
        {
            InitializeComponent();
            InitializeEditButton();

            _vm = new EmployeeViewModel(employee);
            BindingContext = _vm.Employee;
        }

        /// <summary>
        /// Initializes the edit button.
        /// </summary>
        private void InitializeEditButton()
        {
            var editButton = new ToolbarItem
                {
                    Text = "Edit",
                    Order = ToolbarItemOrder.Primary,
                };
            editButton.Clicked += btnEdit_Clicked;

            this.ToolbarItems.Add(editButton);
        }

        /// <summary>
        /// Edit clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        private void btnEdit_Clicked(object sender, EventArgs args)
        {
            var page = new EmployeeSavePage(BindingContext as Employee);
            page.BindingContext = BindingContext;
            Navigation.PushAsync(page);
        }

        /// <summary>
        /// Raises the appearing event.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        /// <summary>
        /// Raises the disappearing event.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}

