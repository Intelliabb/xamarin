using System;
using BirthdayCalendar.Models;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCalendar.Data
{
    public class EmployeesRepository
    {
        static object locker = new object ();

        SQLiteConnection database;

        static string DatabasePath {
            get { 
                var sqliteFilename = "SogetiEmployeesSQLite.db3";
                #if __IOS__
                string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
                var path = Path.Combine(libraryPath, sqliteFilename);
                #else
                #if __ANDROID__
                string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
                var path = Path.Combine(documentsPath, sqliteFilename);
                #else
                // WinPhone
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);;
                #endif
                #endif
                return path;
            }
        }

        /// <summary>
        /// Initializes a new instance of the EmployeesDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public EmployeesRepository()
        {
            database = new SQLiteConnection (DatabasePath);
            // create the tables
            database.CreateTable<Employee>();
        }

        public IEnumerable<Employee> GetAllEmployees (bool isActive = true)
        {
            lock (locker) {
                return (from i in database.Table<Employee>() select i).Where(x=>x.IsActive == isActive).ToList();
            }
        }
        public Employee GetEmployeeById (int empId)
        {
            lock (locker) {
                return (database.Table<Employee>().FirstOrDefault(x => x.ID == empId));
            }
        }
        public IEnumerable<Employee> GetEmployeesByPractice (string practice)
        {
            lock (locker) {
                return (database.Table<Employee>().Where(x => x.Practice == practice).ToList());
            }
        }
        public IEnumerable<Employee> GetEmployeesByTitle (string title)
        {
            lock (locker) {
                return (database.Table<Employee>().Where(x => x.Practice == title).ToList());
            }
        }

        public int SaveEmployee (Employee emp) 
        {
            lock (locker) {
                if (emp == null || emp.ID == 0) {
                    return database.Insert(emp);
                } else {
                    database.Update(emp);
                    return emp.ID;
                }
            }
        }

        public int DeleteEmployee(int id)
        {
            lock (locker) {
                Employee emp = GetEmployeeById(id);
                emp.IsActive = false;
                return database.Update(emp);
            }
        }
    }
}

