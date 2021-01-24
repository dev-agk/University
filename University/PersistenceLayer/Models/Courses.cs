using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class Courses
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public string CourseDetails { get; set; }

        public virtual List<StudentCourses> Students { get; set; }

        public virtual Courses Course { get; set; }

        public virtual Students Student { get; set; }

    }
}
