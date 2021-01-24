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
    public class CourseService : ICoursesInterface
    {
        IDataInterface dataSource;
        ILoggerInterface logger;
        ApplicationDataSource data;
        private readonly IConfiguration config;

        public CourseService(IDataInterface _dataSource, IConfiguration _config, ILoggerInterface _logger)
        {
            config = _config;
            dataSource = _dataSource;
            data = dataSource.GetDataSource();
            logger = _logger;
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
                logger.Log(ex.Message); ;
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
                logger.Log(ex.Message);
                return null;
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
                logger.Log(ex.Message);
                return null;
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
                logger.Log(ex.Message);
                return null;
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
                logger.Log(ex.Message);
                return null;
            }
        }
    }
}
