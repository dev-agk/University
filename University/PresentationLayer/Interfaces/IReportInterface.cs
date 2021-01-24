using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using University.Models;
using University.PresentationLayer.ViewModels;

namespace University.PresentationLayer.Interfaces
{
    public interface IReportInterface
    {
        public IEnumerable<StudentCourseReportViewModel> ReportStudentCourseRelation(List<Students> studentsList, List<Courses> courseList, List<StudentCourses> relations);

        public IEnumerable<StudentViewModel> GetAllStudentsforReport(List<Students> students);
        public StudentViewModel GetStudentforReport(Students students);

        public IEnumerable<CourseViewModel> GetAllCoursesforReport(List<Courses> courses);

        public CourseViewModel GetCourseforReport(Courses course);

        public SubscribeViewModel GetSubscribe(List<Students> students, List<Courses> courses);
    }
}
