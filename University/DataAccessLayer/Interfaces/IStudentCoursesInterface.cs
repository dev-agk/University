using System.Collections.Generic;
using University.Models;

namespace University.Interfaces
{
    public interface IStudentCoursesInterface
    {
        public void AddStudentToCourse(int studentId, int courseId);

        public List<StudentCourses> GetAllRelations();

        public void DeleteStudentFromCourse(int studentId, int courseId);

    }
}
