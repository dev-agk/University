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
    public class StudentService : IStudentsInterface
    {
        IDataInterface dataSource;
        ApplicationDataSource data;
        private readonly IConfiguration config;
        ILoggerInterface logger;

        public StudentService(IDataInterface _dataSource, IConfiguration _config, ILoggerInterface _logger)
        {
            config = _config;
            dataSource = _dataSource;
            data = dataSource.GetDataSource();
            logger = _logger;
        }

        public Students CreateStudent(Students student)
        {
            try
            {
                if (student != null)
                {
                    data.students.Add(student);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
            }

            return student;
        }

        public Students DeleteStudent(int studentId)
        {
            try
            {
                var student = data
                                .students
                                .Where(x => x.StudentId == studentId)
                                .FirstOrDefault();

                if (student != null)
                {
                    data.students.Remove(student);
                }
                else
                {
                    return null;
                }
                return student;
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return null;
            }
        }

        public Students GetStudent(int studentId)
        {
            try
            {
                var student = data
                                .students
                                .Where(x => x.StudentId == studentId)
                                .FirstOrDefault();

                if (student != null)
                {
                    return student;
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

        public List<Students> GetStudents()
        {
            try
            {
                var students = data
                                .students
                                .ToList();

                if (students.Any())
                {
                    return students;
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

        public Students UpdateStudent(Students student)
        {
            try
            {
                if (student != null)
                {
                    var oldStudentDetails = data
                                            .students
                                            .Where(x => x.StudentId == student.StudentId)
                                            .FirstOrDefault();

                    oldStudentDetails.FirstName = student.FirstName;
                    oldStudentDetails.LastName = student.LastName;
                    oldStudentDetails.DOB = student.DOB;
                    oldStudentDetails.ContactNo = student.ContactNo;

                    return student;
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
