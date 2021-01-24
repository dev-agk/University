using System.Collections.Generic;
using University.Models;
using University.PresentationLayer.ViewModels;

namespace University.PresentationLayer.Interfaces
{
    public interface IReportInterface
    {
        public IEnumerable<StudentCourseReportViewModel> ReportStudentCourseRelation(List<Students> studentsList, List<Courses> courseList, List<StudentCourses> relations);
    }
}
