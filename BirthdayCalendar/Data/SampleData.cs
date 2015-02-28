using System;
using BirthdayCalendar.Data;
using BirthdayCalendar.Models;

namespace BirthdayCalendar.Data
{
    public static class SampleData
    {
        static EmployeesRepository db = new EmployeesRepository();

        public static void InsertSampleData()
        {
            db.SaveEmployee(new Employee 
                {
                    IsActive = true,
                    Name = "Hussain Abbasi",
                    Title = "Consultant",
                    Practice = "DT",
                    Unit = "Houston",
                    DOB = DateTime.Parse("16-Oct-1985"),
                    ImageUrl = "https://media.licdn.com/mpr/mpr/shrink_200_200/p/2/000/045/2b6/105ac65.jpg"
                }
            );
            db.SaveEmployee(new Employee 
                {
                    IsActive = true,
                    Name = "Naveen Mangtani",
                    Title = "Manager",
                    Practice = "SDI",
                    Unit = "Dallas",
                    DOB = DateTime.Parse("1-Nov-1982"),
                    ImageUrl = "https://media.licdn.com/mpr/mpr/shrink_200_200/p/1/000/22f/2a6/10b1e5b.jpg"
                }
            );
            db.SaveEmployee(new Employee 
                {
                    IsActive = true,
                    Name = "Tiffany Blansett",
                    Title = "Consultant",
                    Practice = "Office",
                    Unit = "Houston",
                    DOB = DateTime.Parse("1-Nov-1982"),
                    ImageUrl = "https://media.licdn.com/mpr/mpr/shrink_200_200/p/5/005/060/1c3/100d8c9.jpg"
                }
            );
            db.SaveEmployee(new Employee 
                {
                    IsActive = true,
                    Name = "Ron Mahlman",
                    Title = "Sr. Manager",
                    Practice = "BIM",
                    Unit = "Ohio",
                    DOB = DateTime.Parse("12-Sep-1974"),
                    ImageUrl = "https://media.licdn.com/mpr/mpr/shrink_200_200/p/8/000/1ea/3cd/0e6dc5e.jpg"
                }
            );
            db.SaveEmployee(new Employee 
                {
                    IsActive = true,
                    Name = "Dan Luciano",
                    Title = "Practise Manager",
                    Practice = "DT",
                    Unit = "Houston",
                    DOB = DateTime.Parse("12-Sep-1970"),
                    ImageUrl = "https://media.licdn.com/mpr/mpr/shrink_200_200/p/4/005/09b/168/125de51.jpg"
                }
            );

        }
    }
}

