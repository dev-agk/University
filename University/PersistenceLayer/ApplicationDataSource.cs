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
        //public ApplicationDataSource()
        //{
        //    this.seedData = new ApplicationDataSource();
        //}

        public List<Students> students { get; set; }

        public List<Courses> courses { get; set; }

        public List<StudentCourses> studentCourses { get; set; }

        private ApplicationDataSource seedData;

        public ApplicationDataSource GetSeedData()
        {
            #region Studend Data
                var studentA = new Students()
                {
                    StudentId = 1,
                    FirstName = "Abhilash",
                    LastName = "GK",
                    ContactNo = "9900195635",
                    DOB = DateTime.ParseExact("22031996", "yyMMddHHmm", CultureInfo.InvariantCulture)
                };

                var studentB = new Students()
                {
                    StudentId = 2,
                    FirstName = "Deepak",
                    LastName = "E",
                    ContactNo = "9900195636",
                    DOB = DateTime.ParseExact("19071985", "yyMMddHHmm", CultureInfo.InvariantCulture)
                };

                var studentC = new Students()
                {
                    StudentId = 3,
                    FirstName = "Chandrashekar",
                    LastName = "P",
                    ContactNo = "9900196635",
                    DOB = DateTime.ParseExact("12111980", "yyMMddHHmm", CultureInfo.InvariantCulture)
                };

                this.seedData.students.Add(studentA);
                this.seedData.students.Add(studentB);
                this.seedData.students.Add(studentC);
            #endregion

            #region Course Data
                var courseA = new Courses()
                {
                   CourseID = 1,
                   CourseName = "C#",
                   CourseDetails = "Introduction to c#"
                };

                var courseB = new Courses()
                {
                    CourseID = 2,
                    CourseName = "PHP",
                    CourseDetails = "Introduction to PHP"
                };

                var courseC = new Courses()
                {
                    CourseID = 2,
                    CourseName = "HR Management",
                    CourseDetails = "Introduction to HR Management"
                };

                this.seedData.courses.Add(courseA);
                this.seedData.courses.Add(courseB);
                this.seedData.courses.Add(courseC);
            #endregion

            #region Students-Courses Relation Data
                var relationA = new StudentCourses()
                {
                   CourseId = 1,
                   StudentId =1
                };

                var relationB = new StudentCourses()
                {
                    CourseId = 2,
                    StudentId = 2
                };

                var relationC = new StudentCourses()
                {
                    CourseId = 3,
                    StudentId = 3
                };

                this.seedData.studentCourses.Add(relationA);
                this.seedData.studentCourses.Add(relationB);
                this.seedData.studentCourses.Add(relationC);
            #endregion

            return this.seedData;
        }
    }
}
