using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENISSCHOOL
{
    public class Course
    {
        public int CourseID { get; set; }
        public String CourseName { get; set; }
        public int HoursNumber { get; set; }
        public int coefficient { get; set; }
        public IList<Student> Students { get; set; }
    }
}
