using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using University.Data;
using University.Interfaces;
using University.Models;

namespace University.Services
{
    public class CourseService : ICoursesInterface
    {
        IDataInterface dataSource;
        ApplicationDataSource data;
        private readonly IConfiguration config;

        public CourseService(IDataInterface _dataSource, IConfiguration _config)
        {
            config = _config;
            dataSource = _dataSource;
            var dataSourceName = config.GetValue<string>("DataSource");
            data = dataSource.GetDataSource(dataSourceName);
        }


        public Courses CreateCourse(Courses course)
        {
            try
            {
                if (course != null)
                {
                    data.courses.Add(course);
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

            return course;
        }

        public Courses DeleteCourse(int courseId)
        {
            try
            {
                var course = data
                                .courses
                                .Where(x => x.CourseID == courseId)
                                .FirstOrDefault();

                if (course != null)
                {
                    data.courses.Remove(course);
                }
                else
                {
                    return null;
                }
                return course;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Courses GetCourse(int courseId)
        {
            try
            {
                var course = data
                                .courses
                                .Where(x => x.CourseID == courseId)
                                .FirstOrDefault();

                if (course != null)
                {
                    return course;
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

        public List<Courses> GetCourses()
        {
            try
            {
                var courses = data
                                .courses
                                .ToList();

                if (courses.Any())
                {
                    return courses;
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

        public Courses UpdateCourse(Courses course)
        {
            try
            {
                if (course != null)
                {
                    var oldCourseDetails = data
                                            .courses
                                            .Where(x => x.CourseID == course.CourseID)
                                            .FirstOrDefault();

                    oldCourseDetails.CourseName = course.CourseName;
                    oldCourseDetails.CourseDetails = course.CourseDetails;

                    return course;
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
