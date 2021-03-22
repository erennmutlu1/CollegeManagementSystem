using CollegeManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Repositories

{
    public class CollegeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CollegeContext>
    {
        protected override void Seed(CollegeContext context)
        {
            var students = new List<Student>
            {
            new Student{StudentId = 1, RegistrationNumber = 111, Name = "Alisch Carlmicheal",Birthday = DateTime.Parse("2000-09-01")},
            new Student{StudentId = 2, RegistrationNumber = 112, Name = "Iron Barmen",Birthday = DateTime.Parse("2000-09-01")},
            new Student{StudentId = 3, RegistrationNumber = 113, Name = "Isaac Newton",Birthday = DateTime.Parse("2000-09-01")},
            new Student{StudentId = 4, RegistrationNumber = 114, Name = "Nicola Tesla",Birthday = DateTime.Parse("1998-09-01")},
            new Student{StudentId = 5, RegistrationNumber = 115, Name = "Harry Kewell",Birthday = DateTime.Parse("1998-09-01")},
            new Student{StudentId = 6, RegistrationNumber = 116, Name = "Xalo Hass",Birthday = DateTime.Parse("1998-09-01")},
            new Student{StudentId = 7, RegistrationNumber = 117, Name = "Silvester Stone",Birthday = DateTime.Parse("1998-09-01")},
            new Student{StudentId = 8, RegistrationNumber = 118, Name = "Alzace Happiness",Birthday = DateTime.Parse("1995-02-15")},
            new Student{StudentId = 9, RegistrationNumber = 119, Name = "Zoyda Carlmicheal",Birthday = DateTime.Parse("1995-02-15")},
            new Student{StudentId = 10, RegistrationNumber = 120, Name = "Rodin Mirann",Birthday = DateTime.Parse("1995-02-15")},
            new Student{StudentId = 11, RegistrationNumber = 121, Name = "Denis Barran",Birthday = DateTime.Parse("1995-02-15")},
            new Student{StudentId = 12, RegistrationNumber = 122, Name = "Nelson Mandela",Birthday = DateTime.Parse("1995-02-15")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher{ TeacherId = 3563, Name = "Zerhaa Clonney", Salary = (decimal) 45000.00, Birthday = DateTime.Parse("1990-02-15")},
                new Teacher{ TeacherId = 1250, Name = "Aghella Barmen", Salary = (decimal) 18600.00, Birthday = DateTime.Parse("1995-02-15") },
                new Teacher{ TeacherId = 8771, Name = "Erry Carlmicheal", Salary = (decimal) 18000.00, Birthday = DateTime.Parse("1997-02-15") },
                new Teacher{ TeacherId = 6302, Name = "Erssan Happinies", Salary = (decimal) 25000.00, Birthday = DateTime.Parse("1986-02-15") },
                new Teacher{ TeacherId = 6302, Name = "Chety Clooney", Salary = (decimal) 20000.00, Birthday = DateTime.Parse("1990-02-15") },
                new Teacher{ TeacherId = 1153, Name = "Momoste Birchi", Salary = (decimal) 10000.00, Birthday = DateTime.Parse("1994-02-15") }
            };

            teachers.ForEach(t => context.Teachers.Add(t));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseId = 1207,Name = "Space Science"},
                new Course{CourseId = 1412,Name = "Modern Arts"},
                new Course{CourseId = 2584,Name = "Computer Science"},
                new Course{CourseId = 4569,Name = "Medicine"}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
        }
    }
}
