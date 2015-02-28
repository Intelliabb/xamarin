using System;
using BirthdayCalendar.Data;
using BirthdayCalendar.Models;

namespace BirthdayCalendar
{
    public class EmployeeSaveViewModel : BaseViewModel
    {
        private EmployeesRepository _repo;
        private Employee _employee;

        public EmployeeSaveViewModel(Employee employee)
        {
            _repo = new EmployeesRepository();
            _employee = employee;
        }

        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }

        public void SaveEmployee()
        {
            if (_employee.ID > 0)
            {
                _repo.SaveEmployee(_employee);
                return;
            }

            _repo.SaveEmployee(new Employee
                {
                    IsActive = true,
                    ImageUrl = _employee.ImageUrl,
                    Name = _employee.Name,
                    Title = _employee.Title,
                    Practice = _employee.Practice,
                    Unit = _employee.Unit,
                    DOB = _employee.DOB
                });
        }

        public void DeleteEmployee()
        {
            _repo.DeleteEmployee(_employee.ID);
        }
    }
}

