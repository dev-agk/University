using System.Collections.Generic;
using University.Models;

namespace University.Interfaces
{
    public interface IStudentsInterface
    {
        public Students CreateStudent(Students student);

        public List<Students> GetStudents();

        public Students GetStudent(int studentId);

        public Students UpdateStudent(Students student);

        public Students DeleteStudent(int studentId);
        
    }
}
