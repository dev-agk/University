using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using University.Data;
using University.Interfaces;
using University.Models;

namespace University.Services
{
    public class StudentCoursesService : IStudentCoursesInterface
    {
        IDataInterface dataSource;
        ApplicationDataSource data;
        private readonly IConfiguration config;


        public StudentCoursesService(IDataInterface _dataSource, IConfiguration _config)
        {
            config = _config;
            dataSource = _dataSource;
            var dataSourceName = config.GetValue<string>("DataSource");
            data = dataSource.GetDataSource(dataSourceName).GetSeedData();
        }

        public void AddStudentToCourse(int studentId, int courseId)
        {
            StudentCourses studentCourses = new StudentCourses()
            {
                CourseId = studentId,
                StudentId = studentId
            };

            try
            {
                data.studentCourses.Add(studentCourses);
            }
            catch (Exception ex)
            {

                throw ex;
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
                    throw new Exception("InvalidRelation");
                }
            }
            catch (Exception ex)
            {

                throw ex;
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
                throw ex;
            }
        }
    }
}
