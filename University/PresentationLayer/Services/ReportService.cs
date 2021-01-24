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
                throw ex;
            }
        }
    }
}
