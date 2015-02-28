using System;
using SQLite;

namespace BirthdayCalendar.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Unit
        {
            get;
            set;
        }
        public string Practice
        {
            get;
            set;
        }
        public string Title {
            get;
            set;
        }
        public DateTime DOB
        {
            get;
            set;
        }
        public string ImageUrl
        {
            get;
            set;
        }

        public Employee()
        {
        }
    }
}

