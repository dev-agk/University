using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Data
{
    public class ApplicationDataSource
    {
        public ApplicationDataSource()
        {
            this.students = new List<Students>()
            {
                new Students()
            {
                StudentId = 1,
                FirstName = "Abhilash",
                LastName = "GK",
                ContactNo = "9900195635",
                DOB = DateTime.ParseExact("22031996", "ddMMyyyy", CultureInfo.InvariantCulture)
            },
                new Students()
                {
                    StudentId = 2,
                    FirstName = "Deepak",
                    LastName = "E",
                    ContactNo = "9900195636",
                    DOB = DateTime.ParseExact("19071985", "ddMMyyyy", CultureInfo.InvariantCulture)
                },
                new Students()
                {
                    StudentId = 3,
                    FirstName = "Chandrashekar",
                    LastName = "P",
                    ContactNo = "9900196635",
                    DOB = DateTime.ParseExact("12111980", "ddMMyyyy", CultureInfo.InvariantCulture)
                }
            };

            this.courses = new List<Courses>()
            {
                new Courses()
                    {
                        CourseID = 1,
                        CourseName = "C#",
                        CourseDetails = "Introduction to c#"
                    },
                new Courses()
                    {
                        CourseID = 2,
                        CourseName = "PHP",
                        CourseDetails = "Introduction to PHP"
                    },
                new Courses()
                    {
                        CourseID = 3,
                        CourseName = "HR Management",
                        CourseDetails = "Introduction to HR Management"
                    }
            };
            this.studentCourses = new List<StudentCourses>()
            {
                new StudentCourses()
                {
                    CourseId = 1,
                    StudentId = 1
                },
                new StudentCourses()
                {
                    CourseId = 3,
                    StudentId = 2
                },
                new StudentCourses()
                {
                    CourseId = 2,
                    StudentId = 3
                }
            };
        }

        public List<Students> students { get; set; }

        public List<Courses> courses { get; set; }

        public List<StudentCourses> studentCourses { get; set; }

    }
}
