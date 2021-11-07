using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENISSCHOOL
{
    public class Student
    {
       
        public int StudentID { get; set; } 
        public String Name { get; set; } 
        public String SurName { get; set; } 
        public String Class { get; set; } 
        public Grade Grade { get; set; }
        public StudentAddress Address { get; set; }
        public IList<Course> Courses { get; set; }

    }
}
