using System;
using BirthdayCalendar.Models;
using BirthdayCalendar.Data;

namespace BirthdayCalendar
{
    public class EmployeeViewModel : BaseViewModel
    {
        private EmployeesRepository _repo;
        private Employee _employee;

        public EmployeeViewModel(Employee employee)
        {
            _repo = new EmployeesRepository();
            _employee = GetEmployee(employee.ID);
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

        private Employee GetEmployee(int empId)
        {
            return _repo.GetEmployeeById(empId);
        }
    }
}

