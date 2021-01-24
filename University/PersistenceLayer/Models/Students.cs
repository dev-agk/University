using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string ContactNo { get; set; }

        public virtual List<StudentCourses> Courses {get;set;}
    }
}
