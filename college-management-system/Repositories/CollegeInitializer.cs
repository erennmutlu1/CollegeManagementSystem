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
            new Student{StudentId = 1, RegistrationNumber = 1000, Name = "John John Florence",Birthday = DateTime.Parse("2000-09-01")},
            new Student{StudentId = 2, RegistrationNumber = 1002, Name = "Kolohe Andino",Birthday = DateTime.Parse("2000-09-01")},
            new Student{StudentId = 3, RegistrationNumber = 1003, Name = "Gabriel Medina",Birthday = DateTime.Parse("2000-09-01")},
            new Student{StudentId = 4, RegistrationNumber = 1004, Name = "Italo Ferreira",Birthday = DateTime.Parse("1998-09-01")},
            new Student{StudentId = 5, RegistrationNumber = 1005, Name = "Filipe Toledo",Birthday = DateTime.Parse("1998-09-01")},
            new Student{StudentId = 6, RegistrationNumber = 1006, Name = "Stephanie Gilmore",Birthday = DateTime.Parse("1998-09-01")},
            new Student{StudentId = 7, RegistrationNumber = 1007, Name = "Sally Fitzgibbons",Birthday = DateTime.Parse("1998-09-01")},
            new Student{StudentId = 8, RegistrationNumber = 1008, Name = "Tatiana Weston Webb",Birthday = DateTime.Parse("1995-02-15")},
            new Student{StudentId = 9, RegistrationNumber = 1009, Name = "Lakey Peterson",Birthday = DateTime.Parse("1995-02-15")},
            new Student{StudentId = 10, RegistrationNumber = 1010, Name = "Jordy Smith",Birthday = DateTime.Parse("1995-02-15")},
            new Student{StudentId = 11, RegistrationNumber = 1011, Name = "Kanoa Igarashi",Birthday = DateTime.Parse("1995-02-15")},
            new Student{StudentId = 12, RegistrationNumber = 1012, Name = "Devid Silva",Birthday = DateTime.Parse("1995-02-15")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher{ TeacherId = 3563, Name = "Joseff Climber", Salary = (decimal) 2500.00, Birthday = DateTime.Parse("1965-02-15")},
                new Teacher{ TeacherId = 1250, Name = "Di Mateo", Salary = (decimal) 3500.00, Birthday = DateTime.Parse("1975-02-15") },
                new Teacher{ TeacherId = 8771, Name = "DeLucca Fernandez", Salary = (decimal) 15000.00, Birthday = DateTime.Parse("1990-02-15") },
                new Teacher{ TeacherId = 6302, Name = "Gilberto Gil", Salary = (decimal) 5000.00, Birthday = DateTime.Parse("1986-02-15") },
                new Teacher{ TeacherId = 1153, Name = "Jimi Page", Salary = (decimal) 4500.00, Birthday = DateTime.Parse("1984-02-15") }
            };

            teachers.ForEach(t => context.Teachers.Add(t));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseId = 1050,Name = "System Information"},
                new Course{CourseId = 4022,Name = "Computer Science"},
                new Course{CourseId = 4041,Name = "Electrical Engineering"},
                new Course{CourseId = 3141,Name = "Fine Arts"}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
        }
    }
}