using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public StudentService(IDataInterface _dataSource, IConfiguration _config)
        {
            config = _config;
            dataSource = _dataSource;
            var dataSourceName = config.GetValue<string>("DataSource");
            data = dataSource.GetDataSource(dataSourceName).GetSeedData();
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
            }
        }
    }
}
