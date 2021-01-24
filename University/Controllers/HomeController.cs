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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult StudentCourses()
        {
            var studentsList = university.GetAllStudents();
            var courseList = university.GetAllCourses();
            var relations = university.GetAllRelations();

            var reportDetails = report.ReportStudentCourseRelation(studentsList, courseList, relations);

            return View(reportDetails);
        }


        public IActionResult Students()
        {

            return View();
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public string AddStudent(StudentViewModel student)
        {
            var std = university.AddStudent(student);
            return (std == null ? "Failed" : "OK");
        }

        [HttpPost]
        public string DeleteStudent(StudentViewModel student)
        {
            var std = university.DeleteStudent();
        }
    }
}
