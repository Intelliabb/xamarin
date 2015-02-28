using System;
using BirthdayCalendar.Models;
using System.Collections.Generic;
using BirthdayCalendar.Data;
using System.Linq;

namespace BirthdayCalendar
{
    public class MainViewModel : BaseViewModel
    {
        private EmployeesRepository _repo;
        private string _title;

        public MainViewModel()
        {
            _repo = new EmployeesRepository();
            _title = "Sogetians";
        }

        public string Title
        {
            get { return _title; }
            set 
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public List<Employee> Employees
        {
            get { return _repo.GetAllEmployees().ToList(); }
        }

        public void AddSamples()
        {
            SampleData.InsertSampleData();
        }
    }
}

