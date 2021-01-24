using System.Collections.Generic;
using System.Linq;
using University.BusinessLayer.Interfaces;
using University.Interfaces;
using University.Models;
using University.PresentationLayer.ViewModels;

namespace University.BusinessLayer.Services
{
    public class StudentCourseBLService : IStudentCoursesBLInterface
    {
        IStudentsInterface students;
        ICoursesInterface courses;
        IStudentCoursesInterface studentcourses;

        public StudentCourseBLService(IStudentsInterface _students, ICoursesInterface _courses, IStudentCoursesInterface _studentCourses)
        {
            students = _students;
            courses = _courses;
            studentcourses = _studentCourses;
        }

        public Courses AddCourse(Courses course)
        {
            return courses.CreateCourse(course);
        }

        public StudentViewModel StudentViewModel(StudentViewModel student)
        {
            var laststudentId = students
                                .GetStudents()
                                .OrderByDescending(x => x.StudentId)
                                .FirstOrDefault()
                                .StudentId;

            Students std = new Students
            {
                StudentId = laststudentId + 1,
                ContactNo = student.Contact,
                DOB = student.DateOfBirth,
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            students.CreateStudent(std);

            return student;
        }

        public Courses DeleteCourse(int courseId)
        {
            return courses.DeleteCourse(courseId);
        }

        public Students DeleteStudent(int studentId)
        {
            return students.DeleteStudent(studentId);
        }

        public List<Courses> GetAllCourses()
        {
            return courses.GetCourses();
        }

        public List<StudentCourses> GetAllRelations()
        {
            return studentcourses.GetAllRelations();
        }

        public List<Students> GetAllStudents()
        {
            return students.GetStudents();
        }

        public Courses GetCourse(int courseId)
        {
            return courses.GetCourse(courseId);
        }

        public Students GetStudent(int studentId)
        {
            return students.GetStudent(studentId);
        }

        public void Subscribe(int studentId, int courseId)
        {
            studentcourses.AddStudentToCourse(studentId, courseId);
        }

        public void UnSubscribe(int studentId, int courseId)
        {
            studentcourses.DeleteStudentFromCourse(studentId, courseId);
        }

        public Courses UpdateCourse(Courses course)
        {
            return courses.UpdateCourse(course);
        }

        public Students UpdateStudent(Students student)
        {
            return students.UpdateStudent(student);
        }
    }
}
