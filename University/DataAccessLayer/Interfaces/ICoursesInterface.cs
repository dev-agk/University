using System.Collections.Generic;
using University.Models;

namespace University.Interfaces
{
    public interface ICoursesInterface
    {
        public Courses CreateCourse(Courses course);

        public List<Courses> GetCourses();

        public Courses GetCourse(int courseId);

        public Courses UpdateCourse(Courses course);

        public Courses DeleteCourse(int courseId);
    }
}
