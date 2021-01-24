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

        public CourseViewModel AddCourse(CourseViewModel course)
        {
            var lastCourseId = courses
                     .GetCourses()
                     .OrderByDescending(x => x.CourseID)
                     .FirstOrDefault()
                     .CourseID;

            Courses c = new Courses
            {
                CourseID = course.Id,
                CourseName = course.CourseName,
                CourseDetails = course.CourseDetails
            };

            courses.CreateCourse(c);

            //TO DO: Needs to be changed
            course.Id = lastCourseId + 1;

            return course;
        }

        public StudentViewModel AddStudent(StudentViewModel student)
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

            //TO DO: Needs to be changed
            student.id = laststudentId + 1;

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

        public Courses UpdateCourse(CourseViewModel course)
        {
            var c = new Courses()
            {
                CourseID = course.Id,
                CourseName = course.CourseName,
                CourseDetails = course.CourseDetails,
            };

            return courses.UpdateCourse(c);
        }

        public Students UpdateStudent(StudentViewModel student)
        {
            var std = new Students()
            {
                StudentId = student.id,
                ContactNo = student.Contact,
                DOB = student.DateOfBirth,
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            return students.UpdateStudent(std);
        }
    }
}
