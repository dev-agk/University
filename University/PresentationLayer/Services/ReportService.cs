using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using University.BusinessLayer.Interfaces;
using University.Models;
using University.PresentationLayer.Interfaces;
using University.PresentationLayer.ViewModels;

namespace University.PresentationLayer.Services
{
    public class ReportService : IReportInterface
    {
        ILoggerInterface logger;

        public ReportService(ILoggerInterface _logger)
        {
            logger = _logger;
        }

        public IEnumerable<StudentCourseReportViewModel> ReportStudentCourseRelation(List<Students> studentsList, List<Courses> courseList, List<StudentCourses> relations)
        {
            try
            {
                var report = (from r in relations
                              join s in studentsList on r.StudentId equals s.StudentId
                              join c in courseList on r.CourseId equals c.CourseID
                              select new StudentCourseReportViewModel
                              {
                                  Student = s.FirstName + " " + s.LastName,
                                  Course = c.CourseName
                              }).AsEnumerable();

                return report;
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return null;
            }
        }

        public IEnumerable<StudentViewModel> GetAllStudentsforReport(List<Students> students)
        {
            List<StudentViewModel> stds = new List<StudentViewModel>();

            foreach (var s in students)
            {
                var student = new StudentViewModel()
                {
                    id = s.StudentId,
                    Contact = s.ContactNo,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    DateOfBirth = s.DOB
                };

                stds.Add(student);
            }

            return stds;
        }

        public StudentViewModel GetStudentforReport(Students student)
        {
            var std = new StudentViewModel
            {
                id = student.StudentId,
                Contact = student.ContactNo,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DOB
            };

            return std;
        }

        public IEnumerable<CourseViewModel> GetAllCoursesforReport(List<Courses> courses)
        {
            List<CourseViewModel> courseInfo = new List<CourseViewModel>();

            foreach (var c in courses)
            {
                var course = new CourseViewModel()
                {
                    Id = c.CourseID,
                    CourseDetails = c.CourseDetails,
                    CourseName = c.CourseName
                };

                courseInfo.Add(course);
            }

            return courseInfo;
        }

        public CourseViewModel GetCourseforReport(Courses course)
        {
            var c = new CourseViewModel
            {
                Id = course.CourseID,
                CourseName = course.CourseName,
                CourseDetails = course.CourseDetails
            };

            return c;
        }

        public SubscribeViewModel GetSubscribe(List<Students> students, List<Courses> courses)
        {
            var studentSelectList = students.Select(a =>
                                  new SelectListItem
                                  {
                                      Text = a.FirstName + " " + a.LastName,
                                      Value = a.StudentId.ToString()
                                  }).ToList();

            var courseSelectList = courses.Select(a =>
                                 new SelectListItem
                                 {
                                     Text = a.CourseName,
                                     Value = a.CourseID.ToString()
                                 }).ToList();

            var subscribe = new SubscribeViewModel()
            {
                studentSelectList = studentSelectList,
                courseSelectList = courseSelectList
            };

            return subscribe;
        }
    }
}
