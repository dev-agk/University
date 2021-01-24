using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using University.BusinessLayer.Interfaces;
using University.Data;
using University.Interfaces;
using University.Models;

namespace University.Services
{
    public class StudentCoursesService : IStudentCoursesInterface
    {
        IDataInterface dataSource;
        ILoggerInterface logger;
        ApplicationDataSource data;
        private readonly IConfiguration config;


        public StudentCoursesService(IDataInterface _dataSource, IConfiguration _config, ILoggerInterface _logger)
        {
            config = _config;
            dataSource = _dataSource;
            data = dataSource.GetDataSource();
            logger = _logger;
        }

        public void AddStudentToCourse(int studentId, int courseId)
        {
            StudentCourses studentCourses = new StudentCourses()
            {
                CourseId = courseId,
                StudentId = studentId
            };

            try
            {
                data.studentCourses.Add(studentCourses);
            }
            catch (Exception ex)
            {

                logger.Log(ex.Message);
            }
        }

        public void DeleteStudentFromCourse(int studentId, int courseId)
        {
            var studentCourse = data.studentCourses
                                    .Where(x => x.StudentId == studentId && x.CourseId == courseId)
                                    .FirstOrDefault();

            try
            {
                if (studentCourse != null)
                {
                    data.studentCourses.Remove(studentCourse);
                }
                else
                {
                    logger.Log("Invalid Relation");
                }
            }
            catch (Exception ex)
            {

                logger.Log(ex.Message);
            }
        }

        public List<StudentCourses> GetAllRelations()
        {
            var studentCourses = data.studentCourses
                                    .ToList();

            try
            {
                if (studentCourses.Any())
                {
                    return studentCourses;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return null;
            }
        }
    }
}
