using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using University.BusinessLayer.Interfaces;
using University.Models;
using University.PresentationLayer.Interfaces;
using University.PresentationLayer.ViewModels;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStudentCoursesBLInterface university;

        private readonly IReportInterface report;


        public HomeController(ILogger<HomeController> logger, IStudentCoursesBLInterface _university, IReportInterface _report)
        {
            _logger = logger;
            university = _university;
            report = _report;
        }

        #region Report
        public IActionResult Report()
        {
            var studentsList = university.GetAllStudents();
            var courseList = university.GetAllCourses();
            var relations = university.GetAllRelations();

            var reportDetails = report.ReportStudentCourseRelation(studentsList, courseList, relations);

            return View(reportDetails);
        }

        public IActionResult Subscribe()
        {
            var students = university.GetAllStudents();
            var courses = university.GetAllCourses();

            var subscribe = report.GetSubscribe(students, courses);

            return View(subscribe);
        }

        [HttpPost]
        public IActionResult Subscribe(int studentId, int courseID)
        {
            university.Subscribe(studentId, courseID);
            return RedirectToAction("Report");
        } 

        #endregion

        #region Student 

        public IActionResult Students()
        {
            var students = university.GetAllStudents();
            var studentList = report.GetAllStudentsforReport(students);
            return View(studentList);
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentViewModel student)
        {
            var std = university.AddStudent(student);
            return RedirectToAction("Students");
        }

        public IActionResult DeleteStudent(int id)
        {
            var student = university.DeleteStudent(id);
            return RedirectToAction("Students");
        }

        public IActionResult UpdateStudent(int id)
        {
            var studentDetails = university.GetStudent(id);
            var studentInfo = report.GetStudentforReport(studentDetails);
            return View(studentInfo);
        }

        [HttpPost]
        public IActionResult UpdateStudent(StudentViewModel student)
        {
            var std = university.UpdateStudent(student);
            return RedirectToAction("Students");
        }

        #endregion

        #region Courses 

        public IActionResult Courses()
        {
            var courses = university.GetAllCourses();
            var courseList = report.GetAllCoursesforReport(courses);
            return View(courseList);
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(CourseViewModel course)
        {
            var c = university.AddCourse(course);
            return RedirectToAction("Courses");
        }

        public IActionResult DeleteCourse(int id)
        {
            var course = university.DeleteCourse(id);
            return RedirectToAction("Courses");
        }

        public IActionResult UpdateCourse(int id)
        {
            var courseDetails = university.GetCourse(id);
            var courseInfo = report.GetCourseforReport(courseDetails);
            return View(courseInfo);
        }

        [HttpPost]
        public IActionResult UpdateCourse(CourseViewModel course)
        {
            var c = university.UpdateCourse(course);
            return RedirectToAction("Courses");
        }

        #endregion



        #region Default
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //} 
        #endregion

    }
}
