using System.Collections.Generic;
using University.Models;
using University.PresentationLayer.ViewModels;

namespace University.BusinessLayer.Interfaces
{
    public interface IStudentCoursesBLInterface
    {
        #region Students

        public StudentViewModel AddStudent(StudentViewModel student);

        public List<Students> GetAllStudents();

        public Students GetStudent(int studentId);

        public Students UpdateStudent(StudentViewModel student);

        public Students DeleteStudent(int studentId);

        #endregion

        #region Courses

        public CourseViewModel AddCourse(CourseViewModel course);

        public List<Courses> GetAllCourses();

        public Courses GetCourse(int courseId);

        public Courses UpdateCourse(CourseViewModel course);

        public Courses DeleteCourse(int courseId);

        #endregion

        #region Student Courses Relation

        public void Subscribe(int studentId, int courseId);

        public List<StudentCourses> GetAllRelations();

        public void UnSubscribe(int studentId, int courseId);

        #endregion
    }
}
